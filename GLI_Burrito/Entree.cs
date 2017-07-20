using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GLI_Burrito
{
    /*
     * Entree class
     * */
    public class Entree:Product
    {
        public int id;
        public int numberOfMaxIngredients;
        public int numberOfSelectedIngredients;
        public String name;
        public List<Ingredient> ingredients; // the selected ingredients for this entree
        public List<string> selectedCategories; // list of selected ingredient categories
        public double value = 0;
        public double totalValue = 0;
        public bool isConfigurable = false;
        public string[] exemptIngredients; // ingredients that should not be selectable

        /*
         * Create new entree object
         * 
         * @param id the id of this entree
         * @param name the name of this entree
         * @param numberOfIngredients the number of ingredients this entree can take
         * @param isConfigurable is this entree configurable
         * */
        public Entree(int id, String name, double value, int numberOfMaxIngredients, 
                        bool isConfigurable, string[] exemptIngredients)
        {
            this.id = id;
            this.name = name;
            this.value = value;
            this.numberOfMaxIngredients = numberOfMaxIngredients;
            this.isConfigurable = isConfigurable;
            this.ingredients = new List<Ingredient>(numberOfMaxIngredients);
            this.selectedCategories = new List<string>();
            this.exemptIngredients = exemptIngredients;
        }

        /*
         * Adds an ingredient to this entree. 
         * Does not add an ingredient if the max number of ingredients for this entree has been reached
         * or if category has already been chosen.
         * 
         * @return true if added ingredient, false otherwise
         * */
        public bool AddIngredient(Ingredient ingredient)
        {
            // This is one terrible method

            // only allow meat and salsa topping for 2-ingredient entree
            if( numberOfMaxIngredients == 2
                && (!ingredient.category.Equals("Meat") || !ingredient.category.Equals("Salsa")))
            {
                return false;
            }

            // do not add if ingredient is not allowed for this entree
            if(exemptIngredients != null)
            {
                foreach(String exempt in exemptIngredients)
                {
                    if(ingredient.name.Equals(exempt))
                    {
                        return false;
                    }
                }
            }

            //used to not increment ingredient count if ingredient is base
            if (ingredient.category.Equals("Base"))
            {
                //do not add if burrito bowl and trying to add tortilla
                if(id == 0 && ingredient.id == 0)
                {
                    return false;
                }

                //do not add more than one rice
                if(ingredient.id == 1 && ingredients.Contains(ingredient))
                {
                    return false;
                }

                ingredients.Add(ingredient);
            }
            //add ingredient if limit not reached. Do not add if category already chosen.
            else if ((numberOfSelectedIngredients < numberOfMaxIngredients 
                        && selectedCategories.Contains(ingredient.category) == false)
                        || isConfigurable == true)
            {
                ingredients.Add(ingredient);
                selectedCategories.Add(ingredient.category);
                numberOfSelectedIngredients++;
                return true;
            }
            return false;
        }

        /*
         * Returns the total price of this entree, including all ingredients price
         * 
         * @return the total price of this entree
         * */
        public double GetTotalPrice()
        {
            totalValue = value;
            if(ingredients != null)
            {
                foreach(Ingredient ingredient in ingredients)
                {
                    totalValue += ingredient.value;
                }
            }
            return totalValue;
        }

        /*
         * Prints the id, name, and price of this entree
         * 
         * return the id, name, and price of this entree
         * */
        public string PrintSimple()
        {
            return this.id + "  " + this.name + " " + GetTotalPrice();
        }

        /*
         * Returns a string representation of this object
         * 
         * @return string representation of this object
         * */
        public override string ToString()
        {
            string order = this.name + " with ";

            foreach (Ingredient ingredient in ingredients)
            {
                order += ingredient.name + " ";
            }

            return order;
        }
    }    
}
