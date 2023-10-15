using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TextFile;

namespace OOP_Assignment_2_1
{
    public interface IPlant
    {
        string Name { get; }
        int NutrientLevel { get; set; }
        bool IsAlive { get; set; }
        void ReactToRadiation(string radiationType);
        int GetRadiationDemand();
    }

    public class Wombleroot : IPlant
    {
        public string Name { get; private set; }
        public int NutrientLevel { get; set; }
        public bool IsAlive { get; set; }

        public Wombleroot(string name, int nutrientLevel)
        {
            Name = name;
            NutrientLevel = nutrientLevel;
            IsAlive = true;
        }

        public void ReactToRadiation(string radiationType)
        {
            if (radiationType == "alpha")
            {
                NutrientLevel += 2;
            }
            else if (radiationType == "delta")
            {
                NutrientLevel -= 2;
            }
            else if (radiationType == "none")
            {
                NutrientLevel -= 1;
            }

            if (NutrientLevel > 10 || NutrientLevel <= 0)
            {
                IsAlive = false;
            }
        }

        public int GetRadiationDemand()
        {
            return 10;
        }
    }

    public class Wittentoot : IPlant
    {
        public string Name { get; private set; }
        public int NutrientLevel { get; set; }
        public bool IsAlive { get; set; }

        public Wittentoot(string name, int nutrientLevel)
        {
            Name = name;
            NutrientLevel = nutrientLevel;
            IsAlive = true;
        }

        public void ReactToRadiation(string radiationType)
        {
            if (radiationType == "alpha")
            {
                NutrientLevel -= 3;
            }
            else if (radiationType == "delta")
            {
                NutrientLevel += 4;
            }
            else if (radiationType == "none")
            {
                NutrientLevel -= 1;
            }

            if (NutrientLevel <= 0)
            {
                IsAlive = false;
            }
        }

        public int GetRadiationDemand()
        {
            if (NutrientLevel < 5)
            {
                return 4;
            }
            else if (NutrientLevel >= 5 && NutrientLevel <= 10)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Woreroot : IPlant
    {
        public string Name { get; private set; }
        public int NutrientLevel { get; set; }
        public bool IsAlive { get; set; }

        public Woreroot(string name, int nutrientLevel)
        {
            Name = name;
            NutrientLevel = nutrientLevel;
            IsAlive = true;
        }

        public void ReactToRadiation(string radiationType)
        {
            if (radiationType == "alpha" || radiationType == "delta")
            {
                NutrientLevel += 1;
            }
            else if (radiationType == "none")
            {
                NutrientLevel -= 1;
            }

            if (NutrientLevel <= 0)
            {
                IsAlive = false;
            }
        }

        public int GetRadiationDemand()
        {
            return 0;
        }
    }
}
