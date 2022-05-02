using System;
using System.Collections.Generic;
using System.Linq;

namespace workvector
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Trim();
            List<double> list = new List<double>();

            bool isCorrectParse = TryParseStringToListDouble( input, list );

            if ( !isCorrectParse )
            {
                Console.WriteLine( "Failed convert input array." );

                return;
            }

            MultiplicationListByMin( list );

            list.Sort();

            PrintList( list );
        }

        public static void MultiplicationListByMin( List<double> list )
        {
            if ( list.Count == 0 )
            {
                return;
            }

            double min = list.Min();

            for ( int i = 0; i < list.Count; i++ )
            {
                list[ i ] = Math.Round( list[ i ] * min, 3 );
            }
        }

        public static bool TryParseStringToListDouble( string input, List<double> list )
        {
            foreach ( var item in input.Split( " " ) )
            {
                if ( item == string.Empty )
                {
                    continue;
                }

                if ( !double.TryParse( item, out double digit ) )
                {
                    return false;
                }

                list.Add( digit );
            }
            return true;
        }

        private static void PrintList( List<double> list )
        {
            Console.WriteLine( String.Join( " ", list ) );
        }

    }
}
