using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLI_Burrito
{
    /*
     * Ingredient class
     * */
    public class Ingredient:Product
    {
        public int id;
        public String category;
        public String name;
        public double value = 0;
   
        /*
         * Creates an Ingredient instance
         * 
         * @param id the id of this ingredient
         * @param category the category of this ingredient
         * @param name the name of this ingredient
         * @param value the value of this ingredient
         * */
        public Ingredient(int id, String category, String name, double value)
        {
            this.id = id;
            this.category = category;
            this.name = name;
            this.value = value;
        }

        /*
         * Returns the price of this ingredient
         * 
         * @return the price of this ingredient
         * */
        public double GetTotalPrice()
        {
            return this.value;
        }

        /*
         * Retuns a string representation of this object
         * 
         * @return string representation of this object
         * */
        public override string ToString()
        {
            if (value == 0.0)
                return this.id + " " + this.name;
            else
                return this.id + " " + this.name + " " + this.value;
        }
    }
}
