using System;
using System.Collections.Generic;
using WeatherAlmanac.Core.DTO;

namespace WeatherAlmanac.Core.Interface
{
    public interface IRecordRepository              //Says Methods needed, but not how they work
    {
        Result<List<DateRecord>> GetAll();          // Retrieves all records from storage
        Result<DateRecord> Add(DateRecord record);  // Adds a record to storage
        Result<DateRecord> Remove(DateTime date);   // Removes record for date
        Result<DateRecord> Edit(DateRecord record); // Replaces a record with the same date
    }
}
