namespace ThreeDimensionalBody;

public class Cylinder : SolidBody
{
    public double BaseRadius { get; private set; }
    public double Heigth { get; private set; }
    public Cylinder( double baseRadius, double heigth, double density ) : base( density )
    {
        if ( baseRadius < 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( baseRadius ) );
        }
        if ( heigth < 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( heigth ) );
        }
        BaseRadius = baseRadius;
        Heigth = heigth;
    }

    public override double GetVolume()
    {
        return Math.Round( VolumeFormula(), 3 );
    }


    private double VolumeFormula()
    {
        return Math.PI * Math.Pow( BaseRadius, 2 ) * Heigth;
    }

    public override string ToString()
    {
        return $"Цилиндор. Радиус: {BaseRadius}, Высота: {Heigth}, {base.ToString()}";
    }
}
