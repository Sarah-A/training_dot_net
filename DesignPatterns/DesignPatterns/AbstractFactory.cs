using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // IPizza is already defined in SimpleFactory.
    //public interface IPizza
    //{
    //    string Prepare();
    //    string Cut();
    //    string Bake();
    //    string Box();
    //}

    public class NyStyleCheesyPizza : IPizza
    {
        public string Prepare()
        {
            return "Preparing Ny Style Cheesy Pizza\n";
        }

        public string Cut()
        {
            return "Cutting Ny Style Cheesy Pizza\n";
        }

        public string Bake()
        {
            return "Baking Ny Style Cheesy Pizza\n";
        }

        public string Box()
        {
            return "Boxing Ny Style Cheesy Pizza\n";
        }
    }

    public class NyStylePepperoniPizza : IPizza
    {
        public string Prepare()
        {
            return "Preparing Ny Style Pepperoni Pizza\n";
        }

        public string Cut()
        {
            return "Cutting Ny Style Pepperoni Pizza\n";
        }

        public string Bake()
        {
            return "Baking Ny Style Pepperoni Pizza\n";
        }

        public string Box()
        {
            return "Boxing Ny Style Pepperoni Pizza\n";
        }
    }

    public class ChicagoStyleCheesyPizza : IPizza
    {
        public string Prepare()
        {
            return "Preparing Chicago Style Cheesy Pizza\n";
        }

        public string Cut()
        {
            return "Cutting Chicago Style Cheesy Pizza\n";
        }

        public string Bake()
        {
            return "Baking Chicago Style Cheesy Pizza\n";
        }

        public string Box()
        {
            return "Boxing Chicago Style Cheesy Pizza\n";
        }
    }

    public class ChicagoStylePepperoniPizza : IPizza
    {
        public string Prepare()
        {
            return "Preparing Chicago Style Pepperoni Pizza\n";
        }

        public string Cut()
        {
            return "Cutting Chicago Style Pepperoni Pizza\n";
        }

        public string Bake()
        {
            return "Baking Chicago Style Pepperoni Pizza\n";
        }

        public string Box()
        {
            return "Boxing Chicago Style Pepperoni Pizza\n";
        }
    }

    public interface IPizzaStore
    {
        string OrderPizza(string pizzaType);
    }


    public class NyPizzaStore : IPizzaStore
    {
        public string OrderPizza(string pizzaType)
        {
            IPizza pizza;

            switch (pizzaType)
            {
                case "Cheese":
                default:
                {
                    pizza = new NyStyleCheesyPizza();
                    break;
                }
                case "Pepperoni":
                {
                   pizza = new NyStylePepperoniPizza();
                   break;
                }

            }

            return pizza.Prepare(); 
        }
    }
}
