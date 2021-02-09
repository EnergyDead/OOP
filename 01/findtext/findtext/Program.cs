using System;
using System.IO;
using System.Linq;

namespace findtext
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                return 1;
            }
            
            string fileName = args[0] + ".txt";
            string textToSearch = args[ 1 ];
            string[] fileContent = File.ReadAllLines( fileName ).ToArray();

            if ( !string.Join( "\n", fileContent ).Contains( textToSearch ) ) 
            { 
                Console.WriteLine( "Text not found" );

                return 1;
            }

            for ( int lineNum = 0; lineNum < fileContent.Length; lineNum++ )
            {
                if ( fileContent[ lineNum ].Contains( textToSearch ) ) 
                {
                    Console.WriteLine( lineNum + 1 );
                }
            }
            
            return 0;
        }
    }
}
