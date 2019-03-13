using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Item
    {
        public Item(string name, string description, float price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; }
        public string Description { get; }
        public float Price { get; }
    }

    public class ItemsArray
    {
    }

    public class ItemsList
    {
    }

    class Iterator
    {
    }
}
