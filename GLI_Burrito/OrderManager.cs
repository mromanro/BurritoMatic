using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLI_Burrito
{
    /*
     * OrderManager manages orders.
     * Keeps track of all current items for one sale.
     * */
    class OrderManager
    {
        List<Product> order;
        public List<Entree> entrees;
        public List<Ingredient> ingredients;

        /*
         * Create OrderManager instance. Probably should be singleton
         * */
        public OrderManager()
        {
            order = new List<Product>();
            entrees = Database.GetAllEntrees();
            ingredients = Database.GetAllIngredients();
        }

        /*
         * Adds a product to this order.
         * 
         * @param Product the product to add this order
         * */
        public void AddProductToOrder(Product product)
        {
            order.Add(product);
        }

        /*
         * Returns the total price of this order.
         * Adds the price of all the current items in the order.
         *
         * @return  the total price of this order
         * */
        public double GetOrderTotalPrice()
        {
            double totalPrice = 0.0;

            foreach (Product product in order)
            {
                totalPrice += product.GetTotalPrice();
            }

            return totalPrice;
        }

        /*
         * Prints out all items in this order.
         * 
         * @return  string representation of all items in this order
         * */
        public string PrintOrder()
        {
            string msg = "";

            foreach(Product product in order)
            {
                msg += product.ToString() + "\n";
            }

            return msg;
        }
    }
}
