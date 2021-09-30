using System;

namespace ThreeDimensionalBody.figures
{
    public class Cone : SolidBody
    {
        private double _radius;
        private double _height;

        public Cone( double height, double radius, double density ) : base( density )
        {
            SetRadius( radius );
            SetHeight( height );
        }

        public double GetBaseRadius()
        {
            return _radius;
        }

        public double GetHeight()
        {
            return _height;
        }

        public override double GetVolume()
        {
            return Math.PI * Math.Pow( GetBaseRadius(), 2 ) * GetHeight() / 3;
        }

        public override string ToString()
        {
            return $"Конус\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        private void SetHeight( double height )
        {
            _height = height;
        }

        private void SetRadius( double value )
        {
            _radius = value;
        }
    }
}
