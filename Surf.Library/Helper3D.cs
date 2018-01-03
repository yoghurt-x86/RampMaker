using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Surf.Library
{
    public static class Helper3D
    {
        public static double MAX_DIF_ALLOWED = Double.Epsilon;

        public static Vector3D VectorToPoint(this Point3D start, Point3D end)
        {
            return new Vector3D(end.X - start.X, end.Y - start.Y, end.Z - start.Z);
        }
        public static Vector3D Scale(this Vector3D vector, double scaleAmount)
        {
            vector.X *= scaleAmount;
            vector.Y *= scaleAmount;
            vector.Z *= scaleAmount;
            return vector;
        }
        public static bool ApproximateEquals(this double a, double b)
        {
            return (Math.Abs(a - b) < MAX_DIF_ALLOWED);
        }

        public static Vector3D ProjectedOn(this Vector3D a, Vector3D n)
        {
            var Multiply = Vector3D.DotProduct(a, n) / Math.Pow(n.Length, 2);
            return new Vector3D(n.X * Multiply, n.Y * Multiply, n.Z * Multiply );
        }

    }
}
