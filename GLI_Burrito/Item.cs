using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLI_Burrito
{
    /*
     * Class for generic menu items
     * */
    public class Item:Product
    {
        int id;
        string name;
        double value;

        /*
         * Create new Item instance
         * 
         * @param id this id of this item
         * @param name the name of this item
         * @param value the value of this item
         * */
        public Item(int id, string name, double value)
        {
            this.id = id;
            this.name = name;
            this.value = value;
        }

        /*
         * Returns the price of this item
         * 
         * @return the price of this item
         * */
        public double GetTotalPrice()
        {
            return this.value;
        }
    }
}
