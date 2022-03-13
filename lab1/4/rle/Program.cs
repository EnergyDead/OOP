using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rle
{
    class Program
    {
        const string inputFileName = "binary";
        const string outputFileName = "binaryOutput";
        const string outputFileName2 = "binaryOutput1";

        static void Main( string[] args )
        {
            var input = File.ReadAllBytes( inputFileName );

            var result = Compressitive( input );
            var decodeResault = Decode( result );

            File.WriteAllBytes( outputFileName, result );
            File.WriteAllBytes( outputFileName2, decodeResault );

            Debug( input, decodeResault );
        }

        static byte[] Decode( byte[] input )
        {
            List<byte> result = new();

            for ( int i = 0; i <= input.Length - 2; i += 2 )
            {
                for ( int j = 0; j < input[ i ]; j++ )
                {
                    result.Add( input[ i + 1 ] );
                }

            }

            return result.ToArray();
        }

        static byte[] Compressitive( byte[] input )
        {
            byte temp;
            int countByte = 1;
            List<byte> result = new();
            temp = input[ 0 ];
            for ( int i = 1; i < input.Length; i++ )
            {
                if ( temp == input[ i ] )
                {
                    countByte++;
                    continue;
                }
                while ( countByte > byte.MaxValue )
                {
                    AddPair( result, byte.Parse( byte.MaxValue.ToString() ), temp );
                    countByte -= byte.MaxValue;
                }
                AddPair( result, byte.Parse( countByte.ToString() ), temp );
                temp = input[ i ];
                countByte = 1;
            }
            AddPair( result, byte.Parse( countByte.ToString() ), temp );

            return result.ToArray();
        }

        static void AddPair( List<byte> value, byte count, byte ch )
        {
            value.Add( count );
            value.Add( ch );
        }

        static void Debug( byte[] first, byte[] second )
        {
            for ( int i = 0; i < first.Length; i++ )
            {
                if ( second[ i ] != first[ i ] )
                {
                    Console.WriteLine( $"not corrct {i}, dec = {second[ i ]} and in = {first[ i ]}" );
                }
            }
        }
    }
}
