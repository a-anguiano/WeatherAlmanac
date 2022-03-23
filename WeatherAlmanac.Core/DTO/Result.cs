namespace WeatherAlmanac.Core.DTO
{
    public class Result<T>      //list, we can check our results
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }     //T allows to be anything basically
    }
}
