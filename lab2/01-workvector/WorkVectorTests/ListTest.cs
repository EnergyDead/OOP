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
            string inputValue = "1 2 3 4 -1 4, 0,2 2,2";
            var resultList = new List<double>();

            //Act
            var isRead = Program.TryParseStringToListDouble( inputValue, resultList );

            //Assert
            Assert.True( isRead );
            Assert.NotEmpty( resultList );
            Assert.Equal( 8, resultList.Count );
        }

        [Fact]
        public void ReadList_IncorrectInputElements_ErrorrMessage()
        {
            //Arrange
            string inputValue = "1 2 3 4 -1 4, ,2 2,2dc";
            var resultList = new List<double>();

            //Act
            var isRead = Program.TryParseStringToListDouble( inputValue, resultList );

            //Assert
            Assert.False( isRead );
        }

        [Fact]
        public void ReadList_EmptyInput_CorrectRead()
        {
            //Arrange
            var inputValue = string.Empty;
            var resultList = new List<double>();

            //Act
            var isRead = Program.TryParseStringToListDouble( inputValue, resultList );

            //Assert
            Assert.True( isRead );
            Assert.Empty( resultList );
        }

        [Fact]
        public void MultiplicationListByMin_CorrectInput()
        {
            //Arrange
            var inputList = new List<double> { 1, 2, 3, 3.2, 0.1 };
            var result = new List<double> { 0.1, 0.2, 0.3, 0.32, 0.01 };

            //Act
            Program.MultiplicationListByMin( inputList );

            //Assert
            Assert.Equal( result.Count, inputList.Count );
            for ( int i = 0; i < inputList.Count; i++ )
            {
                Assert.Equal( result[ i ], inputList[ i ] );
            }
        }

        [Fact]
        public void MultiplicationListByMin_EmptyInput()
        {
            //Arrange
            var inputList = new List<double>();

            //Act
            Program.MultiplicationListByMin( inputList );

            //Assert
            Assert.Empty( inputList );
        }
    }
}
