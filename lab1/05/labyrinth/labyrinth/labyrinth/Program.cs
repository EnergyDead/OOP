using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace labyrinth
{
    class Program
    {
        public enum TypeField
        {
            wall = '#',
            road = '.',
            empty = ' ',
            start = 'B',
            finish = 'A',
            error
        }

        public struct Point
        {
            public int x;
            public int y;
            public char type;

            public Point( int x, int y, char type )
            {
                this.x = x;
                this.y = y;
                this.type = type;
            }
        }

        static int Main( string[] args )
        {
            if ( args.Length < 1 || args.Length > 2 )
            {
                Console.WriteLine( "Error arguments. Use: labyrinth.exe <input file> <output file>" );

                return 1;
            }

            string inputDate = File.ReadAllText( args[ 0 ] );

            List<string> field = inputDate.Split( '\n' ).ToList();

            if ( field.Select( r => r.Length ).Select( c => c > 100 ).Contains( true ) || field.Count() > 100 )
            {
                Console.WriteLine( "Error input size. Max 100*100." );
            }


            if ( inputDate.Where( ch => ch == 'A' ).Count() != 1 || inputDate.Where( ch => ch == 'B' ).Count() != 1 )
            {
                Console.WriteLine( "Error count Start or Finish position." );

                return 0;
            }

            List<Point> points = new List<Point>();
            for ( int rowNumber = 0; rowNumber < field.Count; rowNumber++ )
            {
                for ( int columnNumber = 0; columnNumber < field[ rowNumber ].Length; columnNumber++ )
                {
                    points.Add( new Point( columnNumber, rowNumber, '#' ) );
                }
                points.Add( new Point( field[ rowNumber ].Length, rowNumber, '#' ) );
            }

            var input = "";

            foreach ( var r in points )
            {
                input += r.type;
            }
            string[] output = input.Split( '\r' );
            foreach ( var s in output )
            {
                Console.WriteLine( s );
            }

            return 0;
        }
    }
}
