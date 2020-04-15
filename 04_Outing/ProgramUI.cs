using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing
{
    class ProgramUI
    {
        private OutingsRepository _outingsRepo = new OutingsRepository();
        public void Run()
        {
            SeedData();
            KomodoOutings();
        }

        private void KomodoOutings()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. View list of company outings.\n" +
                    "2. Add a new outing.\n" +
                    "3. View total cost of company outings.\n" +
                    "4. View total cost of outings by event.\n" +
                    "5. Exit.");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        ViewTotalCostOfOutings();
                        break;
                    case "4":
                        ViewTotalCostByEvent();
                        break;
                    case "5":
                        Console.WriteLine("Until next time....");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewOutings()
        {
            Console.Clear();

            List<Outings> outingsList = _outingsRepo.GetListOfOutings();

            foreach (Outings prop in outingsList)
            {
                Console.WriteLine($"Event:{prop.Event}, Attendance:{prop.Attendance}, Date:{prop.Date}, Total Cost:${prop.TotalCost}\n");
            }
        }

        private void AddOuting()
        {
            Console.Clear();

            Outings newOuting = new Outings();

            Console.WriteLine("Enter the type of outing:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            string outingAsString = Console.ReadLine();
            int outingAsInt = int.Parse(outingAsString);
            newOuting.Event = (Outings.EventTypes)outingAsInt;
            Console.WriteLine(newOuting.Event);

            Console.WriteLine("Enter the number of employees in attendance:");
            newOuting.Attendance = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the date (yyyy/mm/dd, press enter after each line):");
            int year = Convert.ToInt32(Console.ReadLine());
            int month = Convert.ToInt32(Console.ReadLine());
            int day = Convert.ToInt32(Console.ReadLine());
            newOuting.Date = new DateTime(year, month, day);

            Console.WriteLine("Enter the total cost:");
            newOuting.TotalCost = Convert.ToDouble(Console.ReadLine());

            _outingsRepo.AddNewOuting(newOuting);
        }

        private void ViewTotalCostOfOutings()
        {
            Console.Clear();

            List<Outings> outingsList = _outingsRepo.GetListOfOutings();

            int i = 1;
            foreach (Outings prop in outingsList)
            {
                Console.WriteLine($"Outing {i++} - Date:{prop.Date}, Total Cost:${prop.TotalCost}\n");
            }

            double totalCost = _outingsRepo.GetCostOfAllOutings();
            Console.WriteLine($"The current total cost of all comany outings is ${totalCost}.");
        }

        private void ViewTotalCostByEvent()
        {
            Console.Clear();

            List<Outings> outingsList = _outingsRepo.GetListOfOutings();


            int i = 1;
            foreach (Outings prop in outingsList)
            {
                double quot = prop.CostPerPerson;
                Console.WriteLine($"Outing {i++} - Number of Employees:{prop.Attendance}, Total Cost:${prop.TotalCost}, Cost Per Person:${quot}\n");
            }

        }

        private void SeedData()
        {
            DateTime dateOne = new DateTime(2019, 04, 15);
            DateTime dateTwo = new DateTime(2019, 05, 23);
            DateTime dateThree = new DateTime(2019, 07, 10);
            DateTime dateFour = new DateTime(2019, 09, 25);

            Outings outingOne = new Outings(Outings.EventTypes.Bowling, 10, dateOne, 30.25);
            Outings outingTwo = new Outings(Outings.EventTypes.AmusementPark, 20, dateTwo, 375.65);
            Outings outingThree = new Outings(Outings.EventTypes.Concert, 25, dateThree, 750.75);
            Outings outingFour = new Outings(Outings.EventTypes.Golf, 12, dateFour, 315.48);

            _outingsRepo.AddNewOuting(outingOne);
            _outingsRepo.AddNewOuting(outingTwo);
            _outingsRepo.AddNewOuting(outingThree);
            _outingsRepo.AddNewOuting(outingFour);

        }
    }
}
