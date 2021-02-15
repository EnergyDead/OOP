using System;
using System.Collections.Generic;
using System.IO;

namespace findtext
{
    class Program
    {
        static int Main(string[] args)
        {
            if ( args.Length < 1 )
            {
                Console.WriteLine( "Invalid arguments count" );
                Console.WriteLine( "Uasge: copyfile.exe <input file name> <text to search>" );

                return 1;
            }

            //Get path to file
            string searchFilePath = GetPathToFile( args[0] );
            string textToSearch = string.Empty;
            if ( args.Length == 2 )
            {
                textToSearch = args[1];
            }

            //Read file to string
            List<string> fileContent = new List<string>();
            try
            {
                fileContent = ReadFile( searchFilePath );
            } 
            catch (Exception error)
            {
                Console.WriteLine( error.Message );

                return 1;
            }

            //Checking if the file contains a string
            if ( !string.Join( "\n", fileContent ).Contains( textToSearch ) ) 
            { 
                Console.WriteLine( "Text not found" );

                return 1;
            }

            //Output lines containing srearch string
            //StreamWriter tempFile = new StreamWriter ( args[3] );
            for ( int lineNum = 0; lineNum < fileContent.Count; lineNum++ )
            {                
                if ( fileContent[lineNum].Contains(textToSearch) )
                {
                    Console.WriteLine(lineNum + 1);
                    //tempFile.Write(lineNum + 1);
                }
            }
            
            return 0;
        }

        private static string GetPathToFile( string fileName )
        {
            string pathToWorkDirectory = Directory.GetCurrentDirectory();
            string pathToProgram = Directory.GetParent( pathToWorkDirectory ).Parent.Parent.FullName;

            return Path.Combine( pathToProgram, fileName );
        }

        private static List<string> ReadFile( string searchFilePath )
        {
            using ( StreamReader file = new StreamReader(searchFilePath) )
            {
                List<string> fileContent = new List<string>();
                while ( file.Peek() >= 0 )
                {
                    fileContent.Add(file.ReadLine());
                }

                return fileContent;
            }
        }
    }
}
