using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ObsceneWordFilter
{
    class Program
    {
        static readonly string filterFileName = "..\\..\\..\\filter.txt";

        static void Main( string[] args )
        {
            string checkLine = Console.ReadLine();
            string result = ObsceneWordFilter( checkLine );
            
            Console.WriteLine( result );
        }

        public static List<string> SplitString( string input )
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " ", "    " };

            return input.ToLower().Split( separators, StringSplitOptions.RemoveEmptyEntries ).ToList();
        }

        public static string ObsceneWordFilter( string checkLine )
        {
            string filterWord = String.Join( " ", File.ReadAllLines( filterFileName ) );
            List<string> obsceneWord = SplitString( filterWord );
            obsceneWord.ForEach( word => checkLine = checkLine.Replace( word, "****" ) );

            return checkLine;
        }
    }
}
