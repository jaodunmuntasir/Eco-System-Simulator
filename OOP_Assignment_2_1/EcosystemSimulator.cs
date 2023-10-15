using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace OOP_Assignment_2_1
{
    public class EcosystemSimulator
    {
        private List<IPlant> plants;
        private int numDays;

        public EcosystemSimulator(string filename)
        {
            LoadPlantsFromFile(filename);
        }

        private void LoadPlantsFromFile(string filename)
        {
            TextFileReader reader = new TextFileReader(filename);

            reader.ReadLine(out string line);
            int numPlants = int.Parse(line);
            plants = new List<IPlant>();

            for (int i = 1; i <= numPlants; i++)
            {
                reader.ReadLine(out line);

                string[] plantData = line.Split(' ');
                string name = plantData[0];
                string species = plantData[1];
                int nutrientLevel = int.Parse(plantData[2]);

                IPlant plant;

                if (species == "wom")
                {
                    plant = new Wombleroot(name, nutrientLevel);
                }
                else if (species == "wit")
                {
                    plant = new Wittentoot(name, nutrientLevel);
                }
                else if (species == "wor")
                {
                    plant = new Woreroot(name, nutrientLevel);
                }
                else
                {
                    throw new ArgumentException("Invalid plant species.");
                }

                plants.Add(plant);
            }

            reader.ReadLine(out line);
            numDays = int.Parse(line);
        }

        public void SimulateEcosystem()
        {
            Console.WriteLine("Ecosystem Simulation");

            for (int day = 1; day <= numDays; day++)
            {
                Console.WriteLine($"\nDay {day}");

                int alphaDemand = 0;
                int deltaDemand = 0;

                foreach (IPlant plant in plants)
                {
                    Console.WriteLine($"{plant.Name} ({plant.GetType().Name}) - Nutrient Level: {plant.NutrientLevel}");

                    int demand = plant.GetRadiationDemand();

                    if (demand > 0)
                    {
                        if (plant.GetType() == typeof(Wombleroot))
                        {
                            alphaDemand += demand;
                        }
                        else if (plant.GetType() == typeof(Wittentoot))
                        {
                            deltaDemand += demand;
                        }
                    }

                    if (plant.IsAlive)
                    {
                        string radiationType = GetRadiationType(alphaDemand, deltaDemand);
                        plant.ReactToRadiation(radiationType);
                    }
                }
            }

            Console.WriteLine("\nEcosystem Simulation Complete");
            PrintAlivePlants();
            PrintStrongestPlant();
        }

        public string GetRadiationType(int alphaDemand, int deltaDemand)
        {
            if (alphaDemand > deltaDemand + 2)
            {
                //Console.WriteLine("\nALPHA\n");
                return "alpha";
            }
            else if (deltaDemand > alphaDemand + 2)
            {
                //Console.WriteLine("\nDELTA\n");
                return "delta";
            }
            else
            {
                //Console.WriteLine("\nNONE\n");
                return "none";
            }
        }

        private void PrintAlivePlants()
        {
            Console.WriteLine("\nAlive Plants:");
            foreach (IPlant plant in plants)
            {
                if (plant.IsAlive)
                {
                    Console.WriteLine($"{plant.Name} ({plant.GetType().Name}) - Nutrient Level: {plant.NutrientLevel}");
                }
            }
        }

        private void PrintStrongestPlant()
        {
            int maxNutrientLevel = 0;
            string strongestPlant = "";

            foreach (IPlant plant in plants)
            {
                if (plant.IsAlive && plant.NutrientLevel > maxNutrientLevel)
                {
                    maxNutrientLevel = plant.NutrientLevel;
                    strongestPlant = $"{plant.Name} ({plant.GetType().Name})";
                }
            }

            if (strongestPlant != "")
            {
                Console.WriteLine("\nStrongest Plant:");
                Console.WriteLine(strongestPlant);
            }
            else
            {
                Console.WriteLine("\nStrongest Plant:");
                Console.WriteLine("All Plants are Dead!");
            }
        }
    }
}
