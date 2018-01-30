using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DpShortPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                { "a", "b,2;h,8;g,1" },
                { "b", "h,6;c,1" },
                { "c", "h,5;i,3;j,9;d,2" },
                { "d", "j,7;e,9" },
                { "e", "e,0" },
                { "f", "e,4;j,1;k,1" },
                { "g", "k,9;h,7" },
                { "h", "c,5;i,1;g,7;k,2;b,6" },
                { "i", "c,3;h,1;k,4;j,9" },
                { "j", "d,7;f,1;e,2;i,9;c,9;k,3" },
                { "k", "i,4;j,3;f,1;h,2" }
            };

            LoopHashMap(dic);
            Console.WriteLine();
            var keyAndValue = results.OrderBy(x => x.Value).First();
            Console.WriteLine("Final Path：{0}   Min Cost： {1}", keyAndValue.Key, keyAndValue.Value);
            Console.ReadKey();
        }

        static int count = 0;
        static Dictionary<string, int> results = new Dictionary<string, int>();

        private static void LoopHashMap(Dictionary<String, String> map)
        {
            String start = "a";
            String end = "e";
            StringBuilder sb = new StringBuilder();
            sb.Append(start);
            int sum = 0;
            
            RecursionHashMap(start, map, end, sb, sum);
        }

        private static void RecursionHashMap(String start, Dictionary<String, String> map, String end,
                StringBuilder sbNew, int sumNew)
        {
            String value = map[start];
            String[] arr = value.Split(';');

            for (int i = 0; i < arr.Length; i++)
            {
                String[] list = arr[i].Split(',');
                StringBuilder sb = new StringBuilder();
                sb.Append(sbNew.ToString());
                int sum = sumNew;

                if (!sb.ToString().Contains(list[0]))
                {
                    if (list[0]==end)
                    {
                        count++;
                        sb.Append("-" + list[0]);
                        sum = sum + Convert.ToInt32(list[1]);
                        Console.WriteLine("Path:" + count + "  " + sb.ToString() + " Sum:" + sum);
                        results.Add(sb.ToString(), sum);
                    }
                    else
                    {
                        sum = sum + Convert.ToInt32(list[1]);
                        sb.Append("-" + list[0]);
                        RecursionHashMap(list[0], map, end, sb, sum);
                    }
                }
            }
        }
    }
}
