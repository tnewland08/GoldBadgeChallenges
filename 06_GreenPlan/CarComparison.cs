using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public enum CarType
    {
        Electric =1,
        Gas,
        Hybrid
    }

    class CarComparison
    {
        private string _make;
        private string _model;

        public CarType Types { get; set; }
        public string CarName
        {
            get
            {
                string fullCarName = $"{_make} {_model}";
                return fullCarName;
            }
            set
            {

            }
        }

        public double SafetyRating { get; set; }
        public double Emissions { get; set; }

        public void SetMake(string name)
        {
            _make = name;
        }

        public void SetModel(string name)
        {
            _model = name;
        }

        public CarComparison() { }

        public CarComparison(CarType types, string make, string model, double safetyRating, double emissions)
        {
            Types = types;
            _make = make;
            _model = model;
            SafetyRating = safetyRating;
            Emissions = emissions;
        }

        
    }
}
