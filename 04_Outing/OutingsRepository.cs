using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing
{
    class OutingsRepository
    {
        private List<Outings> _listOfOutings = new List<Outings>();

        public void AddNewOuting(Outings newOuting)
        {
            _listOfOutings.Add(newOuting);
        }

        public List<Outings> GetListOfOutings()
        {
            return _listOfOutings;
        }

        public double GetCostOfAllOutings()
        {
            double totalCost = 0.0;
            foreach (Outings item in _listOfOutings)
            {
                totalCost += item.TotalCost;
            }
            return totalCost;
        }

        public double GetCostPerPerson()
        {
            double perCost = 0.0;
            foreach (Outings item in _listOfOutings)
            {
                perCost += item.CostPerPerson;
            }
            return perCost;
        }
    }
}
