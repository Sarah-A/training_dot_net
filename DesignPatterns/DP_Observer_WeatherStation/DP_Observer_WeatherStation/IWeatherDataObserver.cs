using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Observer_WeatherStation
{
    interface IWeatherDataObserver
    {
        // consider: do we want to push all data from the weather station or
        //           do we want each observer to pull only the data it needs through public getters in the subejct?
        //           Is the WeatherData expected to change and add additional measurements in the future?
        //           I think teh pull version is more decoupled and not more complicated and therefore better.
        void Update(int temp, int humidity);
    }
}
