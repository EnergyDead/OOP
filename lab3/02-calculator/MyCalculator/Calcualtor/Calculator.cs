using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        // todo: использовать Словарь<Name, Symbol>
        private static List<Argument> _args;

        public Calculator()
        {
            _args = new List<Argument>();
        }

        public bool CreateOrChangeArgument( string value )
        {
            string[] args = value.Split( " " );
            if ( args.Length == 0 )
            {
                return false;
            }

            switch ( args[ 0 ] )
            {
                case "var":
                    if ( args.Length == 2 )
                    {
                        return CreateVar( args[ 1 ] );
                    }
                    return false;
                case "let":
                    if ( args[ 1 ].Contains( '=' ) )
                    {
                        return CreateLet( args[ 1 ] );
                    }
                    else if ( args.Length == 2 )
                    {
                        return CreateVar( args[ 1 ] );
                    }
                    break;
                case "fn":
                    if ( args[ 1 ].Contains( '=' ) )
                    {
                        return CreateFn( args[ 1 ] );
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }

        public string Print( string command )
        {
            var args = command.Split( ' ' );
            if ( args.Length != 2 )
            {
                return "Неверная комманда.";
            }
            var name = args[ 1 ];
            if ( HasArgName( name ) )
            {
                return _args.First( arg => arg.Name == name ).ToString();
            }
            return "Неизвестная перемерная";
        }

        public string PrintFns()
        {
            StringBuilder stringBuilder = new();
            foreach ( var arg in _args )
            {
                if ( arg is Function )
                {
                    stringBuilder.AppendLine( $"{arg.Name}:{arg.ToString()}" );
                }
            }
            return stringBuilder.ToString();
        }

        public string PrintVars()
        {
            StringBuilder stringBuilder = new();
            foreach ( var arg in _args )
            {
                if ( arg is Variable )
                {
                    stringBuilder.AppendLine( $"{arg.Name}:{arg.ToString()}" );
                }
            }
            return stringBuilder.ToString();
        }

        private static bool CreateFn( string command )
        {
            // todo: использовать правильную токенизацию
            var args = command.Split( '=' );
            if ( args.Length != 2 )
            {
                return false;
            }
            var fnName = args[ 0 ];
            var argFunc = args[ 1 ];
            if ( HasArgName( fnName ) )
            {
                return false;
            }
            if ( HasArgName( argFunc ) )
            {
                _args.Add( new Function( fnName, (Variable)_args.First( argument => argument.Name == argFunc ) ) );
                return true;
            }
            if ( argFunc.Contains( (char)Operation.Plus ) )
            {
                return CreateFnWithOperation( args, Operation.Plus );
            }
            else if ( argFunc.Contains( (char)Operation.Minus ) )
            {
                return CreateFnWithOperation( args, Operation.Minus );
            }
            else if ( argFunc.Contains( (char)Operation.Divide ) )
            {
                return CreateFnWithOperation( args, Operation.Divide );
            }
            else if ( argFunc.Contains( (char)Operation.Multiply ) )
            {
                return CreateFnWithOperation( args, Operation.Multiply );
            }
            return false;
        }

        private static bool CreateFnWithOperation( string[] args, Operation operation )
        {
            var fnName = args[ 0 ];
            var argFunc = args[ 1 ].Split( (char)operation );
            if ( argFunc.Length != 2 )
            {
                return false;
            }

            var firstVariable = argFunc[ 0 ];
            var secondVariable = argFunc[ 1 ];
            if ( !HasArgName( firstVariable ) || !HasArgName( secondVariable ) )
            {
                return false;
            }
            var pairArgs = (_args.First( arg => arg.Name == firstVariable ),
                            _args.First( arg => arg.Name == secondVariable ));
            _args.Add( new Function( fnName, pairArgs, operation ) );

            return true;
        }

        private static bool CreateLet( string command )
        {
            var args = command.Split( '=' );
            if ( args.Length != 2 )
            {
                return false;
            }

            var letName = args[ 0 ];
            var letValue = args[ 1 ];

            // todo: если переменной нет то создать, обновлять всегда
            if ( HasArgName( letName ) )
            {
                return UpdateVariable( letName, letValue );
            }
            else
            {
                return CreateVariable( letName, letValue );
            }
        }

        private static bool CreateVariable( string letName, string letValue )
        {
            double? value = null;
            if ( HasArgName( letValue ) )
            {
                value = _args.First( argument => argument.Name == letValue ).GetValue();
                _args.Add( new Variable( letName, value ) );
                return true;
            }
            else if ( double.TryParse( letValue, out double argValue ) )
            {
                value = argValue;
                _args.Add( new Variable( letName, value ) );
                return true;
            }
            return false;
        }

        private static bool UpdateVariable( string name, string letValue )
        {
            double? value = null;
            if ( HasArgName( letValue ) )
            {
                value = _args.First( argument => argument.Name == letValue ).GetValue();
                _args.First( a => a.Name == name ).SetValue( value );
                return true;
            }
            if ( double.TryParse( letValue, out double argValue ) )
            {
                value = argValue;
                _args.First( a => a.Name == name ).SetValue( value );
                return true;
            }
            return false;
        }

        private static bool CreateVar( string name )
        {
            if ( name.Contains( '=' ) )
            {
                return false;
            }
            if ( HasArgName( name ) )
            {
                return false;
            }

            _args.Add( new Variable( name ) );
            return true;
        }

        private static bool HasArgName( string name )
        {
            return _args.Any( argument => argument.Name == name );
        }
    }
}
