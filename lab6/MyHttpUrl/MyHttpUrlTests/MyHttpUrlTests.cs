using MyHttpUrl;
using System;
using Xunit;

namespace MyHttpUrlTests;

public class MyHttpUrlTests
{
    [Fact]
    public void CreateEmptyUrl_NullArgExp()
    {
        //Arrange   
        HttpUrl url;

        //Act
        void action() => url = new( null );

        //Assert
        Assert.Throws<UrlParsingError>( action );
    }

    [Fact]
    public void CreateUrl_EmptyString_ReturnExp()
    {
        //Arrange
        HttpUrl url;

        //Act
        void action() => url = new( string.Empty );


        //Assert
        Assert.Throws<UrlParsingError>( action );

    }

    [Fact]
    public void CreateUrl_SepToStart_ProtocolExp()
    {
        //Arrange
        HttpUrl url;
        string strUrl = @"://google.com/main.txt";

        //Act
        void action() => url = new( strUrl );


        //Assert
        Assert.Throws<UrlParsingError>( action );

    }

    [Fact]
    public void CreateUrl_SepHasNot_ProtocolExp()
    {
        //Arrange
        HttpUrl url;
        string strUrl = @"google.com/main.txt";

        //Act
        void action() => url = new( strUrl );


        //Assert
        Assert.Throws<UrlParsingError>( action );

    }

    [Fact]
    public void CreateUrl_ReturnCorrectUrl()
    {
        //Arrange
        string strUrl = @"http://google.com/main.txt";

        //Act
        HttpUrl url = new( strUrl );

        //Assert
        Assert.Equal( strUrl, url.Url );
        Assert.Equal( Protocol.HTTP, url.Protocol );
        Assert.Equal( "", url.Domain );
        Assert.Equal( "", url.Document );
        Assert.Equal( 1, url.Port );
        
    }
}
