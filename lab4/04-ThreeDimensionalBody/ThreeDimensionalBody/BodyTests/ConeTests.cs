using System;
using ThreeDimensionalBody;
using Xunit;

namespace BodyTests
{
    public class ConeTests
    {
        [Fact]
        public void Cone_ZeroBaseRadius_CorrectResult()
        {
            //arrange
            double radius = 0;
            double heigth = 0;
            double density = 0;
            Body body;

            //act
            body = new Cone( radius, heigth, density );

            //assert
            Assert.Equal( 0, body.GetVolume() );
            Assert.Equal( 0, body.GetMass() );
            Assert.Equal( 0, body.GetDensity() );
        }

        [Fact]
        public void Cone_CorrectInput_CorrectResult()
        {
            //arrange
            double radius = 2;
            double heigth = 2;
            double density = 2;
            Body body;

            //act
            body = new Cone( radius, heigth, density );

            //assert
            Assert.Equal( 8.378, body.GetVolume() );
            Assert.Equal( 16.756, body.GetMass() );
            Assert.Equal( 2, body.GetDensity() );
        }

        [Fact]
        public void Sphere_NegativeRadius_ResultExeption()
        {
            //arrange
            double radius = -1;
            double heigth = 2;
            double density = 2;
            Body body;

            //act
            void act() => body = new Cone( radius, heigth, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'baseRadius')", exception.Message );
        }

        [Fact]
        public void Sphere_NegativeDensity_ResultExeption()
        {
            //arrange
            double radius = 1;
            double heigth = 2;
            double density = -1;
            Body body;

            //act
            void act() => body = new Cone( radius, heigth, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'density')", exception.Message );
        }

        [Fact]
        public void Sphere_NegativeHeigth_ResultExeption()
        {
            //arrange
            double radius = 1;
            double heigth = -1;
            double density = 1;
            Body body;

            //act
            void act() => body = new Cone( radius, heigth, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'heigth')", exception.Message );
        }
    }
}
