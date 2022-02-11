using System;
using System.IO;

namespace flipbyte
{
    class Program
    {
        public static int Main( string[] args )
        {
            if ( !int.TryParse( args[ 0 ], out int number ) )
            {
                Console.WriteLine( "Expected number atgument." );

                return 1;
            }
            if ( !NumberInRange( number ) )
            {
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

        private static bool NumberInRange( int number )
        {
            if ( ( 255 < number ) || ( number < 0 ) )
            {
                Console.WriteLine( "Argument is not in 0..255" );

                return false;
            }

            return true;
        }
    }
}
