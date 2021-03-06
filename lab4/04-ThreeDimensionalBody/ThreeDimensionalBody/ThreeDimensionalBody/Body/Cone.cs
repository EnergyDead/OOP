namespace ThreeDimensionalBody;

public class Cone : SolidBody
{
    public double BaseRadius { get; private set; }
    public double Heigth { get; private set; }
    public Cone( double baseRadius, double heigth, double density ) : base( density )
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
        return VolumeFormula();
    }


    private double VolumeFormula()
    {
        return  ( Math.PI * Math.Pow( BaseRadius, 2 ) * Heigth ) / 3;
    }

    public override string ToString()
    {
        return $"Конус. Радиус: {BaseRadius}, Высота: {Heigth}, {base.ToString()}";
    }
}
