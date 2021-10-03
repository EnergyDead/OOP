using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeDimensionalBody.figures
{
    public class Compound : Body
    {
        private List<Body> _bodies = new List<Body>();
        public Compound()
        {
        }

        public bool AddChildBody( Body body )
        {
            _bodies.Add( body );

            return true;
        }

        public override double GetDensity()
        {
            return _bodies.Select( b => b.GetDensity() ).Sum() / _bodies.Count;
        }

        public override double GetMass()
        {
            return _bodies.Select( b => b.GetMass() ).Sum();
        }

        public override double GetVolume()
        {
            return _bodies.Select( b => b.GetVolume() ).Sum();
        }

        public override string ToString()
        {
            return $"Составное тело включающее {_bodies.Count} элементов.\n{String.Join( "\n", _bodies.Select( b => b.ToString() ) )}";
        }
    }
}
