namespace MyHttpUrl;

public class UrlParsingError : ArgumentException
{
    public UrlParsingError( string message ) : base( message )
    {
    }
}
