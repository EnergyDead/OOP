namespace Calculator
{
    public interface ICalculator
    {
        public bool CreateOrChangeArgument( string value );
        public string Print( string name );
        public string PrintVars();
        public string PrintFns();

    }
}
