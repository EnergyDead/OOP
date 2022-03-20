using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using GeneratePrime = GeneratePrimeNumbers.GeneratePrimeNumbers;

namespace GeneratePrimeNumbersTests
{
    public class GeneratePrimeNumbersTests
    {
        [Fact]
        public void GeneratePrimesNaive_ZeroInput_ArgumentOutOfRangeException()
        {
            //arrange
            int N = 0;

            //act
            Action action = () => GeneratePrime.GeneratePrimeNumbersSet( N );
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( action );

            //assert
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'Use a number between 2 and 100000000.')", exception.Message );
        }

        [Fact]
        public void GeneratePrimesNaive_InputOutsideInRange()
        {
            //arrange
            int N = 100000001;

            //act
            Action action = () => GeneratePrime.GeneratePrimeNumbersSet( N );
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( action );

            //assert
            Assert.Equal( "Specified argument was out of the range of valid values. (Parameter 'Use a number between 2 and 100000000.')", exception.Message );
        }

#if RELEASE
        [Fact]
        public void GeneratePrimesNaive_BigInput()
        {
            int N = 100000000;
            int countNaiveInN = 5761455;

            var result = GeneratePrime.GeneratePrimeNumbersSet( N );

            Assert.NotEmpty( result );
            Assert.Equal( countNaiveInN, result.Count );
        }
#endif
        [Fact]
        public void GeneratePrimesNaive_CorrectInput5_CorrectResalut()
        {
            int N = 5;
            var correctResults = new List<int>() { 2, 3, 5 };

            var result = GeneratePrime.GeneratePrimeNumbersSet( N ).ToList();

            Assert.NotEmpty( result );
            Assert.Equal( correctResults.Count, result.Count );
            for ( int i = 0; i < result.Count; i++ )
            {
                Assert.Equal( correctResults[ i ], result[ i ] );
            }
        }

        [Fact]
        public void GeneratePrimesNaive_CorrectInput6_CorrectResalut()
        {
            int N = 6;
            var correctResults = new List<int>() { 2, 3, 5 };

            var result = GeneratePrime.GeneratePrimeNumbersSet( N ).ToList();

            Assert.NotEmpty( result );
            Assert.Equal( correctResults.Count, result.Count );
            for ( int i = 0; i < result.Count; i++ )
            {
                Assert.Equal( correctResults[ i ], result[ i ] );
            }
        }
    }
}
