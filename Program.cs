using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
namespace Scratch
{
    class Program
    {
        class MonteCarlo
        {

            static Random rnd;
            public static void Main()
            {
                int x = EulerLib.Primes.
                double range = 0.15;
                double high = 0.5 + range;
                double low = 0.5 - range;

                rnd = new Random();
                int correct = 0;
                int tries = 10000000;
                for (int i = 0; i < tries; i++)
                {
                    var r = Flip(100);
                    if (r > low && r < high)
                    {

                        correct++;
                    }
                }
                Console.WriteLine((double)correct/(double)(tries));

            }
            static double Flip(int times = 25)
            {
                var heads = Enumerable.Range(0, times).Select(z => rnd.NextDouble() > 0.5).Where(e => e).Count();
                return (double)heads / (double)times;
            }
        }
        class OutputObj
        {
            public string stock = "";
            public string location;
            public string size;
            public string companyName;
            public string fullName;
            public string[][] pipelineDetails;
        }

        static int[][] squares = 
        {
            new int[] { 0, 1 },
            new int[] { 0, 4 },
            new int[] { 0, 9 },
            new int[] { 1, 6 },
            new int[] { 2, 5 },
            new int[] { 3, 6 },
            new int[] { 4, 9 },
            new int[] { 6, 4 },
            new int[] { 8, 1 },

        };
        public static dec Add6And9 (dec i)
        {
            dec six =  0b0000100000;
            dec nine = 0b0100000000;
            if ((i | six) == i || (i | nine) == i)
            {
                i = i | six;
                i = i | nine;
            }
            return i;
        }
        public static bool HasBoth(dec a, dec b)
        {
             dec[][] sqrs =
    squares.Select(e => e.Select(z => IntToDecPos(z)).ToArray()).ToArray();

            a = Add6And9(a);
            b = Add6And9(b);
            foreach (dec[] d in sqrs)
            {
                if ((a | d[0]) == a && (b | d[1]) == b){
                    continue;
                }
                if ((b | d[0]) == b && (a | d[1]) == a)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public static void Runs()
        {

            var diceA = Permute(10, 6);
            var diceB= Permute(10, 6);
            int count = 0;
            foreach (var a in diceA)
            {
                foreach (var b in diceB)
                {
                    if (HasBoth(a, b)) count++;
                }
            }
            Console.WriteLine(count);
        }
        static string ToDec(int i) { return System.Convert.ToString(i, 2); }
        static dec IntToDecPos(int i)
        {
            if (i == 0) i = 10;
            return 1 << (i-1);
        }
        //
        //places is the size of the array
        // fills is the number of recursions
        public static HashSet<dec> Permute(int places, int fills, HashSet<dec> set = null, int basis=0)
        {
            if (set == null) set = new HashSet<dec>();
            //if places = 4 & fills = 1
            //1000 0100 0010 0001
            //if places = 3 & fills = 2
            //110 101 011
            for (int i = places-1; i >= 0; i--)
            {
                if (((1 << i) | basis)==basis) continue;
                dec newVal = basis + (1 << i);
                if (fills == 1)
                {
                    set.Add(newVal);
                }
                else
                {
                    Permute(places-1, fills - 1, set, newVal);
                }
            }
            return set;
        }
    }
    public struct dec
    {
        public int val;
        public static implicit operator dec (int i)
        {
            return new dec() { val = i };
        }
        public static implicit operator int (dec i)
        {
            return i.val;
        }
        public override string ToString()
        {
            return System.Convert.ToString(this.val, 2);
        }
    }
}
