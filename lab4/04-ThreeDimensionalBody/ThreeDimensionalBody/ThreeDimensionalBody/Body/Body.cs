namespace ThreeDimensionalBody;

public abstract class Body
{
    public virtual double GetDensity()
    {
        throw new NotImplementedException();
    }
    public virtual double GetVolume()
    {
        throw new NotImplementedException();
    }
    public virtual double GetMass()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Плотность: {GetDensity()}, Обьем: {Math.Round( GetVolume(), 3 )}, Масса: {Math.Round( GetMass(), 3 )}";
    }

    protected List<Compound> Parent { get; set; } = new();
    protected void SetParent( Body body, Compound compound )
    {
        body.Parent.Add( compound );
    }
}
