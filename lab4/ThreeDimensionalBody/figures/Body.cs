using System;

namespace ThreeDimensionalBody.figures
{
    public class Body
    {
        protected double _density;

        public virtual double GetDensity()
        {
            throw new NotImplementedException();
        }

        public virtual double GetVolume()
        {
            throw new NotImplementedException();
        }

        public virtual double GetMass()
        {
            throw new NotImplementedException();
        }


    }
}
