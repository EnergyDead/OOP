using System.Diagnostics.Contracts;

namespace MyDateTime;

public struct DateTime
{
    private const int perMinute = 60;
    private const int perHour = perMinute * 60;
    private const int perDay = perHour * 24;

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

        return days + 1;
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
}