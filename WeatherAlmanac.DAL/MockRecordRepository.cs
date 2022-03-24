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

        public Result<DateRecord> Edit(DateRecord record)       //here the record is already "updated"
        {
            //Replace DateRecord property

            //if null, leave it old; replace otherwise with new            
            Result<DateRecord> result = new Result<DateRecord>();
            result.Data = record;
            result.Message = "";
            result.Success = true;

            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].Date == record.Date)
                {
                    _records[i] = record;
                }
            }
            return result;
            //throw new NotImplementedException();
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
            Result<DateRecord> result = new Result<DateRecord>();
                        
            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].Date == date)
                {                    
                    result.Data = _records[i];         
                    result.Message = "";
                    result.Success = true;              //technically only part "you need"
                    _records.Remove(_records[i]);
                }
            }
            return result;
        } 
            //throw new NotImplementedException();
    }
}
