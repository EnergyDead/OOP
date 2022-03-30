using System;
using ThreeDimensionalBody;
using Xunit;

namespace BodyTests
{
    public class ParallelepipedTests
    {
        [Fact]
        public void Parallelepiped_ZeroBaseRadius_CorrectResult()
        {
            //arrange
            double width = 0;
            double heigth = 0;
            double depth = 0;
            double density = 0;
            Body body;

            //act
            body = new Parallelepiped( width, heigth, depth, density );

            //assert
            Assert.Equal( 0, body.GetVolume() );
            Assert.Equal( 0, body.GetMass() );
            Assert.Equal( 0, body.GetDensity() );
        }

        [Fact]
        public void Parallelepiped_CorrectInput_CorrectResult()
        {
            //arrange
            double width = 1;
            double heigth = 2;
            double density = 2;
            double depth = 1;
            Body body;

            //act
            body = new Parallelepiped( width, heigth, depth, density );

            //assert
            Assert.Equal( 2, body.GetVolume() );
            Assert.Equal( 4, body.GetMass() );
            Assert.Equal( 2, body.GetDensity() );
        }

        [Fact]
        public void Parallelepiped_NegativeWidth_ResultExeption()
        {
            //arrange
            double width = -1;
            double heigth = 2;
            double density = 2;
            double depth = 1;
            Body body;

            //act
            void act() => body = new Parallelepiped( width, heigth, depth, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'width')", exception.Message );
        }

        [Fact]
        public void Parallelepiped_NegativeDensity_ResultExeption()
        {
            //arrange
            double width = 1;
            double heigth = 2;
            double density = -1;
            double depth = 1;
            Body body;

            //act
            void act() => body = new Parallelepiped( width, heigth, depth, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'density')", exception.Message );
        }

        [Fact]
        public void Parallelepiped_NegativeDepth_ResultExeption()
        {
            //arrange
            double width = 1;
            double heigth = 2;
            double density = 1;
            double depth = -1;
            Body body;

            //act
            void act() => body = new Parallelepiped( width, heigth, depth, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'depth')", exception.Message );
        }

        [Fact]
        public void Parallelepiped_NegativeHeigth_ResultExeption()
        {
            //arrange
            double width = 0;
            double heigth = -1;
            double density = 1;
            double depth = 0;
            Body body;

            //act
            void act() => body = new Parallelepiped( width, heigth, depth, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'heigth')", exception.Message );
        }
    }
}
