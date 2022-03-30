namespace ThreeDimensionalBody
{
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
    }
}
