namespace ThreeDimensionalBody.figures
{
    public class Parallelepiped : SolidBody
    {
        private double _width;
        private double _heigth;
        private double _depth;

        public Parallelepiped( double width, double height, double depth, double density ) : base( density )
        {
            SetWidth( width );
            SetDepth( depth );
            SetHeight( height );
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

        public override double GetVolume()
        {
            return GetWidth() * GetHeigth() * GetDepth();
        }

        public override string ToString()
        {
            return $"Паралеллепипед\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
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
