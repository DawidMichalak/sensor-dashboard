namespace sensor.Domain.Exceptions
{
    public class InvalidDateRangeException : Exception
    {
        public InvalidDateRangeException() : base("Invalid date range")
        {
        }
    }
}
