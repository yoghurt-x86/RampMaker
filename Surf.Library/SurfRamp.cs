using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Composition;
using System.Windows.Media.Media3D;
using MS.Internal.Media3D;
using Surf.Library;

namespace Surf
{
    public class SurfRamp
    {

        public MeshGeometry3D Model { get; private set; }

        public SurfRamp(Point3D startPoint, Point3D endPoint, double rampHeight)
        {
            var v1 = startPoint.VectorToPoint(endPoint);
            var Positions = UnitSurfRamp();

            // Create transforms to position Ramp 
            var transform = new Transform3DGroup();
            transform.Children.Add(new ScaleTransform3D(startPoint.VectorToPoint(endPoint).Length, rampHeight / 5, rampHeight / 5));                                //Size of ramp
            transform.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), -Vector3D.AngleBetween(v1, new Vector3D(v1.X, v1.Y, 0))))); //Rotate up/down on the Y angle
            transform.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), -Vector3D.AngleBetween(v1, new Vector3D(v1.X, 0, v1.Z))))); //Rotate Left/Right on the Z angle
            //transform.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(v1, rotation)));                                                                 //Rotate locally around the direction of ramp
            transform.Children.Add(new TranslateTransform3D(startPoint.ToVector()));                                                                                //Translate to startPoint

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
