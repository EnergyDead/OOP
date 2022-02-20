using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace bmpinfo
{
    internal class Program
    {
        static void Main( string[] args )
        {
            int upperLimit = 100000000;
           int result = 0;

            // Create a boolean array
            // "prime[0..n]" and
            // initialize all entries
            // it as true. A value in
            // prime[i] will finally be
            // false if i is Not a
            // prime, else true.

            bool[] prime = new bool[ upperLimit + 1 ];

            for ( int i = 0; i <= upperLimit; i++ )
                prime[ i ] = true;

            for ( int p = 2; p * p <= upperLimit; p++ )
            {
                // If prime[p] is not changed,
                // then it is a prime
                if ( prime[ p ] == true )
                {
                    // Update all multiples of p
                    for ( int i = p * p; i <= upperLimit; i += p )
                        prime[ i ] = false;
                }
            }

            // Print all prime numbers
            for ( int i = 2; i <= upperLimit; i++ )
            {
                if ( prime[ i ] == true )
                    result++;
            }

            Console.WriteLine( result );
        }

        static string GetPath( string fileName )
        {
            string pathToWorkDirectory = Directory.GetCurrentDirectory();
            string pathToProgram = Directory.GetParent( pathToWorkDirectory ).Parent.Parent.FullName;

            return Path.Combine( pathToProgram, fileName );
        }
    }
}
