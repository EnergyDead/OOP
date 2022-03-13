using System;
using System.Collections.Generic;

namespace GeneratePrimeNumbers
{
    public class Program
    {
        static void Main()
        {
            if ( !int.TryParse( Console.ReadLine(), out int number ) )
            {
                Console.WriteLine( "Error convert input lint to number. Please write integer." );
                return;
            }

            HashSet<int> result;
            try
            {
                result = GeneratePrimeNumbers.GeneratePrimeNumbersSet( number );
            }
            catch ( Exception error )
            {
                Console.WriteLine( error.Message );
                return;
            }

            Console.WriteLine( string.Join( ", ", result ) );
        }
    }
}
