using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLI_Burrito
{
    /*
     * Database class. Used to represent a database of menu items.
     * */
    class Database
    {
        static DataTable entreesTable = GetEntreesTable();
        static DataTable ingredientsTable = GetIngredientsTable();
        static DataTable otherItemsTable = GetOtherItemsTable();

        /*
         * Creates a DataTable of entrees
         * 
         * @return DataTable of entrees
         * */
        public static DataTable GetEntreesTable()
        {
            DataTable entreesTable = new DataTable();
            entreesTable.Columns.Add("ID", typeof(int));
            entreesTable.Columns.Add("Name", typeof(string));
            entreesTable.Columns.Add("Value", typeof(double));
            entreesTable.Columns.Add("NumberOfIngredients", typeof(int));
            entreesTable.Columns.Add("IsConfigurable", typeof(bool));
            entreesTable.Columns.Add("ExemptIngredients", typeof(string[]));

            entreesTable.Rows.Add(0, "2-Ingredient Burrito-in-a-Bowl", 3.99, 2, false, new string[] { "Tortilla" });
            entreesTable.Rows.Add(1, "2-Ingredient Burrito", 4.99, 2, false, null);
            entreesTable.Rows.Add(2, "3-Ingredient Burrito", 5.99, 3, false, null);
            entreesTable.Rows.Add(3, "A-La-Cart Burrito", 5.99, 3, true, null);

            return entreesTable;
        }

        /*
         * Creates a DataTable of ingredients
         * 
         * @return DataTable of ingredients
         * */
        public static DataTable GetIngredientsTable()
        {
            DataTable ingredientsTable = new DataTable();
            ingredientsTable.Columns.Add("ID", typeof(int));
            ingredientsTable.Columns.Add("Category", typeof(string));
            ingredientsTable.Columns.Add("Name", typeof(string));
            ingredientsTable.Columns.Add("Value", typeof(double));
            ingredientsTable.Columns.Add("ExtraValue", typeof(double));

            ingredientsTable.Rows.Add(0, "Base", "Tortilla", 0.0, 0.50);
            ingredientsTable.Rows.Add(1, "Base", "Rice", 0.0, 0.50);
            ingredientsTable.Rows.Add(2, "Meat", "Chicken", 0.0, 0.50);
            ingredientsTable.Rows.Add(3, "Meat", "Steak", 0.0, 0.50);
            ingredientsTable.Rows.Add(4, "Salsa", "Red Salsa", 0.0, 0.50);
            ingredientsTable.Rows.Add(5, "Salsa", "Green Salsa", 0.0, 0.50);
            ingredientsTable.Rows.Add(6, "Salsa", "Queso", 1.50, 1.50);
            ingredientsTable.Rows.Add(7, "Toppings", "Grated Cheese", 0.0, 0.33);
            ingredientsTable.Rows.Add(8, "Toppings", "Sour Cream", 0.0, 0.33);
            ingredientsTable.Rows.Add(9, "Toppings", "Guacamole", 1.25, 1.25);

            return ingredientsTable;
        }

        /*
         * Creates a DataTable of other menu items
         * 
         * @return DataTable of other menu items
         * */
        public static DataTable GetOtherItemsTable()
        {
            DataTable otherItemsTable = new DataTable();
            otherItemsTable.Columns.Add("ID", typeof(int));
            otherItemsTable.Columns.Add("Name", typeof(string));
            otherItemsTable.Columns.Add("Value", typeof(double));

            otherItemsTable.Rows.Add(0, "Soft drinks", 1.25);
            otherItemsTable.Rows.Add(1, "Brownie", 1.50);
            otherItemsTable.Rows.Add(2, "Chips", 2.00);

            return otherItemsTable;
        }

        /*
         * Creates a DataTable of categories that are exempt
         * 
         * @return DataTable of exempt categories
         * */
        public static DataTable ExceptCategories()
        {
            DataTable exceptTable = new DataTable();
            exceptTable.Columns.Add("ID", typeof(int));
            exceptTable.Columns.Add("NumberOfIngredients", typeof(int));
            exceptTable.Columns.Add("Categories", typeof(string[]));

            exceptTable.Rows.Add(0, 2, new string[]{"Toppings"});

            return exceptTable;
        }

        /*
         * Returns all entrees from the entrees DataTable
         * 
         * @return List<Entree> all entrees
         * */
        public static List<Entree> GetAllEntrees()
        {
            List<Entree> entrees = new List<Entree>();

            foreach (DataRow row in entreesTable.Rows)
            {
                entrees.Add(new Entree(row.Field<int>(0), 
                                        row.Field<string>(1), 
                                        row.Field<double>(2),
                                        row.Field<int>(3),
                                        row.Field<bool>(4),
                                        row.Field<string[]>(5)));
            }

            return entrees;
        }

        /*
         * Returns all ingredients from the entrees DataTable
         * 
         * @return List<Ingredient> all ingredients
         * */
        public static List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (DataRow row in ingredientsTable.Rows)
            {
                ingredients.Add(new Ingredient(row.Field<int>(0),
                                                row.Field<string>(1),
                                                row.Field<string>(2),
                                                row.Field<double>(3)));
            }

            return ingredients;
        }

        /*
         * Returns all other items from the other items DataTable
         * 
         * @return List<Item> all items
         * */
        public List<Item> getAllOtherItems()
        {
            List<Item> items = new List<Item>();

            foreach (DataRow row in otherItemsTable.Rows)
            {
                items.Add(new Item(row.Field<int>(0),
                                    row.Field<string>(1),
                                    row.Field<double>(2)));
            }

            return items;
        }
    }
}
