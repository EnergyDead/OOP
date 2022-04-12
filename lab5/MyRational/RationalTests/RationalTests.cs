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
        rational = new( 5 );

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
    public void CreateRational_CorrectInput_ReturnImplified()
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

    [Fact]
    public void CreateRational_CorrectNegativeInput_ReturnIimplified()
    {
        //arrange
        Rational rational;

        //act
        rational = new( -50, 5300 );

        //assert
        Assert.True( Math.Round( rational.Value, 3 ) == -0.009, "Инициализируем число -0.009" );
        Assert.True( rational.Numerator == -1, "знаменатель равен -1" );
        Assert.True( rational.Denominator == 106, "числитель равен 106" );
    }

    [Fact]
    public void UnaryPlus_Unchanged()
    {
        //arrange
        Rational rational = new( 2 );

        //act
        _ = +rational;

        //assert
        Assert.True( rational.Value == 2, "Унарный плюс. Без именений." );
    }

    [Fact]
    public void UnaryMinus_VhangesTheSignOfTheNumber()
    {
        //arrange
        Rational rational = new( 2 );

        //act
        _ = -rational;

        //assert
        Assert.True( rational.Value == -2, "Унарный минус. Изменился знак." );
    }

    [Fact]
    public void UnaryMinus_NegativeInput_VhangesTheSignOfTheNumber()
    {
        //arrange
        Rational rational = new( -2 );

        //act
        _ = -rational;

        //assert
        Assert.True( rational.Value == 2, "Унарный минус. Изменился знак." );
    }

    [Fact]
    public void Sum_TwoNurmalRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        Rational rational2 = new( 4, 7 );

        //act
        Rational result = rational + rational2;

        //assert
        Assert.True( Math.Round( result.Value, 2 ) == 1.24, "Сумма равна 1.23." );
        Assert.True( result.Numerator == 26, "Числитель равен 26." );
        Assert.True( result.Denominator == 21, "Знаменатель 21." );
    }

    [Fact]
    public void Sum_NegativeAndCorrectInput_ValidReturn()
    {
        //arrange
        Rational rational = new( -7, 3 );
        Rational rational2 = new( 4, 9 );

        //act
        Rational result = rational + rational2;

        //assert
        Assert.True( Math.Round( result.Value, 2 ) == -1.89, "Сумма равна -1.88." );
        Assert.True( result.Numerator == -17, "Числитель равен -17." );
        Assert.True( result.Denominator == 9, "Знаменатель 9." );
    }

    [Fact]
    public void Sum_NurmalRationalAndInt_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 2;

        //act
        Rational result = rational + numb;

        //assert
        Assert.True( Math.Round( result.Value, 2 ) == 1.24, "Сумма равна 1.23." );
        Assert.True( result.Numerator == 26, "Числитель равен 26." );
        Assert.True( result.Denominator == 21, "Знаменатель 21." );
    }
}
