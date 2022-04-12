namespace MyRational;

public class Rational
{
    // Возвращает числитель
    public int Numerator { get; private set; }
    // Возвращает знаменатель (натуральное число)
    public int Denominator { get; private set; }
    // Возвращает отношение числителя и знаменателя в виде числа double
    public double Value => (double) Numerator / Denominator;
    public Rational()
    {
        Numerator = 0;
        Denominator = 1;
    }

    // Конструирует рациональное число, равное value (value/1)
    public Rational( int value )
    {
        Numerator = value;
        Denominator = 1;
    }
    // Конструирует рациональное число, равное numerator/denominator
    // Рациональное число должно храниться в нормализованном виде:
    //	знаменатель положительный (числитель может быть отрицательным)
    //	числитель и знаменатель не имеют общиз делителей (6/8 => 3/4 и т.п.)
    // Если знаменатель равен нулю, должно сконструироваться рациональное число, равное нулю,
    // либо должно быть выброшено исключение std::invalid_argument.
    public Rational( int numerator, int denominator )
    {
        if ( denominator <= 0 )
        {
            throw new ArgumentException( "The denominator must be a natural number." );
        }
        int gcd;
        if ( numerator > 0 )
        {
            gcd = GreatestCommonDivisor( (uint) numerator, (uint) denominator );
        }
        else
        {
            gcd = GreatestCommonDivisor( (uint) -numerator, (uint) denominator );
        }

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    // Прочие операторы согласно заданию
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

    private static int GreatestCommonDivisor( uint first, uint second )
    {
        uint min = Math.Min( first, second );
        uint C = Math.Max( first, second ) % min;
        if ( C == 0 ) return (int) min;
        return GreatestCommonDivisor( min, C );
    }
}

#if false

    public static uint GCD( uint A, uint B )
    {
        uint C = A;
        A = A > B ? A : B;
        B = C > B ? B : C;
        C = A % B;
        if ( C == 0 ) return B;
        return GCD( B, C );
    }
public struct RationalNumber
{
    public int Numerator { get; private set; }
    public uint Denominator { get; private set; }
    public double Rational => ( (double) Numerator ) / ( (double) Denominator );
    public RationalNumber( int Numerator, uint Denominator )
    {
        uint gcd = 1;
        if ( Numerator == 0 )
        {
            this.Numerator = 0;
            this.Denominator = 1;
            return;
        }
        if ( Numerator > 0 )
            gcd = GCD( (uint) Numerator, Denominator );
        else
            gcd = GCD( (uint) -Numerator, Denominator );
        this.Numerator = Numerator / ( (int) gcd );
        this.Denominator = Denominator / gcd;
    }

    public static implicit operator double( RationalNumber r1 ) => r1.Rational;
    public static implicit operator RationalNumber( int r1 ) => new RationalNumber( r1, 1 );

    public static RationalNumber operator +( RationalNumber r1, RationalNumber r2 )
    {
        return new RationalNumber
            (
                (int) ( r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator ),
                r1.Denominator * r2.Denominator
            );
    }
    public static RationalNumber operator *( RationalNumber r1, RationalNumber r2 )
    {
        return new RationalNumber
            (
                (int) ( r1.Numerator * r2.Numerator ),
                 (uint) ( r1.Denominator * r2.Denominator )
            );
    }
    public static RationalNumber operator -( RationalNumber r1, RationalNumber r2 )
    {
        return r1 + ( -1 * r2 );
    }
    public static RationalNumber operator /( RationalNumber r1, RationalNumber r2 )
    {
        return r1 * r2.Numerator < 0
            ? new RationalNumber( (int) -r2.Denominator, (uint) -r2.Numerator )
            : new RationalNumber( (int) r2.Denominator, (uint) r2.Numerator );
    }

    public static uint GCD( uint A, uint B )
    {
        uint C = A;
        A = A > B ? A : B;
        B = C > B ? B : C;
        C = A % B;
        if ( C == 0 ) return B;
        return GCD( B, C );
    }
}
#endif