using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Delegates
{
    class Zoo
    {
        Animal[] animals;

        public Zoo()
        {
            Animal a = new Animal("Squicky the squirrel");
            Lion l = new Lion("Leo the lion");
            Giraffe g = new Giraffe("Gerry the giraffe");
            animals = new Animal[]{ a, l, g};
        }

        public Animal GetAnimal()
        {
            return animals[0];
        }

        public Animal GetLion()
        {
            //return (Lion)(animals[1]);
            return animals[1];
        }

        public Animal GetGiraffe()
        {
            //return (Giraffe)(animals[2]);
            return animals[2];
        }

        public void PrintAnimal(Animal animal)
        {
            Console.Write("In Zoo.PrintAnimal. ");
            animal.PrintName();
        }

        public void PrintGiraffe(Giraffe giraffe)
        {
            Console.Write("In Zoo.PrintGiraffe. ");
            giraffe.PrintName();
        }

        public void PrintLion(Lion lion)
        {
            Console.Write("In Zoo.PrintLion. ");
            lion.PrintName();
            lion.Roar();
        }
    }
}
