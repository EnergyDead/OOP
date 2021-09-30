using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalBody.figures
{
    public class Body
    {
        protected double _density;
        protected double _volume;

        public virtual double GetDensity()
        {
            throw new NotImplementedException();
        }

        public virtual double GetVolume()
        {
            return _volume;
        }
        public virtual double GetMass()
        {
            throw new NotImplementedException();
        }

        protected virtual void SetVolume()
        {
            throw new NotImplementedException();
        }
    }
}
