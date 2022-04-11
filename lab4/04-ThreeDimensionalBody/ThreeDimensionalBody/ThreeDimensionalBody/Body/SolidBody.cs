namespace ThreeDimensionalBody;

public class SolidBody : Body
{
    private readonly double _density;
    public SolidBody( double density )
    {
        if ( density < 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( density ) );
        }

        _density = density;
    }

    public override double GetDensity()
    {
        return _density;
    }

    public override double GetMass()
    {
        return  _density * GetVolume();
    }
}
