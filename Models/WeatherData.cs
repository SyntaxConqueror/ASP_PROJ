
using System;
using System.Collections.Generic;
namespace ASP_MVC_PROJ.Models
{
    

    public class WeatherData
    {
        public List<WeatherItem> Items { get; set; }
    }

    public class WeatherItem
    {
        public DateTime Date { get; set; }
        public int Period { get; set; }
        public object FreshSnow { get; set; } // Adjust the type based on the actual data type
        public WeatherDetails Weather { get; set; }
        public object SunHours { get; set; } // Adjust the type based on the actual data type
        public object RainHours { get; set; } // Adjust the type based on the actual data type
        public PrecipitationDetails Prec { get; set; }
        public TemperatureDetails Temperature { get; set; }
        public object Pressure { get; set; } // Adjust the type based on the actual data type
        public int RelativeHumidity { get; set; }
        public CloudDetails Clouds { get; set; }
        public WindDetails Wind { get; set; }
        public WindchillDetails Windchill { get; set; }
        public SnowLineDetails SnowLine { get; set; }
        public bool IsNight { get; set; }
    }

    public class WeatherDetails
    {
        public int State { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
    }

    public class PrecipitationDetails
    {
        public double Sum { get; set; }
        public int Probability { get; set; }
        public object SumAsRain { get; set; } // Adjust the type based on the actual data type
        public int Class { get; set; }
    }

    public class TemperatureDetails
    {
        public int Avg { get; set; }
    }

    public class CloudDetails
    {
        public object High { get; set; } // Adjust the type based on the actual data type
        public object Low { get; set; } // Adjust the type based on the actual data type
        public object Middle { get; set; } // Adjust the type based on the actual data type
    }

    public class WindDetails
    {
        public string Unit { get; set; }
        public string Direction { get; set; }
        public string Text { get; set; }
        public int Avg { get; set; }
        public object Min { get; set; } // Adjust the type based on the actual data type
        public object Max { get; set; } // Adjust the type based on the actual data type
        public bool SignificationWind { get; set; }
    }

    public class WindGustsDetails
    {
        public int Value { get; set; }
        public object Text { get; set; } // Adjust the type based on the actual data type
    }

    public class WindchillDetails
    {
        public int Avg { get; set; }
        public object Min { get; set; } // Adjust the type based on the actual data type
        public object Max { get; set; } // Adjust the type based on the actual data type
    }

    public class SnowLineDetails
    {
        public object Avg { get; set; } // Adjust the type based on the actual data type
        public object Min { get; set; } // Adjust the type based on the actual data type
        public object Max { get; set; } // Adjust the type based on the actual data type
        public string Unit { get; set; }
    }
}
