using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    
    class Menu  
    {
        public List<string> listOfIngredients = new List<string>();

        public string Meal { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get { return listOfIngredients; } }        
        public double Price { get; set; }


        public Menu() { }

        public Menu(string meal, string description, string ingredients, double price)
        {
            Meal = meal;
            Description = description;
            listOfIngredients = ingredients.Split(',').ToList();
            Price = price;
        }
    }
}
