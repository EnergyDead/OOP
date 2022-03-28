namespace Calculator
{
    public class Function : Argument
    {
        private List<Argument> _variables;
        private Operation _operation;
        public Function( string name, Variable variable ) : base( name )
        {
            _variables = new List<Argument>() { variable };
        }
        public Function( string name, (Argument, Argument) variables, Operation operation ) : base( name )
        {
            _operation = operation;
            _variables = new List<Argument>() { variables.Item1, variables.Item2 };
        }

        public override double? GetValue()
        {
            double? result = null;
            if ( _variables.Count == 1 )
            {
                return _variables.First().GetValue();
            }
            else if ( _variables.Count == 2 )
            {
                if ( _variables[ 0 ].GetValue().HasValue && _variables[ 1 ].GetValue().HasValue )
                {
                    if ( _operation == Operation.Plus )
                    {
                        result = _variables[ 0 ].GetValue() + _variables[ 1 ].GetValue();
                    }
                    else if ( _operation == Operation.Minus )
                    {
                        result = _variables[ 0 ].GetValue() - _variables[ 1 ].GetValue();
                    }
                    else if ( _operation == Operation.Divide )
                    {
                        result = _variables[ 0 ].GetValue() / _variables[ 1 ].GetValue();
                    }
                    else if ( _operation == Operation.Multiply )
                    {
                        result = _variables[ 0 ].GetValue() * _variables[ 1 ].GetValue();
                    }
                }
            }
            if ( result.HasValue )
            {
                return Math.Round( result.Value, 2 );
            }
            return null;
        }

        public override string ToString()
        {
            if ( GetValue() == null )
            {
                return "null";
            }
            return GetValue().Value.ToString();
        }
    }
}
