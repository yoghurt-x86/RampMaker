using Surf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Media3D;
using HelixToolkit;
using HelixToolkit.Wpf;
using Surf.Library;
using System.Windows.Media;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Specialized;

namespace Ramps.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BezierPointsViewModel _bezierPoints;
        public  BezierPointsViewModel CurrentBezierPoints {get { return this._bezierPoints; } set { if (value != _bezierPoints) { _bezierPoints = value; OnPropertyChanged(); } } }

        private ObservableCollection<BezierPointsViewModel> _BezierList;
        public  ObservableCollection<BezierPointsViewModel> BezierList { get => _BezierList; set { if (value != _BezierList) { _BezierList = value; OnPropertyChanged(); } } }

        private double _height;
        public  double Height { get => _height; set { if (value != _height) { _height = value; OnPropertyChanged(); } } }

        public ICommand AddSegment { get; }
        public ICommand RemoveSegment { get; }

        public Model3DGroup Ramps { get; private set; }

        public MainViewModel() : base()
        {
            Height = 384;
            Ramps = new Model3DGroup();
            CurrentBezierPoints = new BezierPointsViewModel();
            BezierList = new ObservableCollection<BezierPointsViewModel> { CurrentBezierPoints };
            BezierList.CollectionChanged += OnPropertyChanged;
            AddSegment    = new RelayCommand(o => AddSegmentCommand());
            RemoveSegment = new RelayCommand(o => RemoveSegmentCommand());
            CurrentBezierPoints.PropertyChanged += UpdateRamps;
                           this.PropertyChanged += UpdateRamps;
            OnPropertyChanged();
        }

        private void UpdateRamps(object sender, PropertyChangedEventArgs e)
        {
            var bezier3DList = new List<Bezier3D>();
            var surfRamps =    new List<SurfRamp>();

            Vector3D translateVector = new Vector3D(0,0,0);
            for (int i = 0; i < BezierList.Count; i++)
            {
                var bezier = BezierList[i].ToBezier3D();
                bezier.Translate(translateVector);

                translateVector.X += BezierList[i].P3X;
                translateVector.Y += BezierList[i].P3Y;
                translateVector.Z += BezierList[i].P3Z;

                var ramp = new SurfRamp(bezier, BezierList[i].Segments, Height);
                if (BezierList[i].Equals(CurrentBezierPoints)) ramp.Material = new DiffuseMaterial { Brush = Brushes.MediumVioletRed };
                surfRamps.Add(ramp);
            }

            
            var ModelCollection = new Model3DCollection();
            for (int i = 1; i < surfRamps.Count; i++)
            {
                try { surfRamps[i - 1].LinkTo(surfRamps[i]); } catch (ArgumentException) {  }
                ModelCollection.Add(new Model3DGroup { Children = surfRamps[i - 1].GetModel3D() });
            }
            ModelCollection.Add(new Model3DGroup { Children = surfRamps.Last().GetModel3D() });
            Ramps.Children = ModelCollection;
        }
        private void AddSegmentCommand()
        {
            var bezier = new BezierPointsViewModel();
            bezier.PropertyChanged += UpdateRamps;
            BezierList.Add(bezier);
            CurrentBezierPoints = bezier;
        }

        private void RemoveSegmentCommand()
        {
            BezierList.Remove(CurrentBezierPoints);
            CurrentBezierPoints = BezierList.First();
        }
    }
}
