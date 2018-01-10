using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Surf.Library
{
    public class SurfRamp : List<SurfSegment>
    {
        public SurfRamp() : base() { }
        public DiffuseMaterial Material = new DiffuseMaterial { Brush = Brushes.Gray };

        public SurfRamp(Bezier3D bezier, int segments, double height) : base()
        {
            var points = bezier.GetPoints(segments).ToArray();
            SurfSegment[] ramps = new SurfSegment[points.Length - 1];
            for (int i = 1; i < points.Length; i++)
            {
                ramps[i - 1] = new SurfSegment(points[i - 1], points[i], height);
            }
            foreach (var ramp in ramps) try { this.AddSegment(ramp); } catch (ArgumentException) { }
        }

        public Model3DCollection GetModel3D()
        {
            var Model = new Model3DCollection();
            
            foreach (var seg in this) Model.Add(new GeometryModel3D { Geometry = seg.Model, Material = Material });
            return Model;
        }

        public void LinkTo(SurfRamp ramp)
        {
            this.Last().LinkTo(ramp.First());
        }

        public void AddSegment(SurfSegment segment)
        {
            if(this.Count > 0) this.Last().LinkTo(segment);
            this.Add(segment);
        }
    }
}
