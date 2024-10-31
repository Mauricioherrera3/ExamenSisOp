using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExamenSisOp
{
    internal class Program
    {
       
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();

        static void Main(string[] args)
        {
            Console.Write("Ingrese el Número en Base Decimal: ");
            int number = int.Parse(Console.ReadLine());

            
            Thread binario = new Thread(() => ConvertToBinary(number));
            Thread octal = new Thread(() => ConvertToOctal(number));
            Thread hexa = new Thread(() => ConvertToHexadecimal(number));

            binario.Start();
            octal.Start();
            hexa.Start();

          
            binario.Join();
            octal.Join();
            hexa.Join();

            
        }

        static void ConvertToBinary(int number)
        {
            lock (lock1)
            {
                Console.WriteLine($"Binario: {Convert.ToString(number, 2)}");
              
                Thread.Sleep(100); 
                lock (lock2)
                {
                    
                }
            }
        }

        static void ConvertToOctal(int number)
        {
            lock (lock2)
            {
                Console.WriteLine($"Octal: {Convert.ToString(number, 8)}");
               
                Thread.Sleep(100);
                lock (lock1)
                {
                    
                }
            }
        }

        static void ConvertToHexadecimal(int number)
        {
            Console.WriteLine($"Hexadecimal: {number:X}");
        }
    }
}