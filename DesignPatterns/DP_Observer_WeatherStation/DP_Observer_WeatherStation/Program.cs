using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Observer_WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay();
            WeatherStatsDisplay weatherStatsDisplay = new WeatherStatsDisplay();
            WeatherData weatherData = new WeatherData();

            Console.WriteLine("\nNo observer registers - no one will report the event\n");
            weatherData.SetEvent(25, 70);

            weatherData.Register(currentConditionsDisplay);
            Console.WriteLine("\ncurrentConditionsDisplay registered to report event\n");
            weatherData.SetEvent(27, 65);

            weatherData.Register(weatherStatsDisplay);
            Console.WriteLine("\ncurrentConditionsDisplay and weatherStatsDisplay (2) registered to report event\n");
            weatherData.SetEvent(30, 43);

            weatherData.Register(currentConditionsDisplay);
            Console.WriteLine("\ncurrentConditionsDisplay - weatherStatsDisplay - currentConditionsDisplay (3) registered to report event\n");
            weatherData.SetEvent(21, 90);

            weatherData.UnRegister(currentConditionsDisplay);
            Console.WriteLine("\nweatherStatsDisplay - currentConditionsDisplay (3) registered to report event\n");
            weatherData.SetEvent(35, 20);


        }
    }
}
