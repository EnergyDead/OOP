using System;
using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace workvector
{
    public class Program
    {
        public static List<string> errors = new List<string>();

        public static int Main( string[] args )
        {

            var input = Console.ReadLine().Trim();
            List<double> list = ReadList( input );

            if ( errors.Count != 0 )
            {
                Console.WriteLine( string.Join( "\n", errors ) );
                return 0;
            }

            MultiplicationListByMin( list );

            list.Sort();
            PrintList( list );

            return 0;
        }

        public static void PrintList( List<double> list )
        {
            Console.WriteLine( String.Join( " ", list ) );
        }

        public static void MultiplicationListByMin( List<double> list )
        {
            double min = list.Min();

            for ( int i = 0; i < list.Count; i++ )
            {
                list[ i ] = Math.Round( list[ i ] * min, 3 );
            }
        }

        public static List<double> ReadList( string input )
        {
            var result = new List<double>();
            if ( input == Empty )
            {
                return result;
            }

            var content = input.Split( " " );

            foreach ( var item in content )
            {
                if ( item == Empty )
                {
                    continue;
                }
                if ( double.TryParse( item, out double element ) )
                {
                    result.Add( element );
                }
                else
                {
                    errors.Add( $"Error argument. {item} is not float." );
                }
            }

            return result;
        }

    }
}
