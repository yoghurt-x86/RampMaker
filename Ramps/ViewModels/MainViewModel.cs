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

namespace Ramps.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BezierPointsViewModel _bezierPoints;
        public BezierPointsViewModel BezierPoints {get { return this._bezierPoints; } set { if (value != _bezierPoints) { _bezierPoints = value; OnPropertyChanged(); } } }

        private Model3DGroup _currentRamp;
        public Model3DGroup CurrentRamp { get { return this._currentRamp; } set { if (value != _currentRamp) { _currentRamp = value; OnPropertyChanged(); } } }



        public Model3DGroup Ramps { get; private set; }

        public MainViewModel()
        {
            BezierPoints = new BezierPointsViewModel();
            BezierPoints.PropertyChanged += UpdatecurrentRamp;
            Ramps = new Model3DGroup();
            CurrentRamp = new Model3DGroup();

        }

        private void UpdatecurrentRamp(object sender, PropertyChangedEventArgs e)
        {
            try { 
                var p0 = new Point3D(BezierPoints.P0X, BezierPoints.P0Y, BezierPoints.P0Z);
                var p1 = new Point3D(BezierPoints.P1X, BezierPoints.P1Y, BezierPoints.P1Z);
                var p2 = new Point3D(BezierPoints.P2X, BezierPoints.P2Y, BezierPoints.P2Z);
                var p3 = new Point3D(BezierPoints.P3X, BezierPoints.P3Y, BezierPoints.P3Z);
                var Bezier = new Bezier3D(p0, p1, p2, p3);

                CurrentRamp.Children.Clear();
                var points = Bezier.GetPoints(BezierPoints.Segments).ToArray();
                SurfSegment[] ramps = new SurfSegment[points.Length - 1];
                for (int i = 1; i < points.Length; i++)
                {
                    ramps[i - 1] = new SurfSegment(points[i - 1], points[i], BezierPoints.Height);
                }
                for (int i = 0; i < ramps.Length - 1; i++)
                {
                    ramps[i].LinkTo(ramps[i + 1]);
                    CurrentRamp.Children.Add(new GeometryModel3D { Geometry = ramps[i].Model, Material = new DiffuseMaterial { Brush = Brushes.PowderBlue } });
                }
                CurrentRamp.Children.Add(new GeometryModel3D { Geometry = ramps[ramps.Length - 1].Model, Material = new DiffuseMaterial { Brush = Brushes.PowderBlue } });
            }
            catch (Exception)
            {
                return;
            }
        }

        private void AddCurvedBezier(Bezier3D bezier, int segments, double Height)
        {
            var points = bezier.GetPoints(segments).ToArray();
            SurfSegment[] ramps = new SurfSegment[points.Length - 1];
            for (int i = 1; i < points.Length; i++)
            {
                ramps[i - 1] = new SurfSegment(points[i - 1], points[i], Height);
            }
            for (int i = 0; i < ramps.Length - 1; i++)
            {
                ramps[i].LinkTo(ramps[i + 1]);
                Ramps.Children.Add(new GeometryModel3D { Geometry = ramps[i].Model, Material = new DiffuseMaterial { Brush = Brushes.Gray } });
            }
            Ramps.Children.Add(new GeometryModel3D { Geometry = ramps[ramps.Length - 1].Model, Material = new DiffuseMaterial { Brush = Brushes.Gray } });

        }
    }
}
