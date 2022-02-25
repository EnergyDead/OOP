using System;
using System.Text;

namespace HtmlDecode
{
    public class Program
    {
        static void Main( string[] args )
        {
            StringBuilder inputUrl = new StringBuilder( Console.ReadLine() );

            HtmlDecode( inputUrl );

            Console.WriteLine( inputUrl.ToString() );
        }

        public static void HtmlDecode( StringBuilder inputUrl )
        {
            inputUrl.Replace( "&quot;", "\"" );
            inputUrl.Replace( "&apos;", "'" );
            inputUrl.Replace( "&lt;", "<" );
            inputUrl.Replace( "&gt;", ">" );
            inputUrl.Replace( "&amp;", "&" );
        }
    }
}
