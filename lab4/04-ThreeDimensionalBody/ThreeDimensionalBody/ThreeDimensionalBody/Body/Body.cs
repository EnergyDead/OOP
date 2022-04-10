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
        return $"Плотность: {GetDensity()}, Обьем: {GetVolume()}, Масса: {GetMass()}";
    }

    protected Compound? Parent { get; set; } = null;
    protected virtual void SetRerent( Body body, Compound compound )
    {
        body.Parent = compound;
    }
}
