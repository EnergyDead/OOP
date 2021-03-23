using System;

namespace RemoveExtraSpaces
{
    public class Program
    {
        public static int Main( string[] args )
        {
            string arg = args[ 0 ].Trim();
            Console.WriteLine( RemoveExtraSpaces( arg ) );

            return 0;
        }

        public static string RemoveExtraSpaces( string arg )
        {
            while ( arg.Contains( "  " ) ) 
            {
                arg = arg.Replace( "  ", " " );
            }

            return arg;
        }
    }
}
