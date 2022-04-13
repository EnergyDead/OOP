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

    public static implicit operator Rational( int value ) => new( value );

    public static Rational operator +( Rational rational )
    {
        return rational;
    }
    public static Rational operator -( Rational rational )
    {
        rational.Numerator *= -1;
        return rational;
    }

    public override string ToString()
    {
        return $"{Numerator} / {Denominator}";
    }

    #region Arithmetic operator
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
    #endregion

    private static int GreatestCommonDivisor( uint first, uint second )
    {
        uint min = Math.Min( first, second );
        uint C = Math.Max( first, second ) % min;
        if ( C == 0 ) return (int) min;
        return GreatestCommonDivisor( min, C );
    }
}