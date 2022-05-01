using Xunit;
using MyDateTime;

namespace DateTimeTests;

public class DateTimeTests
{
    [Fact]
    public void CreateDateTime()
    {
        DateTime dateTime = new( 61283 );

        Assert.Equal( 23, dateTime.Second );
        Assert.Equal( 1, dateTime.Minute );
        Assert.Equal( 17, dateTime.Hour );
    }

    [Fact]
    public void CreateSecond()
    {
        DateTime dateTime = new( 61 );

        Assert.Equal( 1, dateTime.Second );
    }

    [Fact]
    public void GetDay()
    {
        DateTime dateTime = new( 6656767561283 );

        Assert.Equal( 26, dateTime.Day );
    }
}
