using System;
using System.Text;

namespace HtmlDecode
{
    public class HtmlDecoder
    {
        static void Main()
        {
            string resultUrl = HtmlDecode( Console.ReadLine() );

            Console.WriteLine( resultUrl );
        }

        public static string HtmlDecode( string inputUrl )
        {
            StringBuilder resultUrl = new( inputUrl );
            resultUrl.Replace( "&quot;", "\"" );
            resultUrl.Replace( "&apos;", "'" );
            resultUrl.Replace( "&lt;", "<" );
            resultUrl.Replace( "&gt;", ">" );
            resultUrl.Replace( "&amp;", "&" ); // &amp;lt;

            return resultUrl.ToString();
        }
    }
}
