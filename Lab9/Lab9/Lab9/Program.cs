using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SHA1HashStringForUTF8String("helloworldhelloworldhelloworld"));
        }

        public static string SHA1HashStringForUTF8String(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);
            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.Elapsed);
            return HexStringFromBytes(hashBytes);
        }

        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
