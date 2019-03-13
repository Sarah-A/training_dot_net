using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Factory
{
    class TestSimpleFactory
    {
        public void OrderPizza(string type)
        {
            IPizza pizza;

            switch(type)
            {
                case "Margaritta":
                    {
                        pizza = new PizzaMargarita();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Invalid Pizza type error");
                        return;
                    }
            }

            pizza.Prepare();
            pizza.Bake();
            pizza.Box();

        }
    }
}
