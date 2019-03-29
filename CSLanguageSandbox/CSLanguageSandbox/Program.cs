using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_LINQSimple;

namespace CSLanguageSandbox
{
    class Program
    {
        static void testAbstractClass()
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog("Molly"));
            animals.Add(new Cat("Felix"));

            foreach(Animal animal in animals)
            {
                animal.GetHello();
            }
        }

       
        static void Main(string[] args)
        {
            //testAbstractClass();
        }
    }
}
