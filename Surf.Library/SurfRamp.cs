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
        

        public SurfRamp()
        {
            Model = UnitSurfRamp();
        }
        public SurfRamp(Point3D startPoint, Point3D endPoint, Point3D bottomPoint)
        {
            var v1 = startPoint.VectorToPoint(bottomPoint);
            var r = new RotateTransform3D(new AxisAngleRotation3D(startPoint.VectorToPoint(endPoint), 90), bottomPoint);
            var v2 = r.Transform(v1);

            var point3 = new Point3D(bottomPoint.X + (v2.X * 0.8), bottomPoint.Y + (v2.Y * 0.8), bottomPoint.Z + (v2.Z * 0.8));
            var point4 = new Point3D(bottomPoint.X - (v2.X * 0.8), bottomPoint.Y - (v2.Y * 0.8), bottomPoint.Z - (v2.Z * 0.8));

            var point5 = new Point3D(endPoint.X + v1.X + (v2.X * 0.8), endPoint.Y + v1.Y + (v2.Y * 0.8), endPoint.Z + v1.Z + (v2.Z * 0.8));
            var point6 = new Point3D(endPoint.X + v1.X - (v2.X * 0.8), endPoint.Y + v1.Y - (v2.Y * 0.8), endPoint.Z + v1.Z - (v2.Z * 0.8));

            Model = new MeshGeometry3D
            {
                Positions = new Point3DCollection
                {
                    startPoint,
                    endPoint,
                    point3,
                    point4,
                    point5,
                    point6
                },
                TriangleIndices = new System.Windows.Media.Int32Collection()
                {
                    0,2,3,
                    0,3,1,
                    1,3,5,
                    1,4,0,
                    0,4,2,
                    1,5,4,
                    3,2,4,
                    3,4,5,
                }
            };
        }
        private MeshGeometry3D UnitSurfRamp() {
            /* Initialize Unit SurfRamp */
            return new MeshGeometry3D
            {
                Positions = new Point3DCollection() {
                    new Point3D(0,0,0),
                    new Point3D(1,0,0),
                    new Point3D(0,-5,-4),
                    new Point3D(0,-5,4),
                    new Point3D(1,-5,-4),
                    new Point3D(1,-5,4)
                },
                TriangleIndices = new System.Windows.Media.Int32Collection()
                {
                    0,2,3,
                    0,3,1,
                    1,3,5,
                    1,4,0,
                    0,4,2,
                    1,5,4,
                    3,2,4,
                    3,4,5,
                }
            };
        }
    }
}
