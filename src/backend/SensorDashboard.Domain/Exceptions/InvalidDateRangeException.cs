namespace SensorDashboard.Domain.Exceptions
{
    public class InvalidDateRangeException : Exception
    {
        public InvalidDateRangeException() : base("Invalid date range")
        {
        }
    }
}
