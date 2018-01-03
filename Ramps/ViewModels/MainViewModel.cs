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
            AddCurvedBezier(point1, point2, point3, point4, 50);
                                                            
            point1 = new Point3D(0, 0, 0);                  
            point2 = new Point3D(0, 30, 0);                 
            point3 = new Point3D(0, 40, 20);                
            point4 = new Point3D(0, 50, 20);                 
            AddCurvedBezier(point1, point2, point3, point4, 50);
                                                            
                                                            
            point1 = new Point3D(0, 0, 0);                  
            point2 = new Point3D(30, -30, 0);               
            point3 = new Point3D(40, -40, 20);              
            point4 = new Point3D(50, -50, 20);               
            AddCurvedBezier(point1, point2, point3, point4, 50);
            point1 = new Point3D(0, 0, 0);                  
            point2 = new Point3D(30, 30, 0);                
            point3 = new Point3D(40, 40, 20);               
            point4 = new Point3D(50, 50, 20);               
            AddCurvedBezier(point1, point2, point3, point4, 50);
            point1 = new Point3D(0, 0, 0);                  
            point2 = new Point3D(-30, 30, 0);               
            point3 = new Point3D(-40, 40, 20);              
            point4 = new Point3D(-50, 50, 20);              
            AddCurvedBezier(point1, point2, point3, point4, 50);
            point1 = new Point3D(0, 0, 0);                  
            point2 = new Point3D(-30, -30, 0);              
            point3 = new Point3D(-40, -40, 20);             
            point4 = new Point3D(-50, -50, 20);             
            AddCurvedBezier(point1, point2, point3, point4, 50);
            point1 = new Point3D(0, 0, 0);                  
            point2 = new Point3D(30, -30, -0);              
            point3 = new Point3D(40, -40, -20);             
            point4 = new Point3D(50, -50, -20);             
            AddCurvedBezier(point1, point2, point3, point4, 50);
            point1 = new Point3D(0, 0, -0);                 
            point2 = new Point3D(30, 30, -0);               
            point3 = new Point3D(40, 40, -20);              
            point4 = new Point3D(50, 50, -20);              
            AddCurvedBezier(point1, point2, point3, point4, 50);
            point1 = new Point3D(0, 0, -0);                 
            point2 = new Point3D(-30, 30, -0);              
            point3 = new Point3D(-40, 40, -20);             
            point4 = new Point3D(-50, 50, -20);             
            AddCurvedBezier(point1, point2, point3, point4, 50);
            point1 = new Point3D(0, 0, -0);                 
            point2 = new Point3D(-30, -30, -0);             
            point3 = new Point3D(-40, -40, -20);            
            point4 = new Point3D(-50, -50, -20);            
            AddCurvedBezier(point1, point2, point3, point4, 50);

        }

        internal void updateBezier(Point3D p0, Point3D p1, Point3D p2, Point3D p3, int segments)
        {
            Ramps.Children.Clear();
            AddCurvedBezier(p0, p1, p2, p3, segments);
        }

        private void AddCurvedBezier(Point3D point1, Point3D point2, Point3D point3, Point3D point4, int segments)
        {
            var points = new Bezier3D(point1, point2, point3, point4).GetPoints(segments).ToArray();
            SurfSegment[] ramps = new SurfSegment[points.Length - 1];
            for (int i = 1; i < points.Length; i++)
            {
                ramps[i - 1] = new SurfSegment(points[i - 1], points[i], 10);
                Console.WriteLine("Points" + points[i - 1] + " , " + points[i]);
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
