using System;

namespace ThreeDimensionalBody.figures
{
    public class Cylinder : Body
    {
        private double _height;
        private double _radius;

        public Cylinder( double height, double radius, double density )
        {
            SetRadius( radius );
            SetDensity( density );
            SetHeight( height );
            SetVolume();
            SetMass();
        }

        public double GetBaseRadius()
        {
            return _radius;
        }

        public double GetHeight()
        {
            return _height;
        }

        public override string ToString()
        {
            return $"Цилиндр\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        protected override void SetVolume()
        {
            _volume = Math.PI * Math.Pow( GetBaseRadius(), 2 ) * GetHeight();
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
