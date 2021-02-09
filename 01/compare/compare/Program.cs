using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace compare
{
    class Program
    {
        static int Main(string[] args)
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
            List<String> firstFile = File.ReadAllLines( firstFileName ).ToList();
            List<String> secondFile = File.ReadAllLines( secondFileName ).ToList();
            int countLines = firstFile.Count;

            if ( countLines > secondFile.Count )
            {
                countLines = secondFile.Count;
            }

            for (int lineNum = 0; lineNum < countLines; lineNum++)
            {
                if (firstFile[lineNum] != secondFile[lineNum])
                {
                    Console.WriteLine($"Files are different. Line number is {lineNum + 1}");

                    return 1;
                }
            }

            if ( firstFile.Count != secondFile.Count )
            {
                Console.WriteLine($"Files are different. Line number is {countLines + 1}");

                return 1;
            }
            Console.WriteLine("Files are equal");

            return 0;
        }
    }
}