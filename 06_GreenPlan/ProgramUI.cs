using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    class ProgramUI
    {
        private CarComparisonRepository _carRepo = new CarComparisonRepository();
        public void Run()
        {
            SeedData();
            MainMenu();
        }

        private void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. View list of cars.\n" +
                    "2. Add new car.\n" +
                    "3. Update car(s).\n" +
                    "4. Delete car(s).\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllCars();
                        break;
                    case "2":
                        CreateNewCar();
                        break;
                    case "3":
                        UpdateExistingCar();
                        break;
                    case "4":
                        DeleteCar();
                        break;
                    case "5":
                        Console.WriteLine("Drive Safe!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }

        }
        private void ViewAllCars()
        {
            Console.Clear();

            List<CarComparison> carList = _carRepo.GetListOfCars();

            Console.WriteLine($"{"Car Type",-15} {"Car Name",-15} {"Safety Rating",-20} {"Emissions (metric tons)"}");
            Console.WriteLine(new String('═', 64));

            foreach(CarComparison item in carList)
            {
                Console.WriteLine($"{item.Types,-15}  {item.CarName,-15}  {item.SafetyRating,-20}  {item.Emissions}\n");
            }
        }
        
        private void CreateNewCar()
        {
            Console.Clear();

            CarComparison newCar = new CarComparison();

            Console.WriteLine("Enter the type of car:\n" +
                "1. Electric\n" +
                "2. Gas\n" +
                "3. Hybrid");
            string typesAsString = Console.ReadLine();
            int typesAsInt = int.Parse(typesAsString);
            newCar.Types = (CarType)typesAsInt;
            Console.WriteLine(newCar.Types);

            Console.WriteLine("Enter the make:");
            newCar.SetMake(Console.ReadLine());

            Console.WriteLine("Enter the model:");
            newCar.SetModel(Console.ReadLine());

            Console.WriteLine("Enter the safety rating:");
            string rating = Console.ReadLine();
            newCar.SafetyRating = double.Parse(rating);

            Console.WriteLine("Enter the average annual emissions (metric tons):");
            string emissions = Console.ReadLine();
            newCar.Emissions = double.Parse(emissions);

            _carRepo.AddNewCar(newCar);
        }

        private void UpdateExistingCar()
        {
            Console.Clear();

            ViewAllCars();

            Console.WriteLine("Which car would you like to update?");

            string oldCar = Console.ReadLine();

            CarComparison newCar = new CarComparison();

            Console.WriteLine("Enter the type of car:\n" +
                "1. Electric\n" +
                "2. Gas\n" +
                "3. Hybrid");
            string typesAsString = Console.ReadLine();
            int typesAsInt = int.Parse(typesAsString);
            newCar.Types = (CarType)typesAsInt;
            Console.WriteLine(newCar.Types);

            Console.WriteLine("Enter the make:");
            newCar.SetMake(Console.ReadLine());

            Console.WriteLine("Enter the model:");
            newCar.SetModel(Console.ReadLine());

            Console.WriteLine("Enter the safety rating:");
            string rating = Console.ReadLine();
            newCar.SafetyRating = double.Parse(rating);

            Console.WriteLine("Enter the average annual emissions (metric tons):");
            string emissions = Console.ReadLine();
            newCar.Emissions = double.Parse(emissions);

            bool wasUpdated = _carRepo.UpdateExistingCar(oldCar, newCar);

            if (wasUpdated)
            {
                Console.WriteLine("Successful Update!");
            }
            else
            {
                Console.WriteLine("Date was not updated. Please try again.");
            }
        }

        private void DeleteCar()
        {
            Console.Clear();

            ViewAllCars();

            Console.WriteLine("Which car would you like to delete?");

            string input = Console.ReadLine();

            bool wasDeleted = _carRepo.RemoveCarFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine($"{input} was successfully removed from the list.");
            }
            else
            {
                Console.WriteLine($"{input} ws not removed from the list.  Please try again.");
            }
        }

        private void SeedData()
        {
            CarComparison nissanLeaf = new CarComparison(CarType.Electric, "Nissan", "Leaf", 5.0, 0.0);
            CarComparison toyotaPrius = new CarComparison(CarType.Hybrid, "Toyota", "Prius", 5.0, 1.8);
            CarComparison vwJetta = new CarComparison(CarType.Gas, "VW", "Jetta", 5.0, 4.6);

            _carRepo.AddNewCar(nissanLeaf);
            _carRepo.AddNewCar(toyotaPrius);
            _carRepo.AddNewCar(vwJetta);
        }
    }
}
