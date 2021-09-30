using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalBody.figures
{
    public class SolidBody : Body
    {
        public SolidBody( double density )
        {
            if (density >= 0)
                SetDensity( density );
        }

        public override double GetDensity()
        {
            return _density;
        }

        public override double GetMass()
        {
            return GetVolume() * GetDensity();
        }

        public override string ToString()
        {
            return $"Пустое тело\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        protected void SetDensity( double value )
        {
            _density = value;
        }
    }
}
