using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Observer_WeatherStation
{
    public class CurrentConditionsDisplay : IWeatherDataObserver
    {
        // Consider:
        //          If we want the displays to register themselves automatically to the subject - we should add a reference to the 
        //          subject as a private member and send it in the constructor.
        //          If the registeration and removal should be controlled from outside - we should implemet it like this - with the 
        //          observers not having the subject as a member.


        public void Update(int temp, int humidity)
        {
            Console.WriteLine("Current Conditions Display:\t Temp: {0} Degrees , Humidity: {1} Percent", temp, humidity);
        }
    }
}
