using System;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using WeatherAlmanac.DAL;

namespace WeatherAlmanac.BLL
{
    public class RecordServiceFactory
    {
        public static IRecordService GetRecordService(ApplicationMode mode)
        {
            if (mode == ApplicationMode.TEST)
            {
                return new RecordService(new MockRecordRepository());
            }
            else
            {
                throw new NotImplementedException();        //live version eventually
                //new RecordService(new FileRecordRepository());
            }
        }
    }
}
