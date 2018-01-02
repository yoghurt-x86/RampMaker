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
            var n2 = Vector3D.CrossProduct(Z_AXIS, v1);
            var n3 = Vector3D.CrossProduct(v1, n2);
            n2.Normalize();
            n3.Normalize();

            var vH = Vector3D.Multiply(rampHeight, n3);
            var vW = Vector3D.Multiply((rampHeight * 0.8d), n2);

            var p0 = new Point3D(startPoint.X + vH.X, startPoint.Y + vH.Y, startPoint.Z + vH.Z);
            var p1 = new Point3D(endPoint.X + vH.X, endPoint.Y + vH.Y, endPoint.Z + vH.Z);
            var p2 = new Point3D(startPoint.X + vW.X, startPoint.Y + vW.Y, startPoint.Z + vW.Z);
            var p3 = new Point3D(startPoint.X - vW.X, startPoint.Y - vW.Y, startPoint.Z - vW.Z);
            var p4 = new Point3D(endPoint.X + vW.X, endPoint.Y + vW.Y, endPoint.Z + vW.Z);
            var p5 = new Point3D(endPoint.X - vW.X, endPoint.Y - vW.Y, endPoint.Z - vW.Z);

            Model = new MeshGeometry3D //Apply Mesh
            {
                Positions = new Point3DCollection {
                    p0,
                    p1,
                    p2,
                    p3,
                    p4,
                    p5
                },
                TriangleIndices = new System.Windows.Media.Int32Collection()
                {
                    2,3,0,
                    3,1,0,
                    3,5,1,
                    4,0,1,
                    4,2,0,
                    5,4,1,
                    2,4,3,
                    4,5,3,
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
