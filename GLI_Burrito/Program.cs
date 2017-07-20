using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLI_Burrito
{
    class Program
    {


        /*
         * Simple test run for ordering  
         * */
        static void Main(string[] args)
        {
            //database should include list of ingredients that are hardcoded,
            //and ones that cannot be chosen.

            //if contains hardcoded, get hardcoded items
            //if contains exceptions, do not display exception items.

            int chosenItem = -1;
            OrderManager manager = new OrderManager();

            do
            {
                Print("Please enter entree option");
                
                foreach(Entree entree in manager.entrees)
                {
                    Print(entree.PrintSimple());
                }

                chosenItem = ReadNextInt();
                Entree chosenEntree = manager.entrees.ElementAt(chosenItem);

                Print("You Chose: " + chosenEntree.name);

                Print("Please select ingredients");

                foreach(Ingredient ingredient in manager.ingredients)
                {
                    Print(ingredient.ToString());
                }

                chosenItem = ReadNextInt();
                chosenEntree.AddIngredient(manager.ingredients.ElementAt(chosenItem));

                Print("You chose: " + manager.ingredients.ElementAt(chosenItem));

                manager.AddProductToOrder(chosenEntree);

                Print(manager.PrintOrder());
                Print("Your Total is: " + manager.GetOrderTotalPrice());
            } while (chosenItem != 10);

            Print("Thank you for choosing Build-a-Burrito!");
        }

        static char ReadNextChar()
        {
            return Console.ReadKey().KeyChar;
        }

        static int ReadNextInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        static void Print(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
