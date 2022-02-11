using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace multmatrix
{
    class Program
    {
        static int Main( string[] args )
        {
            if ( args.Length < 2 )
            {
                Console.WriteLine( "Invalid arguments count" );
                Console.WriteLine( "Uasge: multmatrix.exe <matrix file1> <matrix file2>" );

                return 1;
            }

            decimal[][] firstMatrix, secondMatrix;

            try
            {
                firstMatrix = ReadMatrix( args[ 0 ] );
                secondMatrix = ReadMatrix( args[ 1 ] );
            }
            catch ( Exception error )
            {
                Console.WriteLine( error.Message );

                return 1;
            }

            string resault = MultiplyMatrix( firstMatrix, secondMatrix );

            Console.WriteLine( resault );

            // with autotests
            if ( args.Length == 3 ) 
            {
                File.WriteAllText( args[ 2 ], resault );
            }

            return 0;
        }

        static decimal[][] ReadMatrix( string fileName )
        {
            var numberStyles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var provider = new CultureInfo( "en-US" );

            decimal[][] resultMatrix = new decimal[ 3 ][];

            string matrix = ReadFile( fileName );
            matrix = DeleteSpasceInMatrix( matrix );

            int i = 0;
            foreach ( string row in matrix.Trim().Split( "\r\n" ) )
            {
                resultMatrix[ i ] = row.Trim().Split( ' ' ).Select( value => Decimal.Parse( value, numberStyles, provider ) ).ToArray();
                i++;
            }

            return resultMatrix;
        }

        static string MultiplyMatrix( decimal[][] firstMatrix, decimal[][] secondMatrix )
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
                        resultMatrix[ i ][ j ] = resultMatrix[ i ][ j ] + firstMatrix[ i ][ k ] * secondMatrix[ k ][ j ];
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

        static string ReadFile( string fileName )
        {
            string pathToWorkDirectory = Directory.GetCurrentDirectory();
            string pathToProgram = Directory.GetParent( pathToWorkDirectory ).Parent.Parent.FullName;
            string inputFilePath = Path.Combine( pathToProgram, fileName );

            return File.ReadAllText( inputFilePath );
        }
    }
}
