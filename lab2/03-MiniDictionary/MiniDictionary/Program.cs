using System;
using System.IO;

namespace MiniDictionary
{
    public class Program
    {
        const string EndCommand = "...";
        const string SaveCommand = "y";

        static void Main( string[] args )
        {
            Vocabulary vocabulary = new();
            string fileName = string.Empty;

            if ( args.Length != 0 )
            {
                fileName = args[ 0 ];
                if ( !TryReadVocabulary( fileName, vocabulary ) )
                {
                    Console.WriteLine( "Не удалось считать файл. Инициализирован пустой словарь." );
                }
            }

            string word;
            bool hasChanged = false;
            while ( ( word = Console.ReadLine() ) != EndCommand )
            {
                string translation = vocabulary.GetTranslation( word );
                if ( translation == string.Empty )
                {
                    Console.WriteLine( $"Неизвестное слово “{word}”. Введите перевод или пустую строку для отказа." );
                    var translate = Console.ReadLine();
                    if ( translate != string.Empty )
                    {
                        if ( vocabulary.TryAddTranslation( word, translate ) )
                        {
                            hasChanged = true;
                            Console.WriteLine( $"Слово “{word}” сохранено в словаре как “{translate}”." );
                        }
                    }
                    else
                    {
                        Console.WriteLine( $"Слово “{word}” было проигнорированно." );
                    }
                }
                else
                {
                    Console.WriteLine( word + " -> " + translation );
                }
            }

            if ( hasChanged )
            {
                TrySaveVocabulary( fileName, vocabulary );
            }
        }

        private static void TrySaveVocabulary( string fileName, Vocabulary vocabulary )
        {
            Console.WriteLine( "В словарь были внесены изменения. Введите Y или y для сохранения перед выходом." );
            if ( Console.ReadLine().ToLower() != SaveCommand )
            {
                return;
            }

            if ( fileName == string.Empty )
            {
                Console.WriteLine( "Введите название сохраняемого словаря." );
                fileName = Console.ReadLine();
            }
            if ( !SaveVocabulary.SaveVocabularyToFile( fileName, vocabulary ) )
            {
                Console.WriteLine( "Ошика при сохранении." );
            }
        }

        private static bool TryReadVocabulary( string fileName, Vocabulary vocabulary )
        {
            if ( File.Exists( fileName ) )
            {
                return false;
            }

            var inputContent = File.ReadAllLines( fileName );
            for ( int i = 0; i < inputContent.Length; i += 2 )
            {
                vocabulary.TryAddTranslation( inputContent[ i ], inputContent[ i + 1 ] );
            }

            return true;
        }
    }
}
