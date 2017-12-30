using Surf;
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
            var ramp = new SurfRamp();
            Console.Write(ramp.Model.Positions);
            Console.ReadLine();
            ramp = new SurfRamp(new Point3D(0,0,0), new Point3D(1,0,0), new Point3D(0,-5,0));
            Console.Write(ramp.Model.Positions);
            Console.ReadLine();
        }
    }
}
