using Surf.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramps.ViewModels
{
    public class BezierPointsViewModel : BaseViewModel
    {
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

    }
}
