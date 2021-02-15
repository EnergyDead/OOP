using System;
using System.IO;

namespace copyfile
{
    class Program
    {
        static int Main( string[] args )
        {
            if ( args.Length != 2 )
            {
                Console.WriteLine( "Invalid arguments count" );
                Console.WriteLine( "Uasge: copyfile.exe <input file name> <output file name>" );

                return 1;
            }
            string pathToWorkDirectory = Directory.GetCurrentDirectory();
            string pathToProgram = Directory.GetParent( pathToWorkDirectory ).Parent.Parent.FullName;

            string inputFilePath = Path.Combine( pathToProgram, args[0] );
            string outputFilePath = Path.Combine( pathToProgram,  args[1] );

            if ( inputFilePath != outputFilePath )
            {
                try
                {
                    File.Copy(Path.Combine(inputFilePath), Path.Combine(outputFilePath), true);
                }
                catch ( Exception error )
                {
                    Console.WriteLine(error.Message);

                    return 1;
                }
            }

            return 0;
        }
    }
}
