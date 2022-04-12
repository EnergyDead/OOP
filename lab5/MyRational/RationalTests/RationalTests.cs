using MyRational;
using System;
using Xunit;

namespace RationalTests;

public class RationalTests
{
    [Fact]
    public void CreateRational_NumberEqualZero()
    { 
        //arrange
        Rational rational;

        //act
        rational = new();

        //assert
        Assert.True( rational.Value == 0, "Инициализируем число 0/1" );
        Assert.True( rational.Numerator == 0, "знаменатель равен 0" );
        Assert.True( rational.Denominator == 1, "числитель равен 1" );
    }

    [Fact]
    public void CreateRational_EqualsInputAndResult()
    {
        //arrange
        Rational rational;

        //act
        rational = new(5);

        //assert
        Assert.True( rational.Value == 5, "Инициализируем число 5/1" );
        Assert.True( rational.Numerator == 5, "знаменатель равен 5" );
        Assert.True( rational.Denominator == 1, "числитель равен 1" );
    }

    [Fact]
    public void CreateRational_NegativeNumerator()
    {
        //arrange
        Rational rational;

        //act
        rational = new( -5 );

        //assert
        Assert.True( rational.Value == -5, "Инициализируем число -5/1" );
        Assert.True( rational.Numerator == -5, "знаменатель равен -5" );
        Assert.True( rational.Denominator == 1, "числитель равен 1" );
    }

    [Fact]
    public void CreateRational_CorrectNumeratorAndDenominator_ReturnCorrect()
    {
        //arrange
        Rational rational;

        //act
        rational = new( 5, 2 );

        //assert
        Assert.True( rational.Value == 2.5, "Инициализируем число 5/2" );
        Assert.True( rational.Numerator == 5, "знаменатель равен 5" );
        Assert.True( rational.Denominator == 2, "числитель равен 2" );
    }

    [Fact]
    public void CreateRational_NegativeNumeratorAndCorrectDenominator_ReturnCorrect()
    {
        //arrange
        Rational rational;

        //act
        rational = new( -5, 2 );

        //assert
        Assert.True( rational.Value == -2.5, "Инициализируем число -5/2" );
        Assert.True( rational.Numerator == -5, "знаменатель равен -5" );
        Assert.True( rational.Denominator == 2, "числитель равен 2" );
    }

    [Fact]
    public void CreateRational_NegativeNumeratorAndNegativeDenominator_ReturnExeption()
    {
        //arrange
        Rational rational;

        //act
        void act() => rational = new( -5, -2 );

        //assert
        ArgumentException exception = Assert.Throws<ArgumentException>( act );
        Assert.Equal( "The denominator must be a natural number.", exception.Message );
    }

    [Fact]
    public void CreateRational_CorrectNumeratorAndZeroDenominator_ReturnExeption()
    {
        //arrange
        Rational rational;

        //act
        void act() => rational = new( 3, 0 );

        //assert
        ArgumentException exception = Assert.Throws<ArgumentException>( act );
        Assert.Equal( "The denominator must be a natural number.", exception.Message );
    }

    [Fact]
    public void CreateRational_CorrectInput_ReturnЫimplified()
    {
        //arrange
        Rational rational;

        //act
        rational = new( 50, 5 );

        //assert
        Assert.True( rational.Value == 10, "Инициализируем число 10/1" );
        Assert.True( rational.Numerator == 10, "знаменатель равен 10" );
        Assert.True( rational.Denominator == 1, "числитель равен 1" );
    }
}
