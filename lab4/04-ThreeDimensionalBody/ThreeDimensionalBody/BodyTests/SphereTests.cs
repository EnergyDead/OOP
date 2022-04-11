using System;
using ThreeDimensionalBody;
using Xunit;

namespace BodyTests
{
    public class SphereTests
    {
        [Fact]
        public void Sphere_ZeroRadius_ResultCorrect()
        {
            //arrange
            double radius = 0;
            double density = 0;
            Body body;

            //act
            body = new Sphere( radius, density );

            //assert
            Assert.Equal( 0, body.GetVolume() );
            Assert.Equal( 0, body.GetMass() );
            Assert.Equal( 0, body.GetDensity() );
        }

        [Fact]
        public void Sphere_CorrectInput_ResultCorrect()
        {
            //arrange
            double radius = 1;
            double density = 2;
            Body body;

            //act
            body = new Sphere( radius, density );

            //assert
            Assert.Equal( 4.189, Math.Round( body.GetVolume(), 3 ) );
            Assert.Equal( 8.378, Math.Round( body.GetMass(), 3 ) );
            Assert.Equal( 2, body.GetDensity() );
        }

        [Fact]
        public void Sphere_NegativeRadius_ResultExeption()
        {
            //arrange
            double radius = -1;
            double density = 1;
            Body body;

            //act
            void act() => body = new Sphere( radius, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'radius')", exception.Message );
        }

        [Fact]
        public void Sphere_NegativeDensity_ResultExeption()
        {
            //arrange
            double radius = 1;
            double density = -1;
            Body body;

            //act
            void act() => body = new Sphere( radius, density );

            //assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( act );
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'density')", exception.Message );
        }
    }
}