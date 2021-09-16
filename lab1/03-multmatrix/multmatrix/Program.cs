using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace multmatrix
{
    class Program
    {
        private struct Multiply
        {
            public double[][] firstMatrix;
            public double[][] secondMatrix;            
        }

        static int Main(string[] args)
        {
            if ( args.Length != 3 )
            {
                Console.WriteLine( "Invalid arguments count" );
                Console.WriteLine( "Uasge: multmatrix.exe <matrix file1> <matrix file2>" );    

                return 1;
            }

            Multiply multiplyArg;

            try
            {
                multiplyArg.firstMatrix = ReadMatrix( args[0] );
                multiplyArg.secondMatrix = ReadMatrix( args[1] );
            }
            catch ( Exception error )
            {
                Console.WriteLine( error.Message );
                
                return 1;
            }

            string resault = MultiplyMatrix( multiplyArg );

            Console.WriteLine( resault );
            File.WriteAllText( args[2], resault );

            return 0;
        }

        static double[][] ReadMatrix( string pathToMatrix )
        {
            string matrix = File.ReadAllText( pathToMatrix );
            double[][] resultMatrix = new double[3][];
            int i = 0;
            matrix = DeleteSpasceInMatrix( matrix );
            foreach ( string row in matrix.Trim().Split( '\n' ) )
            {
                resultMatrix[i] = row.Trim().Split( ' ' ).Select( Convert.ToDouble ).ToArray();
                i++;
            }

            return resultMatrix;
        }

        static string MultiplyMatrix( Multiply multiplyArg )
        {
            double[][] resultMatrix = new double[3][];
            for (int i = 0; i < 3; ++i)
            {
                resultMatrix[i] = new double[3];
            }

            Parallel.For(0, multiplyArg.firstMatrix.Length, i =>
            {
                for (int j = 0; j < 3; ++j)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        resultMatrix[i][j] += multiplyArg.firstMatrix[i][k] * multiplyArg.secondMatrix[k][j];
                    }
                }
            });

            return MatrixAsString(resultMatrix);
        }

        static string MatrixAsString( double[][] matrix )
        {
            string result = String.Empty;
            for ( int i = 0; i < matrix.Length; ++i )
            {
                for ( int j = 0; j < matrix[ i ].Length; ++j )
                {
                    result += matrix[i][j].ToString( "F3" ).PadLeft(8) + " ";
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
