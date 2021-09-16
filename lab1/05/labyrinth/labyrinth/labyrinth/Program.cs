using System;
using System.Collections.Generic;
using System.Linq;

namespace labyrinth
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine(Digitize( 35231) );

            return 0;
        }

        public static long[] Digitize(long n)
        {
            Console.WriteLine(n);
            long[] result = new long[n.ToString().Length];
            for (int i = 0; i < n.ToString().Length; i++ )
            {
                result[ i ] = n % 10;
                n %= 10;
            }
            return result;
        }

    }

    public class User
    {
        private int _progress;
        public int progress
        {
            get
            {
                return _progress % 100;
            }
        }

        public int rank
        {
            get
            {
                int _rank = (_progress / 100) - 8;
                if (_rank >= 0)
                {
                    _rank++;
                }
                return _rank;
            }
        }

        public User()
        {
            _progress = 800;
        }

        public void incProgress(int rankTask)
        {
            int difference = rankTask - rank;
            if (difference == -1)
            {
                difference = 1;
            }

            if (difference == 0)
            {
                difference++;
            }

            if (difference > 0)
            {
                _progress += 10 * difference * difference;
            }
        }

    }
}
