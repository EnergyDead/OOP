using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MiniDictionary
{
    internal class Program
    {
        static Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        static string FileName = "default.txt";
        const string EndCommand = "...";
        const string SaveNewDictionary = "y";

        static void Main( string[] args )
        {
            if ( args.Length != 0 )
            {
                FileName = args[ 0 ];
            }
            if ( File.Exists( FileName ) )
            {
                ReadDictionary( FileName );
            }

            string word;
            bool stateChanged = false;
            while ( ( word = Console.ReadLine() ) != EndCommand )
            {
                List<string> translation = SearchTranslation( word.ToLower() );

                if ( translation.Count == 0 )
                {
                    Console.WriteLine( $"Неизвестное слово “{word}”. Введите перевод или пустую строку для отказа." );
                    var translate = Console.ReadLine();
                    if ( translate != string.Empty )
                    {
                        dictionary.Add( word, new List<string> { translate } );
                        stateChanged = true;
                        Console.WriteLine( $"Слово “{word}” сохранено в словаре как “{translate}”." );
                    }
                }
                else
                {
                    Console.WriteLine( word + " -> " + string.Join( ", ", translation ) );
                }
            }

            if ( stateChanged )
            {
                Console.WriteLine( "В словарь были внесены изменения. Введите Y или y для сохранения перед выходом." );
                if ( Console.ReadLine().ToLower() == SaveNewDictionary )
                {
                    SaveDictionary();
                }
            }
        }

        private static void ReadDictionary( string fileName )
        {
            var inputPair = File.ReadLines( fileName ).ToList();
            foreach ( var item in inputPair )
            {
                var words = item.Split( " " ).ToList();

                if ( words.Count < 1 )
                {
                    continue;
                }
                var word = words[ 0 ];
                words.RemoveAt( 0 );
                dictionary.Add( word, words );
            }
        }

        private static void SaveDictionary()
        {
            StringBuilder sb = new StringBuilder();
            foreach ( var item in dictionary )
            {
                sb.Append( item.Key );
                sb.Append( ' ' );
                sb.AppendJoin( " ", item.Value );
                sb.Append( '\n' );
            }
            File.WriteAllText( FileName, sb.ToString() );
        }

        private static List<string> SearchTranslation( string command )
        {
            return dictionary.ContainsKey( command ) ? dictionary[ command ] : new List<string>();
        }
    }
}
