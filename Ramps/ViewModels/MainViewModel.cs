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
            var ramp = new SurfRamp(new Point3D(-20, 0, 0), new Point3D(0, 0, 0), new Point3D(-20, -10, 0));
            Ramps.Children.Add(new GeometryModel3D { Geometry = ramp.Model, Material = new DiffuseMaterial { Brush = Brushes.Gray } });
            
        }
    }
}
