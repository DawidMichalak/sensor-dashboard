namespace SensorDashboard.Api.Messaging.Processing
{
    public interface ISensorMessageProcessor
    {
        Task ProcessMessage(string body, long unixTimeStamp);
    }
}
