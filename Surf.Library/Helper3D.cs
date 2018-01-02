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
        public static Vector3D ToVector(this Point3D point)
        {
            return new Vector3D(point.X, point.Y, point.Z);
        }

    }
}
