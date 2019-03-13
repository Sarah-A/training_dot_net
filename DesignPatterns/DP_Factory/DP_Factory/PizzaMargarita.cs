using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Factory
{
    class PizzaMargarita : IPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Pizza Margaritta - Preparing");
        }

        public void Bake()
        {
            Console.WriteLine("Pizza Margaritta - Baking");
        }

        public void Box()
        {
            Console.WriteLine("Pizza Margaritta - Boxing");
        }
    }
}
