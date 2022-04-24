using System.Diagnostics.Contracts;

namespace MyDateTime;

public struct DateTime
{
    private const int perMinute = 60;
    private const int perHour = perMinute * 60;

    private ulong _datetime;

    public DateTime( ulong datetime = 0 )
    {
        _datetime = datetime;
    }

    public int Hour
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 0 );
            Contract.Ensures( Contract.Result<int>() < 60 );
            return (int) ( ( _datetime / perHour ) % 24 );
        }
    }

    public int Minute
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 0 );
            Contract.Ensures( Contract.Result<int>() < 60 );
            return (int) ( ( _datetime / perMinute ) % 60 );
        }
    }

    public int Second
    {
        get
        {
            Contract.Ensures( Contract.Result<int>() >= 0 );
            Contract.Ensures( Contract.Result<int>() < 60 );
            return (int) _datetime % 60;
        }
    }
}