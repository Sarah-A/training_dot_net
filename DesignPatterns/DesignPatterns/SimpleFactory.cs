using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IPizza
    {
        string Prepare();
        string Cut();
        string Bake();
        string Box();
    }

    public class CheesyPizza : IPizza
    {
        public string Prepare()
        {
            return "Preparing Cheesy Pizza\n";
        }

        public string Cut()
        {
            return "Cutting Cheesy Pizza\n";
        }

        public string Bake()
        {
            return "Baking Cheesy Pizza\n";
        }

        public string Box()
        {
            return "Boxing Cheesy Pizza\n";
        }
    }

    public class PepperoniPizza : IPizza
    {
        public string Prepare()
        {
            return "Preparing Pepperoni Pizza\n";
        }
        public string Cut()
        {
            return "Cutting Pepperoni Pizza\n";
        }

        public string Bake()
        {
            return "Baking Pepperoni Pizza\n";
        }

        public string Box()
        {
            return "Boxing Pepperoni Pizza\n";
        }
    }

    public class SimplePizzaFactory
    {
        public IPizza CreatePizza(string pizzaType)
        {
            IPizza pizza;
            switch (pizzaType)
            {
                case "Cheese":
                default:
                {
                    pizza = new CheesyPizza();
                    break;
                }
                case "Pepperoni":
                {
                    pizza = new PepperoniPizza();
                    break;
                }               
            }

            return pizza;

        }
    }

    public class SimplePizzaStore
    {
        public SimplePizzaStore()
        {
            m_pizzaFactory = new SimplePizzaFactory();
        }

        public string OrderPizza(string pizzaType)
        {           
            IPizza pizza = m_pizzaFactory.CreatePizza(pizzaType);

            System.Text.StringBuilder pizzaProcess = new System.Text.StringBuilder();

            pizzaProcess.Append(pizza.Prepare());
            pizzaProcess.Append(pizza.Bake());
            pizzaProcess.Append(pizza.Cut());
            pizzaProcess.Append(pizza.Box());

            return pizzaProcess.ToString();
        }

        private SimplePizzaFactory m_pizzaFactory;
    }
}
