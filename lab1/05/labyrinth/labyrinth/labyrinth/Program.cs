using System;
using System.IO;

namespace labyrinth
{
    class Program
    {
        static int Main( string[] args )
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine( "Incorrect input args. Use: labyrinth.exe <input file> <output file>" );

                return 1;
            }

            string inputDate = File.ReadAllText( args[ 0 ] );



            Console.WriteLine( "faile" );

            return 0;
        }
    }
}
