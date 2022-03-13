namespace MyApp
{
    public class Program
    {
        public static bool isSimple(long num)
        {
            if (num == 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static long nSimple(long n)
        {
            int i = 0, nuber = 0;
            while (i < n)
            {
                nuber++;
                i += Convert.ToInt32(isSimple(nuber));
            }
            return nuber;
        }

        public static long ostatoc(long first, long second, long eILId)
        {
            long ost = first;
            for (long i = second - 1; i > 0; i--)
            {
                ost = (ost * first) % eILId;
            }
            return ost;
        }

        public static long closeKey(long p, long q, int e)
        {
            long fi = (p - 1) * (q - 1);
            long d = 0;
            long ost = 0;
            while (ost != 1)
            {
                d++;
                if (isSimple(d))
                {
                    ost = (e * d) % fi;
                }
            }
            return d;
        }
        public static long[] code(string c, int e, long n)
        {
            long[] rez = new long[c.Length + 1];
            for (int i = 0; i < c.Length; i++)
            {
                rez[i] = ostatoc(c[i], e, n);
            }
            return rez;
        }

        public static string decode(long[] c, long d, long n)
        {
            string rez = "";
            for (long i = 0; i < c.Length; i++)
            {
                rez = rez + Convert.ToChar(ostatoc(c[i], d, n));
            }
            return rez;
        }
        public static void Main(string[] args)
        {

            Random r = new Random();
            long p = nSimple(r.Next(25, 51));
            long q = nSimple(r.Next(25, 51));
            long n = p * q;
            int e = 257;
            long d = closeKey(p, q, e);
            Console.Write("Введите слово для шифрования: ");
            string iznac = Console.ReadLine();
            long[] codePhraze = code(iznac, e, n);
            string decoding = decode(codePhraze, d, n);
            Console.WriteLine("зашифрованный: ");
            for (int i = 0; i< codePhraze.Length-1; i++)
            {
                Console.WriteLine("{0} ", codePhraze[i]);
            }
            Console.WriteLine();
            Console.WriteLine("расшифрованный: {0}", decoding);

        }
    }
}