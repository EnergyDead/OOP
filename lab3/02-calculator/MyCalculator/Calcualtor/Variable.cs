namespace Calculator
{
    public class Variable : Argument
    {
        private double? _value;

        // var
        public Variable( string name ) : base( name ) { }

        // let
        public Variable( string name, double? value ) : base( name )
        {
            _value = value;
        }

        public override double? GetValue()
        {
            return _value;
        }

        public override void SetValue( double? v )
        {
            _value = v;
        }


        public static double? operator +( Variable var1, Variable var2 )
        {
            return var1._value + var2._value;
        }
        public static double? operator -( Variable var1, Variable var2 )
        {
            return var1._value - var2._value;
        }
        public static double? operator /( Variable var1, Variable var2 )
        {
            return var1._value / var2._value;
        }
        public static double? operator *( Variable var1, Variable var2 )
        {
            return var1._value * var2._value;
        }

        public override string ToString()
        {
            if ( _value == null )
            {
                return "null";
            }
            return Math.Round( _value.Value, 2 ).ToString();
        }
    }
}
