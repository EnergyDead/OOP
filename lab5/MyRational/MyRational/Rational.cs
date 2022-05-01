namespace MyRational;

// todo: изменить на значимый тип +
public struct Rational
{
    public int Numerator { get; private set; }

    public int Denominator { get; private set; }

    // todo: сделать toDouble() вместо value +
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
        // todo: переиминовать +
        int wholePart = Numerator / Denominator;
        return (wholePart, this - wholePart);
    }

    public override string ToString()
    {
        return $"{Numerator} / {Denominator}";
    }

    #region Arithmetic operator
    public static Rational operator +( Rational rational )
    {
        // todo: возвращать новый Rational +
        return new( rational.Numerator, rational.Denominator );
    }

    public static Rational operator -( Rational rational )
    {
        // todo: возвращать новый Rational -
        return new( -rational.Numerator, rational.Denominator );
    }

    // todo: добавить проверку на переполнение +
    public static Rational operator +( Rational first, Rational second )
    {
        // todo: добавить denominator +
        var numerator = 0;
        var denominator = 0;
        checked
        {
            numerator = first.Numerator * second.Denominator + second.Numerator * first.Denominator;
            denominator = first.Denominator * second.Denominator;
        }

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

    // todo: передавать в denominator только положительные значения +
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

    // todo: добавить тесты +
    // todo: реализовать через сравнение Numerator и Denominator +
    #region Comparison operator
    public static bool operator >( Rational first, Rational second )
    {
        // todo:
        int smallestCommonMultiple = ( first.Denominator * second.Denominator ) / GreatestCommonDivisor( first.Denominator, second.Denominator );
        bool result;
        checked
        {
            result = first.Numerator * ( smallestCommonMultiple / first.Denominator ) > second.Numerator * ( smallestCommonMultiple / second.Denominator );
        }
        return result;
    }

    // todo: добавить тесты +
    public static bool operator <( Rational first, Rational second )
    {
        int smallestCommonMultiple = ( first.Denominator * second.Denominator ) / GreatestCommonDivisor( first.Denominator, second.Denominator );
        bool result;
        checked
        {
            result = first.Numerator * ( smallestCommonMultiple / first.Denominator ) < second.Numerator * ( smallestCommonMultiple / second.Denominator );
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
        if ( remainderOfDivision == 0 )
        {
            return min;
        }

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