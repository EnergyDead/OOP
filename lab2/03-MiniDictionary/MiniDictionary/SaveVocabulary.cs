using System.IO;
using System.Text;

namespace MiniDictionary
{
    public static class SaveVocabulary
    {
        public static bool SaveVocabularyToFile( string fileName, Vocabulary vocabulary )
        {
            if ( !File.Exists( fileName ) )
            {
                return false;
            }
            StringBuilder builder = new();
            foreach ( var item in vocabulary.GetVocabulary() )
            {
                builder.AppendLine( item.Key );
                builder.AppendLine( item.Value );
            }
            File.WriteAllText( fileName, builder.ToString() );

            return true;
        }
    }
}
