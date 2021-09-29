using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalBody.figures
{
    public class Parallelepiped : Body
    {
        private double _width;
        private double _heigth;
        private double _depth;

        public Parallelepiped( double width, double height, double depth, double density )
        {
            SetWidth( width );
            SetDensity( density );
            SetDepth( depth );
            SetHeight( height );
            SetVolume();
            SetMass();
        }

        public double GetDepth()
        {
            return _depth;
        }

        public double GetHeigth()
        {
            return _heigth;
        }

        public double GetWidth()
        {
            return _width;
        }

        public override string ToString()
        {
            return $"Паралеллепипед\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        protected override void SetVolume()
        {
            _volume = GetWidth() * GetHeigth() * GetDepth();
        }

        private void SetHeight( double height )
        {
            _heigth = height;
        }

        private void SetWidth( double width )
        {
            _width = width;
        }

        private void SetDepth( double depth )
        {
            _depth = depth;
        }
    }
}
