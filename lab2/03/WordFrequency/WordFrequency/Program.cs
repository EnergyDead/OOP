using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFrequency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> map = SplitString( input );
            Dictionary<string, int> dictionary = WordFrequency( map );
            WriteMap( dictionary );
        }

        public static List<string> SplitString( string input )
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " ", "    " };

            return input.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static Dictionary<string, int> WordFrequency( List<string> input )
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach ( string item in input )
            {
                if ( !dictionary.TryAdd(item, 1) )
                {
                    dictionary[ item ] += 1;
                }
            }

            return dictionary;
        }

        public static void WriteMap( Dictionary<string, int> dictionary )
        {
            foreach ( var item in dictionary ) 
            {
                Console.WriteLine( "{0} - {1}", item.Key, item.Value );
            }
        }
    }
}
