using System;
using System.Collections.Generic;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.DAL
{
    public class FileRecordRepository : IRecordRepository
    {
        public Result<List<DateRecord>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            throw new NotImplementedException();
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
