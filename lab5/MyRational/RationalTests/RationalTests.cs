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
        Assert.True( rational.ToDouble() == 0, "Инициализируем число 0/1" );
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
        Assert.True( rational.ToDouble() == 5, "Инициализируем число 5/1" );
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
        Assert.True( rational.ToDouble() == -5, "Инициализируем число -5/1" );
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
        Assert.True( rational.ToDouble() == 2.5, "Инициализируем число 5/2" );
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
        Assert.True( rational.ToDouble() == -2.5, "Инициализируем число -5/2" );
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
        Assert.True( rational.ToDouble() == 10, "Инициализируем число 10/1" );
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
        Assert.True( Math.Round( rational.ToDouble(), 3 ) == -0.009, "Инициализируем число -0.009" );
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
        Assert.True( rational.ToDouble() == 2, "Унарный плюс. Без именений." );
    }

    [Fact]
    public void UnaryMinus_VhangesTheSignOfTheNumber()
    {
        //arrange
        Rational rational = new( 2 );

        //act
        var result = -rational;

        //assert
        Assert.True( rational.ToDouble() == 2, "Унарный минус. Не изменяет исходное число." );
        Assert.True( result.ToDouble() == -2, "Унарный минус. Изменился знак." );
    }

    [Fact]
    public void UnaryMinus_NegativeInput_VhangesTheSignOfTheNumber()
    {
        //arrange
        Rational rational = new( -2 );

        //act
        var result = -rational;

        //assert
        Assert.True( rational.ToDouble() == -2, "Унарный минус. Не изменяет исходное число." );
        Assert.True( result.ToDouble() == 2, "Унарный минус. Изменился знак." );
    }

    [Fact]
    public void SumShort_TwoRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        Rational rational2 = new( 4, 7 );

        //act
        rational += rational2;

        //assert
        Assert.Equal( 1.24, rational.ToDouble(), 2 );
        Assert.Equal( 26, rational.Numerator );
        Assert.Equal( 21, rational.Denominator );
    }

    [Fact]
    public void MinusShort_TwoRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        Rational rational2 = new( 4, 7 );

        //act
        rational -= rational2;

        //assert
        Assert.Equal( 0.1, Math.Round( rational.ToDouble(), 2 ) );
        Assert.Equal( 2, rational.Numerator );
        Assert.Equal( 21, rational.Denominator );
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
        Assert.True( Math.Round( result.ToDouble(), 2 ) == 1.24, "Сумма равна 1.23." );
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

        //assert98." );
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
        Assert.True( Math.Round( result.ToDouble(), 2 ) == 2.67, "Сумма равна 2.67." );
        Assert.True( result.Numerator == 8, "Числитель равен 8." );
        Assert.True( result.Denominator == 3, "Знаменатель 3." );
    }

    [Fact]
    public void Sum_IntAndNurmalRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 2;

        //act
        Rational result = numb + rational;

        //assert
        Assert.True( Math.Round( result.ToDouble(), 2 ) == 2.67, "Сумма равна 2.67." );
        Assert.True( result.Numerator == 8, "Числитель равен 8." );
        Assert.True( result.Denominator == 3, "Знаменатель 3." );
    }

    [Fact]
    public void Sum_TwoInt_ValidReturn()
    {
        //arrange
        int numb = 2;

        //act
        Rational result = numb + numb;

        //assert
        Assert.True( result.ToDouble() == 4, "Сумма равна 4." );
        Assert.True( result.Numerator == 4, "Числитель равен 4." );
        Assert.True( result.Denominator == 1, "Знаменатель 1." );
    }

    [Fact]
    public void Minus_TwoNurmalRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        Rational rational2 = new( 4, 9 );

        //act
        Rational result = rational - rational2;

        //assert
        Assert.Equal( 0.22, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 2, result.Numerator );
        Assert.Equal( 9, result.Denominator );
    }

    [Fact]
    public void Minus_TwoNurmalRationalOneNegative_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        Rational rational2 = new( -4, 9 );

        //act
        Rational result = rational - rational2;

        //assert
        Assert.Equal( 1.11, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 10, result.Numerator );
        Assert.Equal( 9, result.Denominator );
    }

    [Fact]
    public void Minus_NurmalRationalAndNumber_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 3;

        //act
        Rational result = rational - numb;

        //assert
        Assert.Equal( -2.33, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( -7, result.Numerator );
        Assert.Equal( 3, result.Denominator );
    }

    [Fact]
    public void Minus_NumberAndNurmalRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 3;

        //act
        Rational result = numb - rational;

        //assert
        Assert.Equal( 2.33, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 7, result.Numerator );
        Assert.Equal( 3, result.Denominator );
    }

    [Fact]
    public void Minus_TwoNumber_ValidReturn()
    {
        //arrange
        int numb = 3;
        int numb2 = 5;

        //act
        Rational result = numb2 - numb;

        //assert
        Assert.Equal( 2, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 2, result.Numerator );
        Assert.Equal( 1, result.Denominator );
    }

    [Fact]
    public void Multiply_TwoRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        Rational rational2 = new( 5, 4 );

        //act
        Rational result = rational * rational2;

        //assert
        Assert.Equal( 0.83, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 5, result.Numerator );
        Assert.Equal( 6, result.Denominator );
    }

    [Fact]
    public void Multiply_RationalAndNumber_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 3;

        //act
        Rational result = rational * numb;

        //assert
        Assert.Equal( 2, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 2, result.Numerator );
        Assert.Equal( 1, result.Denominator );
    }

    [Fact]
    public void MultiplyShort_RationalAndNumber_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 3;

        //act
        rational *= numb;

        //assert
        Assert.Equal( 2, Math.Round( rational.ToDouble(), 2 ) );
        Assert.Equal( 2, rational.Numerator );
        Assert.Equal( 1, rational.Denominator );
    }

    [Fact]
    public void Multiply_NumberAndRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 3;

        //act
        Rational result = numb * rational;

        //assert
        Assert.Equal( 2, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 2, result.Numerator );
        Assert.Equal( 1, result.Denominator );
    }

    [Fact]
    public void Division_TwoRational_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        Rational rational2 = new( 2, 3 );

        //act
        Rational result = rational / rational2;

        //assert
        Assert.Equal( 1, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 1, result.Numerator );
        Assert.Equal( 1, result.Denominator );
    }

    [Fact]
    public void Division_RationalAndNumber_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 2;

        //act
        Rational result = rational / numb;

        //assert
        Assert.Equal( 0.33, Math.Round( result.ToDouble(), 2 ) );
        Assert.Equal( 1, result.Numerator );
        Assert.Equal( 3, result.Denominator );
    }

    [Fact]
    public void DivisionShort_RationalAndNumber_ValidReturn()
    {
        //arrange
        Rational rational = new( 2, 3 );
        int numb = 2;

        //act
        rational /= numb;

        //assert
        Assert.Equal( 0.33, Math.Round( rational.ToDouble(), 2 ) );
        Assert.Equal( 1, rational.Numerator );
        Assert.Equal( 3, rational.Denominator );
    }

    [Fact]
    public void Compare_TwoRational_Equal()
    {
        //arrange
        var first = new Rational( 2, 3 );
        var second = new Rational( 2, 3 );

        //act
        var result = first == second;

        //assert
        Assert.True( result );
    }

    [Fact]
    public void Compare_TwoRational_NotEqual()
    {
        //arrange
        var first = new Rational( 2, 3 );
        var second = new Rational( 4, 3 );

        //act
        var result = first == second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void Compare_RationalAndNumber_Equal()
    {
        //arrange
        var first = new Rational( 2 );
        var second = 2;

        //act
        var result = first == second;

        //assert
        Assert.True( result );
    }

    [Fact]
    public void Compare_RationalAndNumber_NotEqual()
    {
        //arrange
        var first = new Rational( 2, 3 );
        var second = 3;

        //act
        var result = first == second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void Compare_NumberAndRational_Equal()
    {
        //arrange
        var second = new Rational( 2 );
        var first = 2;

        //act
        var result = first == second;

        //assert
        Assert.True( result );
    }

    [Fact]
    public void Compare_NumberAndRational_NotEqual()
    {
        //arrange
        var second = new Rational( 2, 3 );
        var first = 3;

        //act
        var result = first == second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void CompareToNotEqual_NumberAndRational_NotEqual()
    {
        //arrange
        var second = new Rational( 2, 3 );
        var first = 3;

        //act
        var result = first != second;

        //assert
        Assert.True( result );
    }

    [Fact]
    public void CompareToNotEqual_RationalAndNumber_Equal()
    {
        //arrange
        var first = new Rational( 6, 2 );
        var second = 3;

        //act
        var result = first != second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void MixedShot_Correct()
    {
        //arrange
        var first = new Rational( 9, 4 );
        var rational = new Rational( 1, 4 );

        //act
        var result = first.ToCompoundFraction();

        //assert
        Assert.Equal( 2, result.Item1 );
        Assert.Equal( rational, result.Item2 );
    }

    [Fact]
    public void MixedShot_Integer_Correct()
    {
        //arrange
        var first = new Rational( 6, 2 );
        var rational = new Rational( 0 );

        //act
        var result = first.ToCompoundFraction();

        //assert
        Assert.Equal( 3, result.Item1 );
        Assert.Equal( rational, result.Item2 );
    }
    // todo: Добавить тесты для ToCompoundFraction: -1/4, -5/4, 0

    [Fact]
    public void MixedShot_Zero_Correct()
    {
        //arrange
        var first = new Rational( 0 );
        var rational = new Rational( 0 );

        //act
        var result = first.ToCompoundFraction();

        //assert
        Assert.Equal( 0, result.Item1 );
        Assert.Equal( rational, result.Item2 );
    }

    [Fact]
    public void MixedShot_NegativeMixed_Correct()
    {
        //arrange
        var first = new Rational( -1, 4 );
        var rational = new Rational( -1, 4 );

        //act
        var result = first.ToCompoundFraction();

        //assert
        Assert.Equal( 0, result.Item1 );
        Assert.Equal( rational, result.Item2 );
    }

    [Fact]
    public void MixedShot_NegativeNoMixed_Correct()
    {
        //arrange
        var first = new Rational( -5, 4 );
        var rational = new Rational( -1, 4 );

        //act
        var result = first.ToCompoundFraction();

        //assert
        Assert.Equal( -1, result.Item1 );
        Assert.Equal( rational, result.Item2 );
    }

    [Fact]
    public void Multiply_RationalAndNumber_Overflow()
    {
        //arrange
        Rational rational = new( 4, 3 );
        int numb = int.MinValue;
        Rational result;
        //act

        void act() => result = rational * numb;

        //assert
        OverflowException exception = Assert.Throws<OverflowException>( act );
        Assert.Equal( "Arithmetic operation resulted in an overflow.", exception.Message );
    }

    [Fact]
    public void Division_RationalAndNumber_Overflow()
    {
        //arrange
        Rational rational = new( 4, 3 );
        int numb = int.MinValue;
        Rational result;
        //act

        void act() => result = rational / numb;

        //assert
        OverflowException exception = Assert.Throws<OverflowException>( act );
        Assert.Equal( "Arithmetic operation resulted in an overflow.", exception.Message );
    }

    [Fact]
    public void More_TwoRational_NotEqual()
    {
        //arrange
        var first = new Rational( 2, 3 );
        var second = new Rational( 4, 3 );

        //act
        var result = first >= second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void More_RationalAndNumber_Equal()
    {
        //arrange
        var first = new Rational( 2 );
        var second = 2;

        //act
        var result = first > second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void More_RationalAndNumber_NotEqual()
    {
        //arrange
        var first = new Rational( 2, 3 );
        var second = 3;

        //act
        var result = first > second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void More_NumberAndRational_Equal()
    {
        //arrange
        var second = new Rational( 2 );
        var first = 2;

        //act
        var result = first > second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void More_NumberAndRational_NotEqual()
    {
        //arrange
        var second = new Rational( 2, 3 );
        var first = 3;

        //act
        var result = first > second;

        //assert
        Assert.True( result );
    }

    [Fact]
    public void Less_RationalAndNumber_NotEqual()
    {
        //arrange
        var first = new Rational( 2, 3 );
        var second = 3;

        //act
        var result = first < second;

        //assert
        Assert.True( result );
    }

    [Fact]
    public void Less_NumberAndRational_Equal()
    {
        //arrange
        var second = new Rational( 2 );
        var first = 2;

        //act
        var result = first < second;

        //assert
        Assert.False( result );
    }

    [Fact]
    public void Less_NumberAndRational_NotEqual()
    {
        //arrange
        var second = new Rational( 2, 3 );
        var first = 3;

        //act
        var result = first < second;

        //assert
        Assert.False( result );
    }
}
