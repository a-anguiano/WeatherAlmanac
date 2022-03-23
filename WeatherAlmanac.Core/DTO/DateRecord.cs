using System;
using System.Text;

namespace WeatherAlmanac.Core.DTO
{
    public class DateRecord
    {
        public DateTime Date { get; set; }
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
        public decimal Humidity { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Date.ToString("MMMM dd, yyyy"));  //proper format
            sb.AppendLine($"High: {HighTemp}F");
            sb.AppendLine($"Low: {LowTemp}F");
            sb.AppendLine($"Humidity: {Humidity * 100}%");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
