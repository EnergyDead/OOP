namespace MyHttpUrl;

public class HttpUrl
{
    private readonly string separator = "://";

    public string Url { get; private set; }
    public string Domain { get; private set; }
    public string Document { get; private set; }
    public Protocol Protocol { get; private set; }
    public ushort Port { get; private set; }


    public HttpUrl( string strUrl )
    {
        if ( string.IsNullOrEmpty( strUrl ) )
        {
            throw new UrlParsingError( "Input has not null or empty." );
        }

        InitUrl( strUrl );
    }

    private void InitUrl( string strUrl )
    {
        Protocol protocol = GetProtocol( strUrl );
        string domain = GetDomein( strUrl );
        string document = GetDocument( strUrl );
        ushort port = GetPort( strUrl );

        Url = strUrl;
        Domain = domain;
        Document = document;
        Protocol = protocol;
        Port = port;
    }

    private string GetDocument( string strUrl )
    {
        throw new NotImplementedException();
    }

    private ushort GetPort( string strUrl )
    {
        throw new NotImplementedException();
    }

    private Protocol GetProtocol( string strUrl )
    {
        if ( !strUrl.Contains( separator ) )
        {
            throw new UrlParsingError( "Incorrect protocol." );
        }

        string protocol = strUrl[ ..strUrl.IndexOf( separator ) ].ToLower();

        return protocol switch
        {
            "http" => Protocol.HTTP,
            "https" => Protocol.HTTPS,
            _ => throw new UrlParsingError( "Incorrect protocol." ),
        };
    }

    private string GetDomein( string strUrl )
    {
        throw new NotImplementedException();
    }
}
