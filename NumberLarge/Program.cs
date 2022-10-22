using System;
using System.Linq;
using System.Collections.Generic;

namespace NumberLarge
{
    class Number
    {
        public List<byte> A { get; }
        public List<byte> B { get; }
        public Number(string str1, string str2)
        {
            A = new List<byte>();
            B = new List<byte>();
            if (str1.Length < str2.Length)
            {
                string temp = str1;
                str1 = str2;
                str2 = temp;
                A = str1.ToCharArray().Select(i => byte.Parse(i.ToString())).ToList(); // todo not so optimistic, but ok, let's go ahead
                B = str2.ToCharArray().Select(i => byte.Parse(i.ToString())).ToList();
            }
            else
            {
                A = str1.ToCharArray().Select(i => byte.Parse(i.ToString())).ToList();
                B = str2.ToCharArray().Select(i => byte.Parse(i.ToString())).ToList();
            }
        }

        private static List<byte> CreateNumber(List<byte> a, List<byte> b)
        {
            int n = Math.Abs(a.Count - b.Count);
            if (n > 0)
            {
                for (int i = 0; i < n; i++) b.Insert(0, 0);
                return b;
            }
            else return b;
        }

        public List<byte> CalculationSum()
        {
            _ = new List<byte>();
            _ = new List<byte>();
            List<byte> A = this.A;
            List<byte> B = CreateNumber(A, this.B);

            List<byte> Result = new();
            byte temp = 0;
            for (int j = A.Count - 1; j > -1; j--)
            {
                if ((A[j] + B[j] + temp) >= 10)
                {
                    if (j != 0)
                    {
                        Result.Insert(0, (byte)(A[j] + B[j] + temp - 10));
                        temp = 1;
                    }
                    else
                    {
                        Result.Insert(0, (byte)(A[j] + B[j] + temp - 10));
                        Result.Insert(0, 1);
                    }
                }
                else
                {
                    Result.Insert(0, (byte)(A[j] + B[j] + temp));
                    temp = 0;
                }
            }
            return Result;
        }

        public static void Print(List<byte> List)
        {
            Console.WriteLine(@"result:");
            for (int i = 0; i < List.Count; i++) Console.Write(List[i]);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(@"enter the first and second numbers:");
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            Number n = new(str1, str2);
            Number.Print(n.CalculationSum());
            Console.ReadKey();
        }
    }
}

