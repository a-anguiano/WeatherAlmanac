using System;

namespace WeatherAlmanac.UI
{
    class ConsoleIO
    {
        public string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public DateTime GetDate(string prompt)
        {
            DateTime result = new DateTime();   
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                if (!DateTime.TryParse(Console.ReadLine(), out result))  //datetime //|| (inputDate >= DateTime.Now
                {
                    //Error("Please input a proper date\n\n");
                    Console.Write("Invalid format, please enter a date in the past [mm/dd/yyyy]: ");
                    DateTime.TryParse(Console.ReadLine(), out result);
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }

        public int GetInt(string prompt)
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
        public decimal GetDecimal(string message)
        {
            decimal result = -1;
            //int result2 = 0;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{message}: ");
                if (!decimal.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper decimal\n\n");
                }
                else
                {
                    //return result2;
                    valid = true;
                }
            }
            return result;
        }

        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
