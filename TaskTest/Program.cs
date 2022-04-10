using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            long sum = 0;
            long num = await Task.Run(() => {
                for (int i = 0; i < 5000000; i++)
                {
                    for (int j = 0; j < 5000000; j++)
                    {
                        sum = sum + 1;
                    }
                }
                Console.WriteLine(sum);
                return sum;
            });
            Console.WriteLine("Hello");
        }
    }
}
