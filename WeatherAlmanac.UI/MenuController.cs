using System;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using System.Collections.Generic;

namespace WeatherAlmanac.UI
{
    class MenuController
    {
        private ConsoleIO _ui;
        public IRecordService Service { get; set; }

        public MenuController(ConsoleIO ui)
        {
            _ui = ui;
        }

        public ApplicationMode Setup()
        {
            _ui.Display("Welcome to the Weather Almanac");
            _ui.Display("==============================\n");
            
            _ui.Display("What mode would you like to run in?");
            _ui.Display("1. Test");
            _ui.Display("2. Live");

            int mode = _ui.GetInt("Select mode");
            if (mode == 1)
            {
                return ApplicationMode.TEST;
            }
            else if (mode == 2)
            {
                return ApplicationMode.LIVE;
            }
            else
            {
                _ui.Error("Invalid mode.  Exiting.");
                Environment.Exit(0);
                return ApplicationMode.TEST; //?? The program has exited here.
            }
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                switch (GetMenuChoice())
                {
                    case 1:
                        LoadRecord();
                        break;
                    case 2:
                        ViewRecordsByDateRange();
                        break;
                    case 3:
                        AddRecord();
                        break;
                    case 4:
                        EditRecord();
                        break;
                    case 5:
                        DeleteRecord();
                        break;
                    case 6:
                        //Quit
                        running = false;
                        break;
                    default:
                        //Huh??
                        _ui.Error("Invalid menu option");
                        break;

                }

            }

        }

        public int GetMenuChoice()
        {
            DisplayMenu();
            return _ui.GetInt("Enter Choice");
        }
        public void DisplayMenu()
        {
            _ui.Display("Main Menu");
            _ui.Display("==================================");
            _ui.Display("1. Load a record");
            _ui.Display("2. View Records by Date Range");
            _ui.Display("3. Add Record");
            _ui.Display("4. Edit Record");
            _ui.Display("5. Delete Record");
            _ui.Display("6. Quit");
        }

        public void LoadRecord()
        {
            _ui.Display("Load Record");

            //check if user input is able to be parsed into DateTime

            DateTime date = DateTime.Parse(_ui.PromptUser("Enter a date: "));
            Result<DateRecord> result = Service.Get(date);
            _ui.Display(result.Data.ToString());
        }

        public void ViewRecordsByDateRange()
        {
            _ui.Display("View Records By Date Range");
            DateTime start = DateTime.Parse(_ui.PromptUser("Enter a starting date:"));
            DateTime end = DateTime.Parse(_ui.PromptUser("Enter a ending date:"));
            Result<List<DateRecord>> result = Service.LoadRange(start, end);        //result is a list of date records
            foreach (DateRecord d in result.Data)       //looking at just Data part
            {
                _ui.Display(d.ToString());
            }
            //chronological order
        }

        public void AddRecord()
        {
            _ui.Display("Add Record");
            DateTime date = DateTime.Parse(_ui.PromptUser("What's the date?"));
            int highTemp = _ui.GetInt("What's the High Temp?");
            int lowTemp = _ui.GetInt("What's the Low Temp?");
            decimal humid = _ui.GetDecimal("What's the Humidity?");     //change from int to dec
            
            string description = _ui.PromptUser("What's the Description?");

            DateRecord dr = new DateRecord();   //huh
            dr.Date = date;
            dr.HighTemp = highTemp;
            dr.LowTemp = lowTemp;
            dr.Humidity = humid/100;
            dr.Description = description;
            Result<DateRecord> result = Service.Add(dr);
            _ui.Display(result.Data.ToString());
        }

        public void EditRecord()
        {
            _ui.Display("Edit Record");
            DateTime date = DateTime.Parse(_ui.PromptUser("What's the date you wish to edit?"));

            Result<DateRecord> result = Service.Get(date);

            //_ui.Display(result.Data.ToString());


            decimal highTempChange = _ui.GetDecimal($"High ({result.Data.HighTemp}) : ");            //display old info
            decimal lowTempChange = _ui.GetDecimal($"Low ({result.Data.LowTemp}) : ");
            decimal humidChange = _ui.GetDecimal($"Humidity ({result.Data.Humidity}) : ");     

            string descriptionChange = _ui.PromptUser($"Description ({result.Data.Description}) : ");

            DateRecord dr = new DateRecord();   //new empty date record type to send to service
            dr.Date = date;
            dr.HighTemp = highTempChange;
            dr.LowTemp = lowTempChange;
            dr.Humidity = humidChange / 100;
            dr.Description = descriptionChange;
            Result<DateRecord> newResult = Service.Edit(dr);
            //_ui.Display(newResult.Data.ToString());                 //just to test
        }

        public void DeleteRecord()
        {
            _ui.Display("Delete Record");
            DateTime date = DateTime.Parse(_ui.PromptUser("Enter a date to remove: "));
            Result<DateRecord> result = Service.Get(date);
            _ui.Display(result.Data.ToString());

            Result<DateRecord> result2 = Service.Remove(date);

            //_ui.Display(result2.Data.ToString()); //hmmm
        }
    }
}