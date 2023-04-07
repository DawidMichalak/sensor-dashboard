namespace sensor.Api.Requests
{
    public class GetReadingRequest
    {
        public DateTime BeginDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}
