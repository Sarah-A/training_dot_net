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

        public virtual string GetHello()
        {
           return ("I'm an animal. My Name is: " + name_);
        }

    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override string GetHello()
        {
            return ("I'm a cat. My Name is: " + name_);
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override string GetHello()
        {
            return ("I'm a dog. My Name is: " + name_);
        }
    }
       
}
