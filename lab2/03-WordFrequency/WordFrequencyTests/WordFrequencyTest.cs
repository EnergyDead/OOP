using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequency;

namespace WordFrequencyTests
{
    [TestClass]
    public class WordFrequencyTest
    {
        [TestMethod]
        public void SplitString_Correct_Test()
        {
            // Arrange
            string output = "lasd a a ; asd;asd; f;         aldkla          al ladl alla a ";

            // Act
            List<string> result = Program.SplitString( output );

            // Assert
            Equals( "lasd", result[ 0 ] );
            Equals( "a", result[ 1 ] );
            Equals( "a", result[ 2 ] );
            Equals( "asd", result[ 3 ] );
        }
    }
}
