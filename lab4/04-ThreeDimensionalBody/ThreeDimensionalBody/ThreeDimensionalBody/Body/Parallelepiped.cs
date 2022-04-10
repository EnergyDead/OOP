namespace ThreeDimensionalBody;

public class Parallelepiped : SolidBody
{
    // todo: readonly
    public double Width { get; private set; }
    public double Heigth { get; private set; }
    public double Depth { get; private set; }
    public Parallelepiped( double width, double heigth, double depth, double density ) : base( density )
    {
        if ( width < 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( width ) );
        }
        if ( heigth < 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( heigth ) );
        }
        if ( depth < 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( depth ) );
        }
        Width = width;
        Heigth = heigth;
        Depth = depth;
    }
    public override double GetVolume()
    {
        return Math.Round( VolumeFormula(), 3 );
    }

    private double VolumeFormula()
    {
        return Width * Heigth * Depth;
    }

    public override string ToString()
    {
        return $"Параллелепипед. Ширина: {Width}, Высота: {Heigth}, Глубина: {Depth}, {base.ToString()}";
    }
}
