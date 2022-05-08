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
    public void CreateUrl_IncorrectPort_PortExp()
    {
        //Arrange
        HttpUrl url;
        string strUrl = @"http://google.com:/main.txt";

        //Act
        void action() => url = new( strUrl );


        //Assert
        Assert.Throws<UrlParsingError>( action );

    }

    [Fact]
    public void CreateUrl_HasNotPortSep_PortDefaultHttp()
    {
        //Arrange
        HttpUrl url;
        string strUrl = @"http://google.com/main.txt";

        //Act
        url = new( strUrl );


        //Assert
        Assert.Equal( strUrl, url.Url );
        Assert.Equal( 80, url.Port );
        Assert.Equal( Protocol.HTTP, url.Protocol );
        Assert.Equal( "google.com", url.Domain );
        Assert.Equal( "/main.txt", url.Document );

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
        Assert.Equal( "google.com", url.Domain );
        Assert.Equal( "/main.txt", url.Document );
        Assert.Equal( 80, url.Port );

    }

    [Fact]
    public void CreateUrl_WithoutDoc_ReturnCorrectUrl()
    {
        //Arrange
        string strUrl = @"http://google.com";

        //Act
        HttpUrl url = new( strUrl );

        //Assert
        Assert.Equal( strUrl, url.Url );
        Assert.Equal( Protocol.HTTP, url.Protocol );
        Assert.Equal( "google.com", url.Domain );
        Assert.Equal( "/", url.Document );
        Assert.Equal( 80, url.Port );
    }

    [Fact]
    public void CreateUrl_WithoutDocAndHaveSlash_ReturnCorrectUrl()
    {
        //Arrange
        string strUrl = @"http://google.com/";

        //Act
        HttpUrl url = new( strUrl );

        //Assert
        Assert.Equal( strUrl, url.Url );
        Assert.Equal( Protocol.HTTP, url.Protocol );
        Assert.Equal( "google.com", url.Domain );
        Assert.Equal( "/", url.Document );
        Assert.Equal( 80, url.Port );
    }

    [Fact]
    public void CreatHttpUrl_HavePort_WithoutDocAndHaveSlash_ReturnCorrectUrl()
    {
        //Arrange
        string strUrl = @"http://google.com:8012/";

        //Act
        HttpUrl url = new( strUrl );

        //Assert
        Assert.Equal( strUrl, url.Url );
        Assert.Equal( Protocol.HTTP, url.Protocol );
        Assert.Equal( "google.com", url.Domain );
        Assert.Equal( "/", url.Document );
        Assert.Equal( 8012, url.Port );
    }

    [Fact]
    public void CreateHttpsUrl_HavePort_WithoutDocAndHaveSlash_ReturnCorrectUrl()
    {
        //Arrange
        string strUrl = @"https://google.com:8012/";

        //Act
        HttpUrl url = new( strUrl );

        //Assert
        Assert.Equal( strUrl, url.Url );
        Assert.Equal( Protocol.HTTPS, url.Protocol );
        Assert.Equal( "google.com", url.Domain );
        Assert.Equal( "/", url.Document );
        Assert.Equal( 8012, url.Port );
    }

    [Fact]
    public void CreateCorrectHttpUrl()
    {
        //Arrange
        string strUrl = @"https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/get";

        //Act
        HttpUrl url = new( strUrl );

        //Assert
        Assert.Equal( strUrl, url.Url );
        Assert.Equal( Protocol.HTTPS, url.Protocol );
        Assert.Equal( "docs.microsoft.com", url.Domain );
        Assert.Equal( "/en-us/dotnet/csharp/language-reference/keywords/get", url.Document );
        Assert.Equal( 443, url.Port );
    }

    [Fact]
    public void CreateCorrectHttpUrl_UseDomainAndDoc()
    {
        //Arrange
        string domain = "domain";
        string doc = "doc";

        //Act
        HttpUrl url = new( domain, doc );

        //Assert
        Assert.Equal( "http://domain/doc", url.Url );
        Assert.Equal( Protocol.HTTP, url.Protocol );
        Assert.Equal( domain, url.Domain );
        Assert.Equal( $"/{doc}", url.Document );
        Assert.Equal( 80, url.Port );
    }

    [Fact]
    public void CreateCorrectHttpUrl_UseDomainAndDocAndPort()
    {
        //Arrange
        string domain = "domain";
        string doc = "doc";
        ushort port = 11;

        //Act
        HttpUrl url = new( domain, doc, Protocol.HTTPS, 11 );

        //Assert
        Assert.Equal( "https://domain:11/doc", url.Url );
        Assert.Equal( Protocol.HTTPS, url.Protocol );
        Assert.Equal( domain, url.Domain );
        Assert.Equal( $"/{doc}", url.Document );
        Assert.Equal( port, url.Port );
    }
}
