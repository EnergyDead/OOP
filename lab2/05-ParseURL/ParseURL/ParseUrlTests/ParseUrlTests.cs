using Xunit;
using ParseUrl;

namespace ParseUrlTests
{
    public class ParseUrlTests
    {
        [Fact]
        public void EmptyInput()
        {
            Url url = new();

            bool result = ToolUrl.ParseURL( string.Empty, url );

            Assert.False( result );
        }

        [Fact]
        public void ErrorInput()
        {
            string input = "error string";
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.False( result );
        }

        [Fact]
        public void CorrectHTTPInput()
        {
            string input = "http://www.mysite.com/docs/document1.html?page=30&lang=en#title";
            string host = "www.mysite.com";
            string doc = "docs/document1.html?page=30&lang=en#title1";
            int port = 80;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.HTTP, url.protocol );
            Assert.Equal( host, url.host );
            Assert.Equal( port, url.port );
            Assert.Equal( doc, url.document );
        }

        [Fact]
        public void CorrectHTTPSInput()
        {
            string input = "https://www.mysite.com/docs/document1.html?page=30&lang=en#title";
            string host = "www.mysite.com";
            string doc = "docs/document1.html?page=30&lang=en#title1";
            int port = 443;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.HTTPS, url.protocol );
            Assert.Equal( host, url.host );
            Assert.Equal( port, url.port );
            Assert.Equal( doc, url.document );
        }

        [Fact]
        public void CorrectFTPInput()
        {
            string input = "ftp://login:pass@serv.example.com:21/function/reg.php";
            string host = "serv.example.com";
            string doc = "function/reg.php";
            int port = 21;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.FTP, url.protocol );
            Assert.Equal( host, url.host );
            Assert.Equal( port, url.port );
            Assert.Equal( doc, url.document );
        }
    }
}