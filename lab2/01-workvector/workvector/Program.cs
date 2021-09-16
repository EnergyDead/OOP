using System;
using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace workvector
{
    public class Program
    {
        public static int Main( string[] args )
        {
            if ( args.Length != 1 )
            {
                Console.WriteLine("Invalid args. Use workvector.exe <array float args>");

                return 1;
            }

            List<float> result = ReadList( args[ 0 ] );
            result = SplitElementsByMax( result );
            WriteList( result );

            return 0;
        }

        public static List<float> ReadList( string arg )
        {
            return arg.Split( ' ' ).Select( float.Parse ).ToList();
        }

        public static List<float> SplitElementsByMax( List<float> args )
        {
            return args.Select( arg => arg / ( CheckMaxArg( args ) / 2 ) ).ToList();
        } 

        public static float CheckMaxArg( List<float> args )
        {
            float max = 0;
            foreach ( float arg in args )
            {
                if ( arg > max ) 
                {
                    max = arg;
                }
            }

            return max;
        }

        public static void WriteList( List<float> args )
        {
            List<string> result = args.OrderBy( arg => arg ).Select( arg => arg.ToString( "0.000" ) ).ToList();
            Console.WriteLine( Join( " ", result ) );
        }
    }
}
