using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalBody.figures
{
    public class Body
    {
        protected double _density;
        protected double _mass;
        protected double _volume;

        public double GetDensity()
        {
            return _density;
        }

        public double GetVolume()
        {
            return _volume;
        }

        public override string ToString()
        {
            return $"Пустое тело\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        protected void SetDensity( double value )
        {
            _density = value;
        }

        protected virtual void SetVolume() { }

        public double GetMass()
        {
            return _mass;
        }

        protected virtual void SetMass()
        {
            _mass = GetVolume() * GetDensity();
        }
    }
}
