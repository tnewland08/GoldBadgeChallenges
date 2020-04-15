using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    class MenuRepository
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();

        //Create
        public void AddItemToMenu(Menu newItem)
        {
            _listOfMenuItems.Add(newItem);
        }

        //Read
        public List<Menu> GetMenu()
        {
            return _listOfMenuItems;
        }

        //Update
        public bool EditExistngMenuItem(string mealName, Menu newMenuItem)
        {
            Menu oldMenuItem = GetMenuItemByMealName(mealName);

            if (oldMenuItem != null)
            {
                oldMenuItem.Meal = newMenuItem.Meal;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.listOfIngredients = newMenuItem.listOfIngredients;
                oldMenuItem.Price = newMenuItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveMenuItem(string title)
        {
            Menu meal = GetMenuItemByMealName(title);
            if (meal == null)
            {
                return false;
            }

            int startingCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(meal);

            if (startingCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public Menu GetMenuItemByMealName(string name)
        {
            foreach(Menu menuItem in _listOfMenuItems)
            {
                if (menuItem.Meal.ToLower() == name.ToLower())
                {
                    return menuItem;
                }
            }

            return null;
        }
    }
}
