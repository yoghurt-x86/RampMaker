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
        public static Vector3D Z_AXIS = new Vector3D(0,0,100);
        public static Vector3D Y_AXIS = new Vector3D(0,100,0);

        public MeshGeometry3D Model { get; private set; }
        public Point3D StartPoint { get; private set; }
        public Point3D EndPoint { get; private set; }
        public double Height { get; private set; }

        public SurfSegment(Point3D startPoint, Point3D endPoint, double rampHeight)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Height = rampHeight;

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

        public Vector3D GetDirection()
        {
            return StartPoint.VectorToPoint(EndPoint);
        }

        public void LinkTo(SurfSegment seg)
        {
            if (EndPoint.X != seg.StartPoint.X && EndPoint.Y != seg.StartPoint.Y && EndPoint.Z != seg.StartPoint.Z)
            {
                throw new ArgumentException("The ramp does not share endpoint/startpoint");
            }
            var cross = Vector3D.CrossProduct( GetDirection(), seg.GetDirection() );
            var dot =   Vector3D.DotProduct(   GetDirection(), seg.GetDirection() );

            if (dot.ApproximateEquals(0))
            {
                throw new NotImplementedException("Ramp is Straight on");
            }
            else if (cross.Z.ApproximateEquals(0))
            { //vertical turn (up/down)

                if (VerticalDirection(seg)) //up
                {
                    //do nothing actually
                }
                else //down
                {
                    //Math incoming
                    Point3D sharedPoint = new Point3D();

                    //Calculate
                    Vector3D v;
                    Vector3D n2;
                    Vector3D n3;

                    v = StartPoint.VectorToPoint(EndPoint);
                    n2 = Vector3D.CrossProduct(Z_AXIS, v);
                    n3 = Vector3D.CrossProduct(v, n2);
                    n3.Normalize();
                    var h1 = new Vector3D(n3.X * Height, n3.Y * Height, n3.Z * Height);
                    v = seg.StartPoint.VectorToPoint(seg.EndPoint);
                    n2 = Vector3D.CrossProduct(Z_AXIS, v);
                    n3 = Vector3D.CrossProduct(v, n2);
                    n3.Normalize();
                    var h2 = new Vector3D(n3.X * Height, n3.Y * Height, n3.Z * Height);

                    var V1 = StartPoint.VectorToPoint(seg.EndPoint);
                    var V2 = new Vector3D(h2.X - h1.X, h2.Y - h1.Y, h2.Z - h1.Z);

                    var v1 = StartPoint.VectorToPoint(EndPoint);
                    var v2 = seg.StartPoint.VectorToPoint(seg.EndPoint);

                    var k = V2.Length / V1.Length;

                    sharedPoint.X = EndPoint.X + h1.X + (v1.X * k);
                    sharedPoint.Y = EndPoint.Y + h1.Y + (v1.Y * k);
                    sharedPoint.Z = EndPoint.Z + h1.Z + (v1.Z * k);

                    //assign
                    this.Model.Positions[1] = sharedPoint;
                    seg.Model.Positions[0] = sharedPoint;
                }

            }
            else if (cross.X.ApproximateEquals(0) && cross.Y.ApproximateEquals(0))
            {
                throw new NotImplementedException("Horizontal right/left turn link");
            }
        }

        private bool VerticalDirection(SurfSegment seg)
        {
            var n = Vector3D.CrossProduct(this.GetDirection(), seg.GetDirection());
            var k = Vector3D.CrossProduct(this.GetDirection(), n);
            return k.Z < 0;
        }
    }
}
