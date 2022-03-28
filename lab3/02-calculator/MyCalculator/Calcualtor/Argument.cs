namespace Calculator
{
    public abstract class Argument
    {
        public string Name { get; private set; }

        public Argument( string name )
        {
            Name = name;
        }

        public virtual double? GetValue()
        {
            return null;
        }

        public virtual void SetValue( double? v )
        {
            throw new NotImplementedException( "поменять значение." );
        }
    }
}