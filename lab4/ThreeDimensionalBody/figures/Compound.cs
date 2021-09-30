using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
