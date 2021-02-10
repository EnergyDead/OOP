using System;
using System.IO;

namespace compare
{
    class Program
    {
        static int Main( string[] args )
        {
            if ( args.Length != 2 ) 
            {
                return 1;
            }

            if (args[0] == args[1])
            {
                Console.WriteLine( "Files are equal" );

                return 0;
            }

            string firstFileName = args[0] + ".txt";
            string secondFileName = args[1] + ".txt";
            string[] firstFile = File.ReadAllLines( firstFileName );
            string[] secondFile = File.ReadAllLines( secondFileName );
            int countLines = firstFile.Length;

            if ( countLines > secondFile.Length )
            {
                countLines = secondFile.Length;
            }

            for ( int lineNum = 0; lineNum < countLines; lineNum++ ) 
            {
                if ( firstFile[lineNum] != secondFile[lineNum] ) 
                {
                    Console.WriteLine($"Files are different. Line number is {lineNum + 1}");

                    return 1;
                }
            }

            if ( firstFile.Length != secondFile.Length )
            {
                Console.WriteLine($"Files are different. Line number is {countLines + 1}");

                return 1;
            }

            Console.WriteLine("Files are equal");

            return 0;
        }
    }
}