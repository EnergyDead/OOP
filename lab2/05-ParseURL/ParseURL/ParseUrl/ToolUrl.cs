using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseUrl
{
    public static class ToolUrl
    {
        public static bool ParseURL( string? urlValue, Url url )
        {
            if ( urlValue == null )
            {
                return false;
            }
            if ( !TryParseProtocol( urlValue, url ) )
            {
                return false;
            }
            if ( !TryParseHost( urlValue, url ) )
            {
                return false;
            }

            return true;
        }

        private static bool TryParseHost( string urlValue, Url url )
        {


            throw new NotImplementedException();
        }

        private static bool TryParseProtocol( string urlValue, Url url )
        {
            string separator = "://";
            string HTTP = "HTTP";
            string HTTPS = "HTTPS";
            string FTP = "FTP";

            // TODO: проверить - может без проверки будет работать
            if ( !urlValue.Contains( separator ) )
            {
                return false;
            }

            string protocol = urlValue[ ..urlValue.IndexOf( separator ) ];

            if ( protocol.ToUpper() == HTTP )
            {
                url.protocol = Protocol.HTTP;
                return true;
            }
            if ( protocol.ToUpper() == HTTPS )
            {
                url.protocol = Protocol.HTTPS;
                return true;
            }
            if ( protocol.ToUpper() == FTP )
            {
                url.protocol = Protocol.FTP;
                return true;
            }

            return false;
        }
    }
}
