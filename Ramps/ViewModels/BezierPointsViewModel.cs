using Surf.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Ramps.ViewModels
{
    public class BezierPointsViewModel : BaseViewModel
    {
        public ICommand FlattenX { get; }
        public ICommand FlattenY { get; }
        public ICommand FlattenZ { get; }
        public ICommand FlattenDirectionally { get; }

        private double _P0X;
        public double P0X { get => _P0X; set { if (value != _P0X) { _P0X = value; OnPropertyChanged(); } } }

        private double _P0Y;
        public double P0Y { get => _P0Y; set { if (value != _P0Y) { _P0Y = value; OnPropertyChanged(); } } }

        private double _P0Z;
        public double P0Z { get => _P0Z; set { if (value != _P0Z) { _P0Z = value; OnPropertyChanged(); } } }

        private double _P1X;
        public double P1X { get => _P1X; set { if (value != _P1X) { _P1X = value; OnPropertyChanged(); } } }

        private double _P1Y;
        public double P1Y { get => _P1Y; set { if (value != _P1Y) { _P1Y = value; OnPropertyChanged(); } } }

        private double _P1Z;
        public double P1Z { get => _P1Z; set { if (value != _P1Z) { _P1Z = value; OnPropertyChanged(); } } }

        private double _P2X;
        public double P2X { get => _P2X; set { if (value != _P2X) { _P2X = value; OnPropertyChanged(); } } }

        private double _P2Y;
        public double P2Y { get => _P2Y; set { if (value != _P2Y) { _P2Y = value; OnPropertyChanged(); } } }

        private double _P2Z;
        public double P2Z { get => _P2Z; set { if (value != _P2Z) { _P2Z = value; OnPropertyChanged(); } } }

        private double _P3X;
        public double P3X { get => _P3X; set { if (value != _P3X) { _P3X = value; OnPropertyChanged(); } } }

        private double _P3Y;
        public double P3Y { get => _P3Y; set { if (value != _P3Y) { _P3Y = value; OnPropertyChanged(); } } }

        private double _P3Z;
        public double P3Z { get => _P3Z; set { if (value != _P3Z) { _P3Z = value; OnPropertyChanged(); } } }

        private int _segments;
        public int Segments { get => _segments; set { if (value != _segments) { _segments = value; OnPropertyChanged(); } } }

        public BezierPointsViewModel()
        {
            P0X = 0;
            P0Y = 0;
            P0Z = 0;
            P1X = 256;
            P1Y = 0;
            P1Z = 0;
            P2X = -256;
            P2Y = 0;
            P2Z = 0;
            P3X = 512;
            P3Y = 0;
            P3Z = 128;
            Segments = 5;
            FlattenX = new RelayCommand(o => FlattenOnX());
            FlattenY = new RelayCommand(o => FlattenOnY());
            FlattenZ = new RelayCommand(o => FlattenOnZ());
        }

        public Bezier3D ToBezier3D()
        {
            var p0 = new Point3D(P0X, P0Y, P0Z);
            var p1 = new Point3D(P0X + P1X, P0Y + P1Y, P0Z + P1Z);
            var p2 = new Point3D(P3X + P2X, P3Y + P2Y, P3Z + P2Z);
            var p3 = new Point3D(P3X, P3Y, P3Z);
            return new Bezier3D(p0, p1, p2, p3);
        }

        private void FlattenOnX()
        {
            P1X = P0X;
            P2X = P0X;
            P3X = P0X;
        }

        private void FlattenOnY()
        {
            P1Y = P0Y;
            P2Y = P0Y;
            P3Y = P0Y;
        }

        private void FlattenOnZ()
        {
            P1Z = P0Z;
            P2Z = P0Z;
            P3Z = P0Z;
        }

      
    }      
}           