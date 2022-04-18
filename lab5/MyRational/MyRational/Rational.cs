namespace MyRational;

// todo: изменить на значимый тип
public class Rational
{
    public int Numerator { get; private set; }

    public int Denominator { get; private set; }

    // todo: сделать toDouble() вместо value
    public double ToDouble()
    {
        return (double) Numerator / Denominator;
    }

    public Rational()
    {
        Numerator = 0;
        Denominator = 1;
    }

    public Rational( int value )
    {
        Numerator = value;
        Denominator = 1;
    }

    public Rational( int numerator, int denominator )
    {
        if ( denominator <= 0 )
        {
            throw new ArgumentException( "The denominator must be a natural number." );
        }
        int gcd = 1;
        if ( numerator > 0 )
        {
            gcd = GreatestCommonDivisor( numerator, denominator );
        }
        else if ( numerator < 0 )
        {
            gcd = GreatestCommonDivisor( -numerator, denominator );
        }

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public static implicit operator Rational( int value ) => new( value );

    public (int, Rational) ToCompoundFraction()
    {
        // todo: переиминовать
        int wholPart = Numerator / Denominator;
        return (wholPart, this - wholPart);
    }

    public override string ToString()
    {
        return $"{Numerator} / {Denominator}";
    }

    // todo: реализовать через сравнение Numerator и Denominator
    #region Arithmetic operator
    public static Rational operator +( Rational rational )
    {
        // todo: возвращать новый Rational
        return rational;
    }

    public static Rational operator -( Rational rational )
    {
        // todo: возвращать новый Rational
        rational.Numerator *= -1;
        return rational;
    }

    // todo: добавить проверку на переполнение
    public static Rational operator +( Rational first, Rational second )
    {
        // todo: добавить denominator
        var numerator = 0;
        checked
        {
            numerator = first.Numerator * second.Denominator + second.Numerator * first.Denominator;
        }
        var denominator = first.Denominator * second.Denominator;

        return new Rational( numerator, denominator );
    }

    public static Rational operator -( Rational first, Rational second )
    {
        return first + ( -second );
    }

    public static Rational operator *( Rational first, Rational second )
    {
        var numerator = 0;
        var denominator = 0;
        checked
        {
            numerator = first.Numerator * second.Numerator;
            denominator = first.Denominator * second.Denominator;
        }
        return new Rational( numerator, denominator );
    }

    // todo: передавать в denominator только положительные значения
    public static Rational operator /( Rational first, Rational second )
    {
        var numerator = 0;
        var denominator = 0;
        checked
        {
            numerator = first.Numerator * second.Denominator;
            denominator = first.Denominator * second.Numerator;
        }
        if ( denominator < 0 )
        {
            numerator *= -1;
            denominator *= -1;
        }
        return new Rational( numerator, denominator );
    }
    #endregion

    // todo: добавить тесты
    #region Comparison operator
    public static bool operator >( Rational first, Rational second )
    {
        int gcd = GreatestCommonDivisor( first.Denominator, second.Denominator );
        bool result;
        checked
        {
            result = first.Numerator * gcd > second.Numerator * gcd;
        }
        return result;
    }

    // todo: добавить тесты
    public static bool operator <( Rational first, Rational second )
    {
        int gcd = GreatestCommonDivisor( first.Denominator, second.Denominator );
        bool result;
        checked
        {
            result = first.Numerator * gcd < second.Numerator * gcd;
        }
        return result;
    }

    public static bool operator ==( Rational first, Rational second )
    {
        return first.Numerator == second.Numerator && first.Denominator == second.Denominator;
    }

    public static bool operator !=( Rational first, Rational second )
    {
        return first.Numerator != second.Numerator || first.Denominator != second.Denominator;
    }

    public static bool operator >=( Rational first, Rational second )
    {
        return ( first > second ) || ( first == second );
    }

    public static bool operator <=( Rational first, Rational second )
    {
        return ( first < second ) || ( first == second );
    }
    #endregion

    private static int GreatestCommonDivisor( int first, int second )
    {
        int min = Math.Min( first, second );
        int remainderOfDivision = Math.Max( first, second ) % min;
        if ( remainderOfDivision == 0 ) return (int) min;
        return GreatestCommonDivisor( min, remainderOfDivision );
    }

    public override bool Equals( object obj )
    {
        if ( ReferenceEquals( this, obj ) )
        {
            return true;
        }

        if ( obj is null )
        {
            return false;
        }

        return this == (Rational) obj;
    }
}