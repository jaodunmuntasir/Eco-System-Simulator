using System;
using System.Collections.Generic;
using System.IO;
using TextFile;

namespace OOP_Assignment_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the filename: ");
            string filename = Console.ReadLine();

            EcosystemSimulator simulator = new EcosystemSimulator(filename);
            simulator.SimulateEcosystem();

            Console.ReadLine();
        }
    }
}
