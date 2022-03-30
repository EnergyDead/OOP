namespace ThreeDimensionalBody
{
    public class Sphere : SolidBody
    {
        public double Radius { get; private set; }

        public Sphere( double radius, double density ) : base( density )
        {
            if ( radius < 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( radius ) );
            }

            Radius = radius;
        }

        public override double GetVolume()
        {
            return Math.Round( VolumeFormula(), 3 );
        }

        private double VolumeFormula()
        {
            return ( 4.0 / 3 ) * Math.PI * Math.Pow( Radius, 3 );
        }
    }
}
