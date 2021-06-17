using System;
using System.Threading.Tasks;

namespace Task6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var starter = new Starter();
            Task.Run(() => starter.Run(true, 1));
            Task.Run(() => starter.Run(false, 2));
            Console.ReadKey();
        }
    }
}
