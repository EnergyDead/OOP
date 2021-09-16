using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraSpaces;

namespace RemoveExtraSpacesTests
{
    [TestClass]
    public class RemoveExtraSpacesTest
    {
        [TestMethod]
        public void RemoveExtraSpaces_Correct_Test()
        {
            // Arrange
            string output = "lasd a a          aldkla          al ladl alla a ";

            // Act
            string result = Program.RemoveExtraSpaces( output );

            // Assert
            Equals("lasd a a aldkla al ladl alla a ", result);
        }
    }
}
