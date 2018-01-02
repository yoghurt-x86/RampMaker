using Surf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit;
using HelixToolkit.Wpf;
using Surf.Library;

namespace Ramps.ViewModels
{
    public class MainViewModel
    {
        public Model3DGroup Ramps { get; set; }
        public LinesVisual3D Lines { get; set; }

        public MainViewModel()
        {
            Ramps = new Model3DGroup();
            var point1 = new Point3D(0, 0, 0);
            var point2 = new Point3D(30, 0, 0);
            var point3 = new Point3D(40, 0, 20);
            var point4 = new Point3D(50, 0, 20);
            AddCurvedBezier(point1, point2, point3, point4, 10);
            
            point1 = new Point3D(0, 0, 0);
            point2 = new Point3D(0, 30, 0);
            point3 = new Point3D(0, 40, 20);
            point4 = new Point3D(0, 50, 20);
            AddCurvedBezier(point1, point2, point3, point4, 20);


            point1 = new Point3D(0, 0, 0);
            point2 = new Point3D(30, -30, 0);
            point3 = new Point3D(40, -40, 20);
            point4 = new Point3D(50, -50, 20);
            AddCurvedBezier(point1, point2, point3, point4, 20);
            point1 = new Point3D(0, 0, 0);
            point2 = new Point3D(30, 30, 0);
            point3 = new Point3D(40, 40, 20);
            point4 = new Point3D(50, 50, 20);
            AddCurvedBezier(point1, point2, point3, point4, 20);
            point1 = new Point3D(0, 0, 0);
            point2 = new Point3D(-30, 30, 0);
            point3 = new Point3D(-40, 40, 20);
            point4 = new Point3D(-50, 50, 20);
            AddCurvedBezier(point1, point2, point3, point4, 20);
            point1 = new Point3D(0, 0, 0);
            point2 = new Point3D(-30, -30, 0);
            point3 = new Point3D(-40, -40, 20);
            point4 = new Point3D(-50, -50, 20);
            AddCurvedBezier(point1, point2, point3, point4, 20);
            point1 = new Point3D(0, 0, 0);
            point2 = new Point3D(30, -30, -0);
            point3 = new Point3D(40, -40, -20);
            point4 = new Point3D(50, -50, -20);
            AddCurvedBezier(point1, point2, point3, point4, 20);
            point1 = new Point3D(0, 0, -0);
            point2 = new Point3D(30, 30, -0);
            point3 = new Point3D(40, 40, -20);
            point4 = new Point3D(50, 50, -20);
            AddCurvedBezier(point1, point2, point3, point4, 20);
            point1 = new Point3D(0, 0, -0);
            point2 = new Point3D(-30, 30, -0);
            point3 = new Point3D(-40, 40, -20);
            point4 = new Point3D(-50, 50, -20);
            AddCurvedBezier(point1, point2, point3, point4, 20);
            point1 = new Point3D(0, 0, -0);
            point2 = new Point3D(-30, -30, -0);
            point3 = new Point3D(-40, -40, -20);
            point4 = new Point3D(-50, -50, -20);
            AddCurvedBezier(point1, point2, point3, point4, 20);

        }

        internal void updateBezier(Point3D p0, Point3D p1, Point3D p2, Point3D p3, int segments)
        {
            Ramps.Children.Clear();
            AddCurvedBezier(p0, p1, p2, p3, segments);
        }

        private void AddCurvedBezier(Point3D point1, Point3D point2, Point3D point3, Point3D point4, int segments)
        {
            var points = new Bezier3D(point1, point2, point3, point4).GetPoints(segments).ToArray();
            var ramps = new List<SurfSegment>();
            for (int i = 1; i < points.Count(); i++)
            {
                ramps.Add(new SurfSegment(points[i - 1], points[i], 12));
            }
            foreach (var ramp in ramps)
            {
                Ramps.Children.Add(new GeometryModel3D { Geometry = ramp.Model, Material = new DiffuseMaterial { Brush = Brushes.Gray } });
            }
        }
    }
}
