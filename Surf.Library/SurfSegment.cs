using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Composition;
using System.Windows.Media.Media3D;

namespace Surf.Library
{
    public class SurfSegment
    {
        public static Vector3D Z_AXIS = new Vector3D(0,0,1);
        public static Vector3D Y_AXIS = new Vector3D(0,1,0);

        public MeshGeometry3D Model { get; private set; }

        public SurfSegment(Point3D startPoint, Point3D endPoint, double rampHeight)
        {
            var v1 = startPoint.VectorToPoint(endPoint);
            var Positions = UnitSurfRamp();

            // Create transforms to position Ramp 
            var transform = new Transform3DGroup();
            transform.Children.Add(new ScaleTransform3D(startPoint.VectorToPoint(endPoint).Length, rampHeight / 5, rampHeight / 5)); //Size of ramp

            //Rotate ramps!!!

            transform.Children.Add(new TranslateTransform3D(startPoint.ToVector())); //Translate to startPoint

            transform.Transform(Positions); //Apply Transform


            Model = new MeshGeometry3D //Apply Mesh
            {
                Positions = new Point3DCollection(Positions),
                TriangleIndices = new System.Windows.Media.Int32Collection()
                {
                    3,2,0,
                    1,3,0,
                    5,3,1,
                    0,4,1,
                    2,4,0,
                    4,5,1,
                    4,2,3,
                    5,4,3,
                }
            };
        }

        private Point3D[] UnitSurfRamp() {
            /* Initialize Unit SurfRamp */
            return new Point3D[] {
                new Point3D(0, 0, 5),
                new Point3D(1, 0, 5),
                new Point3D(0,-4, 0),
                new Point3D(0, 4, 0),
                new Point3D(1,-4, 0),
                new Point3D(1, 4, 0)
            };
        }
    }
}
