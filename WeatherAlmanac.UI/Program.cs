using System;
using WeatherAlmanac.BLL;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using WeatherAlmanac.UI;


namespace WeatherAlmanac
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO ui = new ConsoleIO();
            MenuController menu = new MenuController(ui);
            ApplicationMode mode = menu.Setup();  //Get test vs live mode
            IRecordService service = RecordServiceFactory.GetRecordService(mode);
            menu.Service = service;
            menu.Run();    //Do the thing!
        }
    }
}
