using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//-----------------------------------------------------------------------------------------------------------------
// TODO:
// Refactor the code - adding Size wreked the design because unlike the other decorators, size goes all the 
//  way to the base class. Therefore, adding it as an additional decorator (which is what I did) is wrong
//  and makes the design messy. 
//  Need to find a better, more elegant way to add it. Perferably without changing all the existing classes...
//-----------------------------------------------------------------------------------------------------------------

namespace DesignPatterns
{
    class MenuItem
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }


    // Note: the Beverage and BeverageDecorator abstract classes can also be interfaces.
    //      we used abstract classes here only because this is the original definition of the pattern.
    //      however, if there are no common member variables or implemented functions, it makes more 
    //      sense to use interfaces instead.
    public abstract class Beverage                  
    {
        public enum Size
        {
            Small,
            Medium,
            Large
        }

        public Beverage()
        {            
        }

        public virtual decimal Price()
        {
            return Price(Size.Small);
        }

        public abstract decimal Price(Size size);        
        public abstract string Description();



    }

    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage m_beverage;
    }
    

    public class DarkRoast : Beverage
    {
        public override decimal Price(Size size)
        {
            return m_prices[size];
        }

        public override string Description()
        {
            return "Dark Coffee";
        }

        private Dictionary<Beverage.Size, decimal> m_prices = new Dictionary<Size, decimal>
        {
            { Size.Small, 5 },
            { Size.Medium, 10 },
            { Size.Large, 15 },
        };

    }

    public class Espresso : Beverage
    {
        public override decimal Price(Size size)
        {
            return m_prices[size];
        }

        public override string Description()
        {
            return "Espresso";
        }

        private Dictionary<Beverage.Size, decimal> m_prices = new Dictionary<Size, decimal>
        {
            { Size.Small, 6 },
            { Size.Medium, 12 },
            { Size.Large, 18 },
        };

    }

    public class Mocha : BeverageDecorator
    {
        public Mocha(Beverage beverage)
        {
            m_beverage = beverage;
        }

        public override decimal Price(Size size)
        {
            return m_beverage.Price(size) + m_prices[size];
        }

        public override string Description()
        {
            return (m_beverage.Description() + " with a dash of Choco");
        }


        //private Beverage m_beverage;

        private Dictionary<Beverage.Size, decimal> m_prices = new Dictionary<Size, decimal>
        {
            { Size.Small, 1 },
            { Size.Medium, 2 },
            { Size.Large, 3 },
        };

    }


    public class Whip : BeverageDecorator
    {
        public Whip(Beverage beverage)
        {
            m_beverage = beverage;
        }

        public override decimal Price(Size size)
        {
            return m_beverage.Price(size) + m_prices[size];
        }

        public override string Description()
        {
            return (m_beverage.Description() + " with Whip on top");
        }
        
        private Dictionary<Beverage.Size, decimal> m_prices = new Dictionary<Size, decimal>
        {
            { Size.Small, (decimal)0.5 },
            { Size.Medium, 1 },
            { Size.Large, (decimal)1.5 },
        };

    }

    public class SmallCup : BeverageDecorator
    {
        public SmallCup(Beverage beverage)
        {
            m_beverage = beverage;
            m_size = Size.Small;
        }

        public override decimal Price()
        {
            return Price(m_size);
        }

        public override decimal Price(Size size)
        {
            return m_beverage.Price(size);
        }

        public override string Description()
        {
            return ("Small " + m_beverage.Description());
        }

        private Size m_size;
        
    }

    public class MediumCup : BeverageDecorator
    {
        public MediumCup(Beverage beverage)
        {
            m_beverage = beverage;
            m_size = Size.Medium;
        }

        public override decimal Price()
        {
            return Price(m_size);
        }

        public override decimal Price(Size size)
        {
            return m_beverage.Price(size);
        }

        public override string Description()
        {
            return ("Medium " + m_beverage.Description());
        }

        private Size m_size;

    }

    public class LargeCup : BeverageDecorator
    {
        public LargeCup(Beverage beverage)
        {
            m_beverage = beverage;
            m_size = Size.Large;
        }

        public override decimal Price()
        {
            return Price(m_size);
        }

        public override decimal Price(Size size)
        {
            return m_beverage.Price(size);
        }

        public override string Description()
        {
            return ("Large " + m_beverage.Description());
        }

        private Size m_size;

    }
}
