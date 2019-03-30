using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class Garage<T> : IGarage<T>, IFixTotalLos<T>, IEnumerable<T> where T : IGiveDetails, new()
    {
        private List<T> _vehicles;
        private List<String> vehicleTypes;

        public Garage(List<string> vehicleTypes)
        {
            this.vehicleTypes = vehicleTypes;
            _vehicles = new List<T>();
        }

        public void AddVehicle(T vehicle)
        {
            try
            {
                if (_vehicles.Contains(vehicle))
                    throw new CarAlreadyHereException("Car already here!");

                else if (!(vehicle.CanFixTotalLost) && vehicle.TotalLost)
                    throw new WeDoNotFixTotalLostException("Can we fix it? no its fucked");

                else if (!(vehicleTypes.Contains(vehicle.Brand)))
                    throw new WrongGarageException("we dont fix this type");

                else if (vehicle == null)
                    throw new CarNullException("nothing to fix");

                else if (!(vehicle.NeedsRepair))
                    throw new RepairMismatchException("no need to fix");

                _vehicles.Add(vehicle);
            }

            catch(CarAlreadyHereException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch(WeDoNotFixTotalLostException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch(WrongGarageException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch(CarNullException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch(RepairMismatchException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        public bool CanFixTotalLost(T vehicle)
        {
            if (vehicle is Bike)
                return true;

            return false;
        }

        public void FixVehicle(T vehicle)
        {
            try
            {
                if (vehicle == null)
                    throw new CarNullException();

                if (!(_vehicles.Contains(vehicle)))
                    throw new CarNotIntGarageException();

                if (!(vehicle.NeedsRepair))
                    throw new RepairMismatchException();
            }

            catch(CarNullException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch(CarNotIntGarageException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch(RepairMismatchException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            vehicle.NeedsRepair = false;
        }

        public void TakeOutVehicle(T vehicle)
        {
            try
            {
                if (vehicle == null)
                    throw new CarNullException();

                else if (!(_vehicles.Contains(vehicle)))
                    throw new CarNotIntGarageException();

                else if (vehicle.NeedsRepair)
                    throw new CarNotReadyException();
            }

            catch(CarNullException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch (CarNotIntGarageException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            catch(CarNotReadyException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            _vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            string result = $"in This Garage Have {_vehicles.Count} Vehicles: \n";
            foreach (T car in _vehicles)
            {
                result = result + $"{car} \n";
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _vehicles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _vehicles.GetEnumerator();
        }
    }
}
