using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    interface IGarage<T>
    {
        void AddVehicle(T vehicle);
        void TakeOutVehicle(T vehicle);
        void FixVehicle(T vehicle);
    }
}
