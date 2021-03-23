using System;
using System.Linq;

namespace calcbits
{
    class Program
    {
        public static int Main(string[] args)
        {
            if ( args.Length == 0 )
            {
                Console.WriteLine( "Not found argument" );

                return 1;
            }

            int nubmer = Convert.ToInt32(args[ 0 ]);
            Console.WriteLine( Convert.ToString( nubmer, 2 ).Count( ch => ch == '1' ) );

            return 0;
        }
    }
}
