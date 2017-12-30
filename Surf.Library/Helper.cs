using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Surf.Library
{
    public static class Helper
    {
        public static Vector3D VectorToPoint(this Point3D start, Point3D end)
        {
            return new Vector3D(end.X - start.X, end.Y - start.Y, end.Z - start.Z);
        }
    }
}
