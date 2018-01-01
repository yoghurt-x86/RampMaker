using Surf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit;

namespace Ramps.ViewModels
{
    public class MainViewModel
    {
        public Model3DGroup Ramps { get; set; }
    
        public MainViewModel()
        {
            Ramps = new Model3DGroup();
            var ramp = new SurfRamp(new Point3D(-20, 0, 0), new Point3D(0, 0, 0), 10);
            var ramp2 = new SurfRamp(new Point3D(0, 0, 0), new Point3D(20, 20, 0), 10);
            Ramps.Children.Add(new GeometryModel3D { Geometry = ramp.Model, Material = new DiffuseMaterial { Brush = Brushes.Gray } });
            Ramps.Children.Add(new GeometryModel3D { Geometry = ramp2.Model, Material = new DiffuseMaterial { Brush = Brushes.Gray } });
        }
    }
}
