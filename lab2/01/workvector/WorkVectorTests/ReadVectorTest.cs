using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using workvector;

namespace WorkVectorTests
{
    [TestClass]
    public class ReadVectorTest
    {
        [TestMethod]
        public void Main_Correct_Test()
        {
            // Arrange
            string[] output = {"1.00 50 3.22 4.1231 5 6 7 8 9 10",};
            // Act

            int result = Program.Main( output );

            // Assert
            Equals(0, result);
        }

        [TestMethod]
        public void ReadList_Correct_Test()
        {
            // Arrange
            string output = "1.00 2.32 3.22 4.1231 5 6 7 8 9 10";
            
            // Act
            List<float> result = Program.ReadList( output );

            // Assert
            Equals( 10, result.Count );
            Equals( 1.00, result[ 0 ] );
            Equals( 2.32, result[ 1 ] );
            Equals( 3.22, result[ 2 ] );
            Equals( 4.1231, result[ 3 ] );
            Equals( 5, result[ 4 ] );
            Equals( 6, result[ 5 ] );
        }

        [TestMethod]
        public void SplitElementsByMax_Correct_Test()
        {
            // Arrange
            List<float> output = new List<float> {10, 10, 20, 10, 20};

            // Act
            List<float> result = Program.SplitElementsByMax( output );

            // Assert
            Equals( 10, result[ 0 ] );
            Equals( 10, result[ 1 ] );
            Equals( 20, result[ 2 ] );
            Equals( 10, result[ 3 ] );
            Equals( 20, result[ 4 ] );
        }

        [TestMethod]
        public void CheckMaxArg_Correct_Test()
        {
            // Arrange
            List<float> output = new List<float> { 10, 10,123, 20, 10, (float) 20.00 };

            // Act
            float result = Program.CheckMaxArg( output );

            // Assert
            Equals( 20.11, result );
        }

        [TestMethod]
        public void WriteList_Check_Correct()
        {

        }
    }
}
