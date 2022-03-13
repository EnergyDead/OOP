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
        public void IncorrectHTTPInput_HasErrorPort()
        {
            string input = "http://www.mysite.com:ErrorPort/docs/document1.html?page=30&lang=en#title";
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.False( result );
        }

        [Fact]
        public void CorrectHTTPInput_HasPort()
        {
            string input = "http://www.mysite.com:3232/docs/document1.html?page=30&lang=en#title";
            string host = "www.mysite.com";
            string doc = "docs/document1.html?page=30&lang=en#title";
            int port = 3232;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectHTTPInput_HasPort_HasNotDoc()
        {
            string input = "http://www.mysite.com:3232";
            string host = "www.mysite.com";
            string doc = "";
            int port = 3232;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );
             
            Assert.True( result );
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectHTTPInput_HasNotPort_HasNotDoc()
        {
            string input = "http://www.mysite.com";
            string host = "www.mysite.com";
            string doc = "";
            int port = 80;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectHTTPInput_HasNotPort()
        {
            string input = "http://www.mysite.com/docs/document1.html?page=30&lang=en#title";
            string host = "www.mysite.com";
            string doc = "docs/document1.html?page=30&lang=en#title";
            int port = 80;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectHTTPSInput_HasPort()
        {
            string input = "https://www.mysite.com:444/docs/document1.html?page=30&lang=en#title";
            string host = "www.mysite.com";
            string doc = "docs/document1.html?page=30&lang=en#title";
            int port = 444;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectHTTPSInput_HasNotPort()
        {
            string input = "https://www.mysite.com/docs/document1.html?page=30&lang=en#title";
            string host = "www.mysite.com";
            string doc = "docs/document1.html?page=30&lang=en#title";
            int port = 443;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectFTPInput_HasPasswordAndLogin_HasPort()
        {
            string input = "ftp://login:pass@serv.example.com:21/function/reg.php";
            string host = "serv.example.com";
            string doc = "function/reg.php";
            int port = 21;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.FTP, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectFTPInput_HasNotPasswordAndLogin_HasPort()
        {
            string input = "ftp://serv.example.com:21/function/reg.php";
            string host = "serv.example.com";
            string doc = "function/reg.php";
            int port = 21;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.FTP, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }

        [Fact]
        public void CorrectFTPInput_HasNotPasswordAndLogin_HasNotPort()
        {
            string input = "ftp://serv.example.com/function/reg.php";
            string host = "serv.example.com";
            string doc = "function/reg.php";
            int port = 21;
            Url url = new();

            bool result = ToolUrl.ParseURL( input, url );

            Assert.True( result );
            Assert.Equal( Protocol.FTP, url.Protocol );
            Assert.Equal( host, url.Host );
            Assert.Equal( port, url.Port );
            Assert.Equal( doc, url.Document );
        }
    }
}