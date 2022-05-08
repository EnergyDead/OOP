namespace MyHttpUrl;

public class HttpUrl
{
    private readonly ushort _defaultHttpPort = 80;
    private readonly ushort _defaultHttpsPort = 443;
    private readonly string separatorScheme = "://";
    private readonly char portSeparator = ':';
    private readonly char slash = '/';

    public string Url
    {
        get
        {
            return ToString();
        }
    }

    public Protocol Protocol { get; private set; }

    public string Domain { get; private set; }

    public ushort Port { get; private set; }

    private string _document;
    public string Document
    {
        get
        {
            return _document == string.Empty ? slash.ToString() : _document;
        }
    }

    public override string ToString()
    {
        string url = $"{Protocol.ToString().ToLower()}://{Domain}";
        if ( Port != _defaultHttpPort && Port != _defaultHttpsPort )
        {
            url += $":{Port}";
        }
        if ( _document != string.Empty )
        {
            url += $"{_document}";
        }
        return url;
    }


    public HttpUrl( string strUrl )
    {
        if ( string.IsNullOrEmpty( strUrl ) )
        {
            throw new UrlParsingError( "Input has not null or empty." );
        }

        if ( !strUrl.Contains( separatorScheme ) )
        {
            throw new UrlParsingError( "Incorrect url." );
        }

        InitUrl( strUrl.Trim() );
    }

    public HttpUrl( string domain, string document, Protocol protocol = Protocol.HTTP )
    {
        if ( string.IsNullOrEmpty( domain ) )
        {
            throw new UrlParsingError( "Incorrect domain." );
        }
        if ( string.IsNullOrEmpty( document ) || document.Trim()[0] != slash )
        {
            document = $"/{document}";
        }

        Domain = domain.Trim();
        _document = document.Trim();
        Protocol = protocol;
        Port = GetPort(protocol);
    }

    public HttpUrl( string domain, string document, Protocol protocol, ushort port )
    {
        if ( string.IsNullOrEmpty( domain ) )
        {
            throw new UrlParsingError( "Incorrect domain." );
        }
        if ( string.IsNullOrEmpty( document ) || document.Trim()[ 0 ] != slash )
        {
            document = $"/{document}";
        }

        Domain = domain.Trim();
        _document = document.Trim();
        Protocol = protocol;
        Port = port;
    }

    private void InitUrl( string strUrl )
    {
        Protocol protocol = GetProtocol( strUrl );
        ushort port = GetPort( strUrl );
        string domain = GetDomein( strUrl );
        string document = GetDocument( strUrl );

        Domain = domain;
        _document = document;
        Protocol = protocol;
        Port = port;
    }

    private string GetDocument( string strUrl )
    {
        string shortUri = GetShortUri( strUrl );
        if ( shortUri.Contains( slash ) )
        {
            int startDoc = shortUri.IndexOf( slash );
            return shortUri[ startDoc.. ];
        }
        return string.Empty;
    }

    private ushort GetPort( string strUrl )
    {
        string authority = GetAuthority( strUrl );

        if ( !authority.Contains( portSeparator ) )
        {
            return GetProtocol( strUrl ) switch
            {
                Protocol.HTTP => _defaultHttpPort,
                Protocol.HTTPS => _defaultHttpsPort,
                _ => throw new UrlParsingError( "Incorrect port." ),
            };
        }

        string strPort = authority.Split( portSeparator )[ 1 ];
        if ( ushort.TryParse( strPort, out ushort port ) )
        {
            return port;
        }
        else
        {
            throw new UrlParsingError( "Incorrect port." );
        }
    }

    private ushort GetPort(Protocol protocol)
    {
        return protocol switch
        {
            Protocol.HTTP => _defaultHttpPort,
            Protocol.HTTPS => _defaultHttpsPort,
            _ => throw new UrlParsingError( "Incorrect port." ),
        };
    }

    private Protocol GetProtocol( string strUrl )
    {
        string protocol = strUrl[ ..strUrl.IndexOf( separatorScheme ) ].ToLower();

        return protocol switch
        {
            "http" => Protocol.HTTP,
            "https" => Protocol.HTTPS,
            _ => throw new UrlParsingError( "Incorrect protocol." ),
        };
    }

    private string GetDomein( string strUrl )
    {
        string authority = GetAuthority( strUrl );
        if ( authority.Contains( portSeparator ) )
        {
            return authority[ ..authority.IndexOf( portSeparator ) ];
        }
        return authority;
    }

    private string GetShortUri( string strUrl )
    {
        int startAuthority = strUrl.IndexOf( separatorScheme ) + separatorScheme.Length;
        return strUrl[ startAuthority.. ];
    }

    private string GetAuthority( string strUrl )
    {
        string shortUri = GetShortUri( strUrl );

        if ( shortUri.Contains( slash ) )
        {
            return shortUri.Split( slash )[ 0 ];
        }
        return shortUri;
    }

    private string GetUrlWithoutDefaultPort( string strUrl )
    {
        return strUrl;
    }
}
