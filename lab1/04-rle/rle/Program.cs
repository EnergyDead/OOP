using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace rle
{
    class Program
    {
        const string pack = "pack";
        const string unpack = "unpack";

        static int Main( string[] args )
        {
            if ( args.Length != 3 )
            {
                Console.WriteLine( "Invalid input format. Use rle.exe <parameter> <inputFile> <outputFile>" );

                return 1;
            }

            string typeWork = args[ 0 ];
            string inputFileName = args[ 1 ];
            string outputFileName = args[ 2 ];

            if ( !File.Exists( args[ 1 ] ) )
            {
                Console.WriteLine( "Error. Input file exist." );

                return 1;
            }
            byte[] input = File.ReadAllBytes( inputFileName );

            if ( input.Length == 0 )
            {
                return 0;
            }

            byte[] result;

            switch ( typeWork )
            {
                case pack:
                    result = Compressitive( input );
                    break;
                case unpack:
                    result = Decode( input );
                    break;
                default:
                    Console.WriteLine( "Error. Unknown argument." );

                    return 1;
            }

            if ( !File.Exists( outputFileName ) )
            {
                Console.WriteLine( "Error. Output file exist." );

                return 1;
            }
            if ( result != null )
            {
                File.WriteAllBytes( outputFileName, result );
            }

            return 0;
        }

        static byte[] Decode( byte[] value )
        {
            if ( value.Length == 0 )
            {
                return null;
            }

            List<byte> result = new();
            for ( int i = 0; i <= value.Length - 2; i += 2 )
            {
                var enumerable = Enumerable.Repeat( value[ i + 1 ], value[ i ] );
                result.AddRange( enumerable );
            }

            return result.ToArray();
        }

        static byte[] Compressitive( byte[] value )
        {
            if ( value.Length == 0 )
            {
                return null;
            }

            byte ch = value[ 0 ];
            int countByte = 1;
            List<byte> result = new();
            for ( int i = 1; i < value.Length; i++ )
            {
                if ( ch == value[ i ] )
                {
                    countByte++;
                    continue;
                }
                AddRange( result, ch, ref countByte );
                ch = value[ i ];
                countByte = 1;
            }
            AddRange( result, ch, ref countByte );

            return result.ToArray();
        }

        static void AddRange( List<byte> value, byte ch, ref int count )
        {
            while ( count > byte.MaxValue )
            {
                AddPair( value, Convert.ToByte( byte.MaxValue ), ch );
                count -= byte.MaxValue;
            }
            AddPair( value, Convert.ToByte( count ), ch );
        }
        static void AddPair( List<byte> value, byte first, byte second )
        {
            value.Add( first );
            value.Add( second );
        }
    }
}