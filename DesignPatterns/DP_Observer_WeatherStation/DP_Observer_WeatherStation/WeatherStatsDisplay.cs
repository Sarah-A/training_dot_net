using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Observer_WeatherStation
{
    public class WeatherStatsDisplay : IWeatherDataObserver
    {
        private int _totalTemp = 0;
        private int _totalHumidity = 0;
        private int _numOfSamples = 0;
        private int _averageTemp = 0;
        private int _averageHumidity = 0;

        public void Update(int temp, int humidity)
        {
            _totalTemp += temp;
            _totalHumidity += humidity;
            ++_numOfSamples;

            if(_totalTemp != 0)
            {
                _averageTemp = _totalTemp / _numOfSamples;
            }
            else 
            {
                _averageTemp = 0;
            }
            if (_totalHumidity != 0)
            {
                _averageHumidity = _totalHumidity / _numOfSamples;
            }
            else
            {
                _averageHumidity = 0;
            }

            Console.WriteLine("Weather Statistics:\t\t Average Temp: {0} Degrees , Average Humidity: {1} Percent. Total samples: {2}", 
                                _averageTemp, _averageHumidity, _numOfSamples);

        }
    }
}
