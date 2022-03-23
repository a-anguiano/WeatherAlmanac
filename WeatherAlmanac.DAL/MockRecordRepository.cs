using System;
using System.Collections.Generic;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.DAL
{
    public class MockRecordRepository : IRecordRepository
    {
        private List<DateRecord> _records;

        public MockRecordRepository()
        {
            _records = new List<DateRecord>();
            DateRecord bogus = new DateRecord();
            bogus.Date = new DateTime(2021, 12, 5); //made random date for testing
            bogus.HighTemp = 82;
            bogus.LowTemp = 40;
            bogus.Humidity = .30m;
            bogus.Description = "Really inconsistent weather today";
            _records.Add(bogus);
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            //add record to private field
            _records.Add(record);

            Result<DateRecord> result = new Result<DateRecord>();
            result.Data = record;
            result.Message = "";
            result.Success = true;

            return result;
            //throw new NotImplementedException();
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            throw new NotImplementedException();
        }

        public Result<List<DateRecord>> GetAll()
        {
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();
            result.Success = true;
            result.Message = "";
            result.Data = new List<DateRecord>(_records);
            return result;
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
