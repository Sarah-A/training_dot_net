using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLanguageSandbox
{
    public abstract class Animal
    {
        protected string name_;
        public Animal(string name) => name_ = name;

        public virtual void PrintName()
        {
            Console.WriteLine("I'm an animal: {0}", name_);
        }

    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void PrintName()
        {
            Console.WriteLine("I'm a cat: {0}", name_);
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void PrintName()
        {
            Console.WriteLine("I'm a dog: {0}", name_);
        }
    }
}
