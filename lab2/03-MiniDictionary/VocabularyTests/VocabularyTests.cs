using MiniDictionary;
using Xunit;

namespace VocabularyTests
{
    public class VocabularyTests
    {
        [Fact]
        public void GetTranslation_EmptyVocabulary_ReturnEmpty()
        {
            Vocabulary vocabulary = new();
            string word = "car";

            string result = vocabulary.GetTranslation( word );

            Assert.Empty( result );
        }

        [Fact]
        public void AddTranslation_CorrectValue_ReturnTrue()
        {
            Vocabulary vocabulary = new();
            string word = "car";
            string translation = "кот";
            Assert.Empty( vocabulary.GetTranslation( word ) );

            bool result = vocabulary.TryAddTranslation( word, translation );

            Assert.True( result );
            Assert.Equal( translation, vocabulary.GetTranslation( word ) );
        }

        [Fact]
        public void GetTranslate_ReturnCorrect()
        {
            Vocabulary vocabulary = new();
            string word = "car";
            string translation = "кот, кошка";
            Assert.Empty( vocabulary.GetTranslation( word ) );

            bool result = vocabulary.TryAddTranslation( word, translation );

            Assert.True( result );
            Assert.Equal( translation, vocabulary.GetTranslation( word ) );
        }

        [Fact]
        public void GetTranslate_LoverCaseInput_ReturnCorrect()
        {
            Vocabulary vocabulary = new();
            string word = "cat";
            string translate = "caT";
            string translation = "кот, кошка";
            Assert.Empty( vocabulary.GetTranslation( word ) );

            bool result = vocabulary.TryAddTranslation( word, translation );

            Assert.True( result );
            Assert.Equal( translation, vocabulary.GetTranslation( translate ) );
        }
    }
}
