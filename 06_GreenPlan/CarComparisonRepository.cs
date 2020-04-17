using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    class CarComparisonRepository
    {
        private List<CarComparison> _listofCars = new List<CarComparison>();

        public void AddNewCar(CarComparison newCar)
        {
            _listofCars.Add(newCar);
        }

        public List<CarComparison> GetListOfCars()
        {
            return _listofCars;
        }

        public bool UpdateExistingCar(string originalCar, CarComparison newCar)
        {
            CarComparison oldCar = GetCarByFullName(originalCar);

            if (oldCar != null)
            {
                oldCar.Types = newCar.Types;
                oldCar.CarName = newCar.CarName;
                oldCar.SafetyRating = newCar.SafetyRating;
                oldCar.Emissions = newCar.Emissions;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCarFromList(string carName)
        {
            CarComparison car = GetCarByFullName(carName);
            if(car == null)
            {
                return false;
            }

            int startingCount = _listofCars.Count;
            _listofCars.Remove(car);

            if(startingCount > _listofCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public CarComparison GetCarByFullName(string name)
        {
            foreach(CarComparison car in _listofCars)
            {
                if(car.CarName.ToLower() == name.ToLower())
                {
                    return car;
                }
            }

            return null;
        }

    }
}
