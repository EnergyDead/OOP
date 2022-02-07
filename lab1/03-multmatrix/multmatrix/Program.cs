using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace multmatrix
{
    class Program
    {
        private struct Multiply
        {
            public decimal[][] firstMatrix;
            public decimal[][] secondMatrix;
        }

        static int Main( string[] args )
        {
            if ( args.Length < 2 )
            {
                Console.WriteLine( "Invalid arguments count" );
                Console.WriteLine( "Uasge: multmatrix.exe <matrix file1> <matrix file2>" );

                return 1;
            }

            Multiply multiplyArg;

            try
            {
                multiplyArg.firstMatrix = ReadMatrix( args[ 0 ] );
                multiplyArg.secondMatrix = ReadMatrix( args[ 1 ] );
            }
            catch ( Exception error )
            {
                Console.WriteLine( error.Message );

                return 1;
            }

            string resault = MultiplyMatrix( multiplyArg );

            Console.WriteLine( resault );

            if ( args.Length == 3 )
            {
                File.WriteAllText( args[ 2 ], resault );
            }

            return 0;
        }

        static decimal[][] ReadMatrix( string pathToMatrix )
        {
            var numberStyles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var provider = new CultureInfo( "en-US" );
            decimal[][] resultMatrix = new decimal[ 3 ][];

            string matrix = File.ReadAllText( pathToMatrix );
            matrix = DeleteSpasceInMatrix( matrix );

            int i = 0;
            foreach ( string row in matrix.Trim().Split( "\r\n" ) )
            {
                resultMatrix[ i ] = row.Trim().Split( ' ' ).Select( value => Decimal.Parse( value, numberStyles, provider ) ).ToArray();
                i++;
            }

            return resultMatrix;
        }

        static string MultiplyMatrix( Multiply multiplyArg )
        {
            decimal[][] resultMatrix = new decimal[ 3 ][];
            for ( int i = 0; i < 3; ++i )
            {
                resultMatrix[ i ] = new decimal[ 3 ];
            }

            for ( int i = 0; i < 3; i++ )
            {
                for ( int j = 0; j < 3; j++ )
                {
                    resultMatrix[ i ][ j ] = 0;
                    for ( int k = 0; k < 3; k++ )
                    {
                        resultMatrix[ i ][ j ] = resultMatrix[ i ][ j ] + multiplyArg.firstMatrix[ i ][ k ] * multiplyArg.secondMatrix[ k ][ j ];
                    }
                }
            }

            return MatrixAsString( resultMatrix );
        }

        static string MatrixAsString( decimal[][] matrix )
        {
            string result = String.Empty;
            for ( int i = 0; i < matrix.Length; ++i )
            {
                for ( int j = 0; j < matrix[ i ].Length; ++j )
                {
                    result += matrix[ i ][ j ].ToString( "F3" ).PadLeft( 9 );
                }
                result += Environment.NewLine;
            }

            return result;
        }

        static string DeleteSpasceInMatrix( string matrix )
        {
            while ( matrix.Contains( "  " ) )
            {
                matrix = matrix.Replace( "  ", " " );
            }

            return matrix;
        }
    }
}
