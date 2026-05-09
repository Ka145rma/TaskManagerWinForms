using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("\nЗадание 10:");
            Console.WriteLine("\n\n");

            Console.Write("введите расстояние: ");
            double feet = double.Parse(Console.ReadLine());

            double inches = feet * 12;
            double yards = feet / 3;
            double miles = feet / 5200;

            Console.WriteLine("в дюймах: " + inches);
            Console.WriteLine("в ярдах: " + yards);
            Console.WriteLine("в милях: " + miles);

        }
    }
}
