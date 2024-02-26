using System;

namespace async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //await function(5);
            Task<int> task1 = function(90);
            Task<int> task2 = function(750); 
            Task<int> task3 = function(3);
            await Task.WhenAll(task1, task2, task3);
            int result1 = task1.Result;
            int result2 = task2.Result;
            int result3 = task3.Result;
            Console.WriteLine($"{result1}, {result2}, {result3}");
        }
        static async Task<int> function(int num)
        {
            Console.WriteLine($"function is work, {num}");

            await Task.Delay(num);

            Console.WriteLine($"function is work 2, {num}");
            return num;
        }

    }
}