using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an menu option:\n" +
                    "1. View Komodo Cafe menu\n" +
                    "2. Create menu item\n" +
                    "3. Delete menu item\n" +
                    "4. Edit menu\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //View menu
                        ViewMenu();
                        break;
                    case "2":
                        //Create item
                        CreateMenuItem();
                        break;
                    case "3":
                        //Delete item
                        DeleteMenuItem();
                        break;
                    case "4":
                        //Edit menu
                        EditMenu();
                        break;
                    case "5":
                        Console.WriteLine("Later Tater!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewMenu()
        {
            Console.Clear();

            List<Menu> menuItems = _menuRepo.GetMenu();

            int i = 0; i++;
            foreach (Menu item in menuItems)
            {
                Console.WriteLine($"{i++}." +
                    $" {item.Meal} - {item.Description}.\n" +
                    $"{item.listOfIngredients}." +
                    $" ${item.Price}");
            }
        }

        private void CreateMenuItem()
        {
            Console.Clear();

            Menu newMenuItem = new Menu();

            Console.WriteLine("Enter Meal Name:");
            newMenuItem.Meal = Console.ReadLine();

            Console.WriteLine("Meal Description:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter Ingredients:");
            newMenuItem.Ingredients.Add(Console.ReadLine());
            
            Console.WriteLine("Enter the price:");
            newMenuItem.Price = Convert.ToDouble(Console.ReadLine());

            _menuRepo.AddItemToMenu(newMenuItem);

        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            ViewMenuByName();

            Console.WriteLine("\nWhich menu item would you like to remove to remove?");
            string input = Console.ReadLine();
            
            bool wasRemoved = _menuRepo.RemoveMenuItem(input);

            if (wasRemoved)
            {
                Console.WriteLine("Menu item was removed.");
            }
            else
            {
                Console.WriteLine("The menu item could not be removed.");
            }
        }

        private void EditMenu()
        {
            Console.Clear();
            ViewMenuByName();
            Console.WriteLine("Which meal would you like to edit?");

            string oldMenuItem = Console.ReadLine();
            int itemNumber = int.Parse(oldMenuItem);


            Menu newMenuItem = new Menu();

            Console.WriteLine("Enter Meal Name:");
            newMenuItem.Meal = Console.ReadLine();

            Console.WriteLine("Meal Description:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter Ingredients:");
            newMenuItem.Ingredients.Add(Console.ReadLine());

            Console.WriteLine("Enter the price:");
            newMenuItem.Price = Convert.ToDouble(Console.ReadLine());

            bool successfulEdit = _menuRepo.EditExistngMenuItem(oldMenuItem, newMenuItem);

            if (successfulEdit)
            {
                Console.WriteLine("Edit was successful!");
            }
            else
            {
                Console.WriteLine("Edit could not be completed. Pleae try again.");
            }
        }

        private void ViewMenuByName()
        {
            List<Menu> menuItems = _menuRepo.GetMenu();

            int i = 0; i++;
            foreach (Menu item in menuItems)
            {
                Console.WriteLine($"{i++}." +
                    $" {item.Meal}");
            }
        }


        private void SeedMenu()
        {
            Menu hamburgerMeal = new Menu(
                    "Manny's Hammie",
                    "Seared Angus patty and pub chips",
                    "Angus patty,lettuce,tomato,onions,garlic aioli,brioche bun, thick sliced potato chips",
                    4.99);
            Menu cheeseBurgerMeal = new Menu(
                    "Manny's Cheese Hammie",
                    "Seared Angus Patty with cheese and French Fried Potatos",
                    "Angus patty,choice of cheeese:Cheddar,American,Swiss,Jalapeno,Habanero,lettuce,tomato,onion,Chipotle aioli,Kaiser Roll,thin cut fried potato strips",
                    5.99);
            Menu turkeyBurgerMeal = new Menu(
                    "The Gobbler",
                    "Free range Turkey patty and roasted potatos",
                    "Ground Turkey,lettuce,tomato,onion,garlic aioli,red potato chunks",
                    5.99);
            Menu roastedChickenMeal = new Menu(
                    "Roasty, Toasty Chicken",
                    "Free range chicken and smashed potatos",
                    "Roast Chicken(white and/or dark meat),gravy(optional),smashed red potatos with garlic seasoning",
                    6.99);
            Menu meatloafMeal = new Menu(
                    "Mom's Meatloaf",
                    "Two slices of your favorite meat loaf and roasted carrots and potatos",
                    "Ground beef - loafed, with sauteed onions and special ketchup topping, roasted carrots and chunked red potatos, fresh cracked pepper, garlic salt",
                    6.99);
            Menu gardenSalad = new Menu(
                    "THE Garden Salad",
                    "Chef's famous garden salad with choice of dressing. Add roasted chicken for an extra $2.00",
                    "Organic lettuce blend,sliced red onion,banana peppers,vine-ripened tomato chunks,black olives(optional),large croutons,grated parmesan cheese",
                    4.99);
            Menu greekSalad = new Menu(
                    "The Parthenon?",
                    "Chef's not-so famous greek salad.",
                    "Vine-ripened tomatos,cucumbers,red onion,Kalamta olives,green bell pepper,dried oregano,Kosher salt,extra-virgin olive oil,red wine vinegar,feta cheese",
                    4.99);
            Menu caesarSalad = new Menu(
                    "Et Tu, Brute?!",
                    "Ides of March Caesar Salad. Add grilled chicken for an extra $2.00",
                    "Romaine lettuce,lemon juice,minced garlic,Worcestershire sauce,red pepper flakes,dijon mustard,vegetable oil,extra-virgin olive oil,salt,black pepper",
                    4.99);


            _menuRepo.AddItemToMenu(hamburgerMeal);
            _menuRepo.AddItemToMenu(cheeseBurgerMeal);
            _menuRepo.AddItemToMenu(turkeyBurgerMeal);
            _menuRepo.AddItemToMenu(roastedChickenMeal);
            _menuRepo.AddItemToMenu(meatloafMeal);
            _menuRepo.AddItemToMenu(gardenSalad);
            _menuRepo.AddItemToMenu(greekSalad);
            _menuRepo.AddItemToMenu(caesarSalad);
        }
    }
}
