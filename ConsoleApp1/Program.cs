
using Surf.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var point1 = new Point3D(0, 0, 0);
            var point2 = new Point3D(10, 0, 0);
            var point3 = new Point3D(20, 10, 0);
            var point4 = new Point3D(20, 20, 0);

            var bez = new Bezier3D(point1, point2, point3, point4);
            foreach (var point in bez.GetPoints(6))
            {
                Console.WriteLine(point);
            }
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
