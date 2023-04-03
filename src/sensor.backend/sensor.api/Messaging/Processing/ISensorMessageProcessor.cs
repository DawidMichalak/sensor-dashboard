namespace sensor.api.Messaging.Processing
{
    public interface ISensorMessageProcessor
    {
        Task ProcessMessage(string body, long unixTimeStamp);
    }
}