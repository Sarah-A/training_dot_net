using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This is my TODO list: 
 * test Equals with null
 * test Equals with a different objec
 * 

*/

namespace MoneyCoverter_TddByExample
{
    public class Money
    {
        private double _value;
        private string _currency;

        public Money(double val, string currency)
        {
            _value = val;
            _currency = currency;
        }

        public int Multiply(int byVal)
        {
            return (_value * byVal);            
        }

        private double ReducedVal(string toCurrency)
        {
            if( toCurrency == _currency)
            {
                return _value;
            }
            else
            {
                return Bank.Convert(_value, _currency, toCurrency);
            }
        }


        public override bool Equals(Object obj)
        {
            ////if(obj == null)
            ////{
            ////    return false;
            ////}

            Money mn = obj as Money;
            ////if((Object)mn == null)
            ////{
            ////    return false;
            ////}

            if (_currency == mn._currency)
            {
                if (_value == mn._value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // different currency - translate from 2nd object to this one and compare
                if(_value == mn.ReducedVal("USD"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        public Money Plus(Money mn)
        {
            return new Money(_value + mn._value, _currency);
        }
    }
}
