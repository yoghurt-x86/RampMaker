using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Surf.Library
{
    public class Bezier3D
    {
        private Point3D p0;
        private Point3D p1;
        private Point3D p2;
        private Point3D p3;

        public Bezier3D(Point3D p0, Point3D p1, Point3D p2, Point3D p3)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public void Translate(Vector3D vector)
        {
            p0 += vector;
            p1 += vector;
            p2 += vector;
            p3 += vector;
        }

        public IEnumerable<Point3D> GetPoints(int segments)
        {
            var points = new Point3D[segments+1];
            points[0] = p0;
            points[segments] = p3;

            double t = 0;
            for (int i = 1; i < segments; i++)
            {
                t += (1d / segments);
                points[i] = GetPointAtTime(t);
            }

            return points;
        }

        public Point3D GetPointAtTime(double t)
        {
            double u = 1d - t;
            double tt = t * t;
            double uu = u * u;
            double uuu = uu * u;
            double ttt = tt * t;

            Point3D p = new Point3D(uuu * p0.X, uuu * p0.Y, uuu * p0.Z);
            p.X += (3 * uu * t * p1.X) + (3 * u * tt * p2.X) + (ttt * p3.X);
            p.Y += (3 * uu * t * p1.Y) + (3 * u * tt * p2.Y) + (ttt * p3.Y);
            p.Z += (3 * uu * t * p1.Z) + (3 * u * tt * p2.Z) + (ttt * p3.Z);
            //Point3D p = uuu * p0; //first term
            //p += 3 * uu * t * p1; //second term
            //p += 3 * u * tt * p2; //third term
            //p += ttt * p3; //fourth term

            return p;
        }
    }
}
