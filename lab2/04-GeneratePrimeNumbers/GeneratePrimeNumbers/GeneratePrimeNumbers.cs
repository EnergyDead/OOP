using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneratePrimeNumbers
{
    public static class GeneratePrimeNumbers
    {
        private const int MaxBound = 100000000; 
        public static HashSet<int> GeneratePrimeNumbersSet( int upperBound )
        {
            if ( upperBound < 2 || upperBound > MaxBound )
            {
                throw new ArgumentOutOfRangeException( $"Use a number between 2 and {MaxBound}." );
            }
            int max = (int)Math.Sqrt( upperBound ) + 1;
            var result = new HashSet<int>();

            var primes = Enumerable.Repeat( true, upperBound + 1 ).ToArray();
            for ( int i = 2; i <= max; i +=2 )
            {
                if ( primes[ i ] )
                {
                    for ( int j = i * 2; j < primes.Length; j += i )
                    {
                        primes[ j ] = false;
                    }
                } 
                if ( i == 2 ) i--;
            }
            for ( int i = 2; i < primes.Length; i++ )
            {
                if ( primes[ i ] )
                {
                    result.Add( i );
                }
            }

            return result;
        }
    }
}
