using System.Collections.Generic;
using workvector;
using Xunit;

namespace WorkVectorTests
{
    public class List
    {
        [Fact]
        public void ReadList_CorrectInputElements_CorrectListElements()
        {
            //Arrange
            string inputValue = "1 2 3 4 -1 4, ,2 2,2";

            //Act
            var result = Program.ReadList( inputValue );
            var errors = Program.errors;

            //Assert
            Assert.NotNull( result );
            Assert.Empty( errors );
            Assert.Equal( 8, result.Count );
        }

        [Fact]
        public void ReadList_IncorrectInputElements_ErrorrMessage()
        {
            //Arrange
            string inputValue = "1 2 3 4 -1 4, ,2 2,2dc";
            string errorMessage = "Error argument. 2,2dc is not float.";

            //Act
            var result = Program.ReadList( inputValue );
            var errors = Program.errors;

            //Assert
            Assert.NotEmpty( result );
            Assert.Single( errors );
            Assert.Equal( errorMessage, errors[ 0 ] );
        }

        [Fact]
        public void ReadList_EmptyInput_CorrectRead()
        {
            //Arrange
            var inputValue = string.Empty;

            //Act
            var result = Program.ReadList( inputValue );
            var errors = Program.errors;

            //Assert
            Assert.NotNull( result );
            Assert.Empty( result );
            Assert.Empty( errors );
        }

        [Fact]
        public void MultiplicationListByMin()
        {
            //Arrange
            var inputList = new List<double> { 1, 2, 3, 3.2, 0.1 };
            var result = new List<double> { 0.1, 0.2, 0.3, 0.32, 0.01 };

            //Act
            Program.MultiplicationListByMin( inputList );
            var errors = Program.errors;

            //Assert
            Assert.Empty( errors );
            Assert.Equal( result.Count, inputList.Count );
            for ( int i = 0; i < inputList.Count; i++ )
            {
                Assert.Equal( result[ i ], inputList[ i ] );
            }
        }
    }
}
