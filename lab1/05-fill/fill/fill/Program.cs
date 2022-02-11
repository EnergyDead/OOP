using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace fill
{
    internal class Program
    {
        const int MaxSize = 99;
        static int Main( string[] args )
        {
            if ( args.Length != 2 )
            {
                Console.WriteLine( "Error arguments. Use: fill.exe <input file> <output file>" );

                return 1;
            }

            if ( !TryReadFile( args[ 0 ], out List<string> field ) )
            {
                Console.WriteLine( "Error. Can not fild Input file." );

                return 1;
            }

            char[,] fieldMatrix = ConvertToMatrix( field );
            Drow( fieldMatrix );

            if ( !TryWriteInFile( args[ 1 ], fieldMatrix ) )
            {
                Console.WriteLine( "Error. Can not fild Output file." );

                return 1;
            }            

            return 0;
        }

        private static bool TryWriteInFile( string fileName, char[,] fieldMatrix )
        {
            string outputFilePath = GetPath( fileName );
            if ( !File.Exists( outputFilePath ) )
            {
                return false;
            }
            WriteInFile( fieldMatrix, outputFilePath );

            return true;
        }

        private static bool TryReadFile( string fileName, out List<string> field )
        {
            string inputFilePath = GetPath( fileName );
            field = new List<string>();
            if ( !File.Exists( inputFilePath ) )
            {
                return false;
            }
            field = File.ReadAllLines( inputFilePath ).ToList();

            return true;
        }

        private static char[,] ConvertToMatrix( List<string> field )
        {
            int length = MaxSize; // Math.Min( 99, GetMaxLength( field ) );
            int height = MaxSize; // Math.Min( 99, field.Count );
            char[,] matrix = new char[ height, length ];

            for ( int i = 0; i < height; i++ )
            {
                for ( int j = 0; j < length; j++ )
                {
                    if ( i < field.Count && j < field[ i ].Length )
                    {
                        matrix[ i, j ] = field[ i ][ j ];
                    }
                    else
                    {
                        matrix[ i, j ] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static void Drow( char[,] fieldMatrix )
        {
            int width = fieldMatrix.GetLength( 0 );
            int height = fieldMatrix.GetLength( 1 );

            int wavelength = 0;
            bool isDorw;
            Point position = new() { x = 0, y = 0 };
            Point adjacent = new();
            do
            {
                isDorw = false;
                for ( position.y = 0; position.y < width; ++position.y )
                {
                    for ( position.x = 0; position.x < height; ++position.x )
                    {
                        if ( GetPointType( fieldMatrix[ position.y, position.x ] ) == PointType.startDrow
                          || GetPointType( fieldMatrix[ position.y, position.x ] ) == PointType.paintedOver )
                        {
                            for ( Direction direction = 0; direction <= Direction.up; direction++ )
                            {
                                SwitchDirection( direction, position, ref adjacent );

                                if ( IsNewPositionCorrect( adjacent, height, width ) && ( GetPointType( fieldMatrix[ adjacent.y, adjacent.x ] ) == PointType.blank ) )
                                {
                                    isDorw = true;
                                    fieldMatrix[ adjacent.y, adjacent.x ] = '.';
                                }
                            }
                        }

                    }
                }
                wavelength++;
            } while ( isDorw );
        }

        private static void WriteInFile( char[,] fieldMatrix, string pathToFile )
        {
            List<string> result = new();

            for ( int i = 0; i < fieldMatrix.GetLength( 0 ); i++ )
            {
                string line = string.Empty;
                for ( int j = 0; j < fieldMatrix.GetLength( 1 ); j++ )
                {
                    line += fieldMatrix[ i, j ].ToString();

                }
                result.Add( line );
            }

            File.WriteAllLines( pathToFile, result );
        }

        private static void SwitchDirection( Direction direction, Point position, ref Point adjacent )
        {
            switch ( direction )
            {
                case Direction.left:
                    adjacent.x = position.x - 1;
                    adjacent.y = position.y;
                    break;
                case Direction.right:
                    adjacent.x = position.x + 1;
                    adjacent.y = position.y;
                    break;
                case Direction.down:
                    adjacent.x = position.x;
                    adjacent.y = position.y - 1;
                    break;
                case Direction.up:
                    adjacent.x = position.x;
                    adjacent.y = position.y + 1;
                    break;
            }
        }

        static string GetPath( string fileName )
        {
            string pathToWorkDirectory = Directory.GetCurrentDirectory();
            string pathToProgram = Directory.GetParent( pathToWorkDirectory ).Parent.Parent.FullName;

            return Path.Combine( pathToProgram, fileName );
        }

        static PointType GetPointType( char point )
        {
            switch ( point )
            {
                case ' ':
                    return PointType.blank;
                case '.':
                    return PointType.paintedOver;
                case 'O':
                    return PointType.startDrow;
                default:
                    return PointType.fence;
            }
        }

        private static bool IsNewPositionCorrect( Point adjacent, int height, int width )
        {
            return adjacent.x >= 0 && adjacent.x < height && adjacent.y >= 0 && adjacent.y < width;
        }

        private static int GetMaxLength( List<string> field )
        {
            int maxLength = 0;
            foreach ( string line in field )
            {
                if ( maxLength < line.Length )
                    maxLength = line.Length;
            }
            return maxLength;
        }

        /// <summary>
        /// debug help function
        /// </summary>
        /// <param name="field"></param>
        private static void Print( string[,] field )
        {
            for ( int i = 0; i < field.GetLength( 0 ); i++ )
            {
                Console.WriteLine();
                for ( int j = 0; j < field.GetLength( 1 ); j++ )
                {
                    Console.Write( "{0}", field[ i, j ] );

                }
            }
        }
    }
    public enum PointType
    {
        blank = ' ',
        paintedOver = '.',
        startDrow = 'O',
        fence
    }

    public struct Point
    {
        public int x;
        public int y;
    }

    public enum Direction
    {
        left,
        right,
        down,
        up
    }
}