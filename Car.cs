using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class Car
    {
        public Car(string brand, bool totalLost, bool needsRepair)
        {
            try
            {
                if (totalLost && !(needsRepair))
                    throw new RepairMismatchException();
            }

            catch (RepairMismatchException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            this.Brand = brand;
            this.TotalLost = totalLost;
            this.NeedsRepair = needsRepair;
        }

        public string Brand { get; private set; }
        public bool TotalLost { get; private set; }
        public bool NeedsRepair { get; set; }
    }
}
