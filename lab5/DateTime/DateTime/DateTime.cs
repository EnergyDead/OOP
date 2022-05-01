using System.Diagnostics.Contracts;

namespace MyDateTime;

public struct DateTime
{
    private const int perMinute = 60;
    private const int perHour = perMinute * 60;
    private const int perDay = perHour * 24;
    private const int daysPerYear = 365;
    private const int daysPer4Years = 1461;
    private const int daysPer100Years = 36524;
    private const int daysPer400Years = 146097;

    private static readonly int[] s_daysToMonth365 = {
            0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
    private static readonly int[] s_daysToMonth366 = {
            0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };

    private ulong _timeStamp;

    public DateTime( ulong datetime = 0 )
    {
        _timeStamp = datetime;
    }

    public int Second
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 0 );
            Contract.Ensures( Contract.Result<int>() < 60 );
            return (int) _timeStamp % 60;
        }
    }

    public int Minute
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 0 );
            Contract.Ensures( Contract.Result<int>() < 60 );
            return (int) ( ( _timeStamp / perMinute ) % 60 );
        }
    }

    public int Hour
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 0 );
            Contract.Ensures( Contract.Result<int>() < 24 );
            return (int) ( ( _timeStamp / perHour ) % 24 );
        }
    }

    public int Day
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 1 );
            Contract.Ensures( Contract.Result<int>() < 31 );
            return GetDay();
        }
    }

    public int Month
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 1 );
            Contract.Ensures( Contract.Result<int>() < 12 );
            return GetMonth();
        }
    }

    public int Year
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 0001 );
            Contract.Ensures( Contract.Result<int>() < 9999 );
            return GetYear();
        }
    }

    public WeekDay WeekDay
    {
        get
        {
            return GetWeekDay();
        }
    }

    public override string ToString()
    {
        return $"{Day}/{Month}/{Year} {Hour}:{Minute}:{Second} {GetShorhWeekDay()}";
    }

    private WeekDay GetWeekDay()
    {
        throw new NotImplementedException();
    }

    private int GetDay()
    {
        var days = (int) ( _timeStamp / perDay );
        int countYear400 = days / daysPer400Years;
        days -= countYear400 * daysPer400Years;

        int countYear100 = days / daysPer100Years;
        if ( countYear100 == 4 ) countYear100 = 3;
        days -= countYear100 * daysPer100Years;

        int countYear4 = days / daysPer4Years;
        days -= countYear4 * daysPer4Years;

        int countYear1 = days / daysPerYear;
        if ( countYear1 == 4 ) countYear1 = 3;
        days -= countYear1 * daysPerYear;

        bool leapYear = countYear1 == 3 && ( countYear4 != 24 || countYear100 == 3 );
        int[] daysM = leapYear ? s_daysToMonth366 : s_daysToMonth365;
        int m = 0;
        while ( days >= daysM[ m ] )
        {
            m++;
        }

        return days - daysM[ m - 1 ] + 1;
    }

    private int GetMonth()
    {
        throw new NotImplementedException();
    }

    private int GetYear()
    {
        throw new NotImplementedException();
    }

    private string GetShorhWeekDay()
    {
        throw new NotImplementedException();
    }

    private int CountDaysLeapYear( int days )
    {
        int y400 = days / daysPer400Years;
        days -= y400 * daysPer400Years;
        int y100 = days / daysPer100Years;
        if ( y100 == 4 ) y100 = 3;
        days -= y100 * daysPer100Years;
        int y4 = days / daysPer4Years;
        days -= y4 * daysPer4Years;
        int y1 = days / daysPerYear;
        if ( y1 == 4 ) y1 = 3;
        days -= y1 * daysPerYear;
        bool leapYear = y1 == 3 && ( y4 != 24 || y100 == 3 );
        int m = ( days >> 5 ) + 1;
        int[] daysM = leapYear ? s_daysToMonth366 : s_daysToMonth365;
        while ( days >= daysM[ m ] ) m++;

        return days - daysM[ m - 1 ] + 1;
    }
}