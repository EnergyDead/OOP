namespace ParseUrl
{
    public static class ToolUrl
    {
        readonly static char EndPassword = '@';
        readonly static char SeparatorLoginAndPassword = ':';
        readonly static char Separator = '/';

        readonly static int DefaultPortFTP = 21;
        readonly static int DefaultPortHTTP = 80;
        readonly static int DefaultPortHTTPS = 443;

        public static bool ParseURL( string? urlValue, Url url )
        {
            if ( urlValue == null )
            {
                return false;
            }
            if ( !TryParseProtocol( ref urlValue, url ) )
            {
                return false;
            }
            // разделить All
            if ( !TryParseAll( urlValue, url ) )
            {
                return false;
            }

            return true;
        }

        private static bool TryParseAll( string urlValue, Url url )
        {

            if ( url.Protocol == Protocol.FTP )
            {
                RemoveLoginAndPassword( ref urlValue );
            }
            bool hasDoc = urlValue.Contains( Separator );
            bool hasPort = urlValue.Contains( SeparatorLoginAndPassword );
            
            // не нужно hasDoc и hasPort
            url.Host = GetHost( urlValue, hasDoc, hasPort );

            // не нужно hasDoc и hasPort
            if ( !TryParsePort( url, urlValue, hasDoc, hasPort ) )
            {
                return false;
            }

            // вынести проверку на hasDoc
            url.Document = hasDoc ? GetDocument( urlValue, hasDoc ) : string.Empty;

            return true;
        }

        private static bool TryParsePort( Url url, string urlValue, bool hasDoc, bool hasPort )
        {
            if ( !hasPort )
            {
                if ( url.Protocol == Protocol.FTP )
                {
                    url.Port = DefaultPortFTP;
                    return true;
                }
                if ( url.Protocol == Protocol.HTTP )
                {
                    url.Port = DefaultPortHTTP;
                    return true;
                }
                if ( url.Protocol == Protocol.HTTPS )
                {
                    url.Port = DefaultPortHTTPS;
                    return true;
                }
            }
            string portStr;
            if ( hasDoc )
            {
                portStr = urlValue[ GetStartParseIndex( urlValue, SeparatorLoginAndPassword )..urlValue.IndexOf( Separator ) ];
            }
            else
            {
                portStr = urlValue[ GetStartParseIndex( urlValue, SeparatorLoginAndPassword ).. ];
            } 

            if ( !int.TryParse( portStr, out int port ) )
            {
                return false;
            }

            url.Port = port;
            return true;
        }

        private static string GetHost( string urlValue, bool hasDoc, bool hasPort )
        {
            if ( hasPort )
            {
                return urlValue[ ..urlValue.IndexOf( SeparatorLoginAndPassword ) ];
            }
            else if ( hasDoc )
            {
                return urlValue[ ..urlValue.IndexOf( Separator ) ];
            }
            else
            {
                return urlValue;
            }
        }

        private static bool TryParseProtocol( ref string urlValue, Url url )
        {
            string separator = "://";
            string HTTP = "HTTP";
            string HTTPS = "HTTPS";
            string FTP = "FTP";

            if ( !urlValue.Contains( separator ) )
            {
                return false;
            }

            string protocol = urlValue[ ..urlValue.IndexOf( separator ) ];

            urlValue = urlValue[ GetStartParseIndex( urlValue, separator ).. ];

            if ( protocol.ToUpper() == HTTP )
            {
                url.Protocol = Protocol.HTTP;
                return true;
            }
            if ( protocol.ToUpper() == HTTPS )
            {
                url.Protocol = Protocol.HTTPS;
                return true;
            }
            if ( protocol.ToUpper() == FTP )
            {
                url.Protocol = Protocol.FTP;
                return true;
            }

            return false;
        }

        private static void RemoveLoginAndPassword( ref string urlValue )
        {
            bool hasLoginAndPassword = urlValue.Contains( EndPassword ) && urlValue.LastIndexOf( EndPassword ) < urlValue.IndexOf( Separator );
            if ( hasLoginAndPassword )
            {
                urlValue = urlValue[ GetStartParseIndex( urlValue, EndPassword ).. ];
            }
        }

        private static string GetDocument( string urlValue, bool hasDoc )
        {
            return hasDoc ? urlValue[ GetStartParseIndex( urlValue, Separator ).. ] : string.Empty;
        }

        private static int GetStartParseIndex( string urlValue, string separator )
        {
            return urlValue.IndexOf( separator, StringComparison.OrdinalIgnoreCase ) + separator.Length;
        }

        private static int GetStartParseIndex( string urlValue, char separator )
        {
            int charLength = 1;
            return urlValue.IndexOf( separator, StringComparison.OrdinalIgnoreCase ) + charLength;
        }
    }
}
