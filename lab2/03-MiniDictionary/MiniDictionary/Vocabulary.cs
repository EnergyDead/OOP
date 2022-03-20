using System.Collections.Generic;

namespace MiniDictionary
{
    public class Vocabulary
    {
        private readonly Dictionary<string, string> _vocabulary;

        public Vocabulary()
        {
            _vocabulary = new Dictionary<string, string>();
        }

        public string GetTranslation( string word )
        {
            string translate = word.ToLower();

            return _vocabulary.ContainsKey( translate ) ? _vocabulary[ translate ] : string.Empty;
        }

        public Dictionary<string, string> GetVocabulary()
        {
            return _vocabulary;
        }

        public bool TryAddTranslation( string translate, string translation )
        {
            if ( !_vocabulary.ContainsKey( key: translate ) )
            {
                _vocabulary.Add( translate.ToLower(), value: translation );

                return true;
            }

            return false;
        }
    }
}
