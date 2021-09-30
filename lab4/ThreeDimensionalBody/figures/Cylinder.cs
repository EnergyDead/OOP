using System;

namespace ThreeDimensionalBody.figures
{
    public class Cylinder : SolidBody
    {
        private double _height;
        private double _radius;

        public Cylinder( double height, double radius, double density ) : base( density )
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
            return Math.PI * Math.Pow( GetBaseRadius(), 2 ) * GetHeight();
        }

        public override string ToString()
        {
            return $"Цилиндр\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        private void SetHeight( double height )
        {
            _height = height;
        }

        private void SetRadius( double radius )
        {
            _radius = radius;
        }
    }
}
