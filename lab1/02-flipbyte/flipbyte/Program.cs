using System;
using System.IO;

namespace flipbyte
{
    class Program
    {
        public static int Main( string[] args )
        {
            int number;
            try
            {
                number = IsCorrectArgument( args[ 0 ] );
            }
            catch ( Exception error )
            {
                Console.WriteLine( error.Message );

                return 1;
            }

            byte result = FlipByte( number );

            Console.WriteLine( result );
            
            if ( args.Length == 2 )
            {
                File.WriteAllText( args[ 1 ], result.ToString() );
            }

            return 0;
        }

        private static byte FlipByte( int number )
        {
            byte revert = (byte)number;
            byte result = 0;
            for ( int i = 0; i < 8; i++ )
            {
                result <<= 1;
                result |= (byte)( revert & 1 );
                revert >>= 1;
            }

            return result;
        }

        private static int IsCorrectArgument( string args )
        {
            int number = Convert.ToInt32( args );
            if ( ( 255 < number ) || ( number < 0 ) )
            {
                throw new Exception( "Argument is not in 0..255" );
            }

            return number;
        }
    }
}
