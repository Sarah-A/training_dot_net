using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// Duck is the class that uses strategy.
    /// Strategy can be used to avoid code duplication. Instead of having two complete implementation with a small different duck types 
    /// </summary>
    public class Duck
    {
        public Duck(IStrategyCall call)
        {
            call_ = call;
        }

        public string Call()
        {
            return call_.Call();
        }

        //---------------------------------------
        // Member variables:
        //---------------------------------------
        private IStrategyCall call_;
    }

    public interface IStrategyCall
    {
        string Call();
    }

    public class IStrategyCall_Quack : IStrategyCall
    {
        public string Call()
        {
            return "Quack";
        }
    }

    public class IStrategyCall_Qual : IStrategyCall
    {
        public string Call()
        {
            return "Qual";
        }
    }

}
