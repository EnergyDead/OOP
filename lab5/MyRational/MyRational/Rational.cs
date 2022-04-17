namespace MyRational;

public class Rational
{
    public int Numerator { get; private set; }

    public int Denominator { get; private set; }

    public double Value => (double) Numerator / Denominator;
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
            gcd = GreatestCommonDivisor( (uint) numerator, (uint) denominator );
        }
        else if (numerator < 0 )
        {
            gcd = GreatestCommonDivisor( (uint) -numerator, (uint) denominator );
        }

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public static implicit operator Rational( int value ) => new( value );

    public (int, Rational) ToCompoundFraction()
    {
        int wholPart = Numerator / Denominator;
        return ( wholPart, this - wholPart );
    }

    

    public override string ToString()
    {
        return $"{Numerator} / {Denominator}";
    }

    #region Arithmetic operator
    public static Rational operator +( Rational rational )
    {
        return rational;
    }

    public static Rational operator -( Rational rational )
    {
        rational.Numerator *= -1;
        return rational;
    }

    public static Rational operator +( Rational first, Rational second )
    {
        var numerator = first.Numerator * second.Denominator + second.Numerator * first.Denominator;
        var denominator = first.Denominator * second.Denominator;

        return new Rational( numerator, denominator );
    }

    public static Rational operator -( Rational first, Rational second )
    {
        return first + ( -second );
    }

    public static Rational operator *( Rational first, Rational second )
    {
        var numerator = first.Numerator * second.Numerator;
        var denominator = first.Denominator * second.Denominator;

        return new Rational( numerator, denominator );
    }

    public static Rational operator /( Rational first, Rational second )
    {
        var numerator = first.Numerator * second.Denominator;
        var denominator = first.Denominator * second.Numerator;

        return new Rational( numerator, denominator );
    }
    #endregion

    #region Comparison operator
    public static bool operator >( Rational first, Rational second )
    {
        return first.Value > second.Value;
    }

    public static bool operator <( Rational first, Rational second )
    {
        return first.Value < second.Value;
    }

    public static bool operator ==( Rational first, Rational second )
    {
        return first.Value == second.Value;
    }

    public static bool operator !=( Rational first, Rational second )
    {
        return first.Value != second.Value;
    }

    public static bool operator >=( Rational first, Rational second )
    {
        return first.Value >= second.Value;
    }

    public static bool operator <=( Rational first, Rational second )
    {
        return first.Value <= second.Value;
    }
    #endregion

    private static int GreatestCommonDivisor( uint first, uint second )
    {
        uint min = Math.Min( first, second );
        uint C = Math.Max( first, second ) % min;
        if ( C == 0 ) return (int) min;
        return GreatestCommonDivisor( min, C );
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

        return this == (Rational)obj;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}