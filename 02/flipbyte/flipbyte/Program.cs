using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace flipbyte
{
    class Program
    {
        static int Main( string[] args )
        {
            int number;
            try
            {
                number = IsCorrectArgument( args[0] );
            } 
            catch ( Exception error )
            {
                Console.WriteLine( error.Message );

                return 1;
            }

            byte[] bytArray = BitConverter.GetBytes( number );
            BitArray bit = new BitArray( bytArray );
            int[] result = new int[1];
            ReversBit( bit );
            bit.CopyTo( result, 0 );

            Console.WriteLine( result[0] );
            File.WriteAllText( args[1], result[0].ToString() );

            return 0;
        }

        static int IsCorrectArgument( string args )
        {
            int number = Convert.ToInt32( args );
            if ( ( 255 < number ) || ( number < 0 )  ) 
            {
                throw new Exception( "Argument is not in 0..255" );
            }

            return number;
        }

        static BitArray ReversBit( BitArray number )
        {
            bool[] tempArray = new bool[8];
            for ( int i = 0; i < 8; i++)
            {
                tempArray[i] = number[i];
            }
            Array.Reverse(tempArray);
            for (int i = 0; i < 8; i++)
            {
                number[i] = tempArray[i];
            }

            return number;
        }
    }
}
