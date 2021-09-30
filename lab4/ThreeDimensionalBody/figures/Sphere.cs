using System;

namespace ThreeDimensionalBody.figures
{
    public class Sphere : SolidBody
    {
        private double _radius;
        public Sphere( double radius, double density ) : base( density )
        {
            SetRadius( radius );
        }

        public double GetRadius()
        {
            return _radius;
        }
        public override double GetVolume()
        {
            return 4 * Math.PI * Math.Pow( _radius, 3 ) / 3;
        }

        public override string ToString()
        {
            return $"Сфера\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        private void SetRadius( double value )
        {
            _radius = value;
        }
    }
}
