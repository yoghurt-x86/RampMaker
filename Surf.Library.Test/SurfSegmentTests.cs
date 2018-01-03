using System;
using System.Windows.Media.Media3D;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Surf.Library.Test
{
    [TestClass]
    public class SurfSegmentTests
    {
        [TestMethod]
        public void LinkToVertical()
        {
            var point1 = new Point3D(0, 0, 0);
            var point2 = new Point3D(10.512311231231, 10.512311231231 / 2, 10.512311231231);
            var point3 = new Point3D(22.3123123, 22.3123123 / 2, 22.3123123);
            var segment1 = new SurfSegment(point1, point2, 10);
            var segment2 = new SurfSegment(point2, point3, 10);

            segment1.LinkTo(segment2);

            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LinkToVerticalDown()
        {
            var point1 = new Point3D(0, 0, 0);
            var point2 = new Point3D(10, 0, 0);
            var point3 = new Point3D(20, 0, -10);
            var segment1 = new SurfSegment(point1, point2, 10);
            var segment2 = new SurfSegment(point2, point3, 10);

            segment1.LinkTo(segment2);

            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LinkToVerticalUp()
        {
            var point1 = new Point3D(0, 0, 0);
            var point2 = new Point3D(10, 0, 0);
            var point3 = new Point3D(20, 0, 10);
            var segment1 = new SurfSegment(point1, point2, 10);
            var segment2 = new SurfSegment(point2, point3, 10);

            segment1.LinkTo(segment2);

            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LinkToHorizontal()
        {
            var point1 = new Point3D(0, 0, 0);
            var point2 = new Point3D(10.512311231231, 10.512311231231 / 2,0);
            var point3 = new Point3D(22.3123123, 22.3123123, 0);
            var segment1 = new SurfSegment(point1, point2, 10);
            var segment2 = new SurfSegment(point2, point3, 10);

            segment1.LinkTo(segment2);

            Assert.IsTrue(true);
        }
    }
}
