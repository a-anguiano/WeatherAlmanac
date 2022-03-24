using System;
using System.Collections.Generic;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using System.Linq;

namespace WeatherAlmanac.BLL
{
    class RecordService : IRecordService
    {
        private IRecordRepository _repo;        //first we get the repo we work from

        public RecordService(IRecordRepository repo)    //initialize RecordService, puts in whichever repository
        {
            _repo = repo;
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            _repo.Add(record);
            Result<DateRecord> result = new Result<DateRecord>();   //empty result
            result.Success = true;
            result.Message = "";
            result.Data = record; //
            return result;

            //throw new NotImplementedException();
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            //DateRecord dr = new DateRecord();
            ////// todo: pass through to IRecordRepository
            //dr.HighTemp = record.HighTemp;
            //dr.LowTemp = record.LowTemp;
            //dr.Humidity = record.Humidity;
            //dr.Description = record.Description;

            Result<DateRecord> result = _repo.Edit(record);
            return result;

            // todo: pass through to IRecordRepository, this should only not be successful if the date doesn't exist
            // which should have been caught when retrieving the record to edit.
            throw new NotImplementedException();
        }

        public Result<DateRecord> Get(DateTime date)
        {            
            List<DateRecord> allDates = _repo.GetAll().Data;        //repos have GetAll method, we want just Data
                                                                        //in this case, Data = ...

            Result<DateRecord> result = new Result<DateRecord>();   //generating empty result variable of type
                                                                    //Result<DateRecord>

            for (int i = 0; i < allDates.Count; i++)    //validation within the service
            {

                if (allDates[i].Date == date)
                {
                    result.Success = true;
                    result.Message = "";        //stringbuilder
                    result.Data = allDates[i];  
                }
            }
            return result;
            //throw new NotImplementedException();
        }

        public Result<List<DateRecord>> LoadRange(DateTime start, DateTime end)
        {
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();   //empty 

            List<DateRecord> list = new List<DateRecord>();     //empty list of date records

            // todo: check to see that start is before end date
            //dictionary, keys are ticks, older has less ticks
            if (start.Ticks < end.Ticks)
            {
            //look at later!!!!!
            }

            // todo: filter records from repository get all based on date range           
            List<DateRecord> allDates = _repo.GetAll().Data;
            List<DateRecord> orderedRange = allDates.OrderBy(d => d.Date).ToList(); //hmmm <=

            foreach (DateRecord d in orderedRange)
            {
                if (d.Date >= start && d.Date <= end)
                {
                    DateRecord dr = new DateRecord();
                    dr = d;         
                    list.Add(dr);
                }
            }

            result.Success = true;
            result.Message = "";
            result.Data = list;             //list of date record(s) in the range

            return result;
           // throw new NotImplementedException();
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            // todo: pass through to IRecordRepository
            Result<DateRecord> result = _repo.Remove(date);
            return result;
            //throw new NotImplementedException();
        }
    }

}
