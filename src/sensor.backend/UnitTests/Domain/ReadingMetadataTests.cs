using sensor.Domain.Models;

namespace UnitTests.Domain
{
    public class ReadingMetadataTests
    {
        [Test]
        public void ReadingMetadataConstructor_ReturnsReadingMetadataWithCorrectProperties()
        {
            var sensorId = 1;
            var type = "Test";

            var metadata = new ReadingMetadata(sensorId, type);

            Assert.Multiple(() =>
            {
                Assert.That(metadata.SensorId, Is.EqualTo(sensorId));
                Assert.That(metadata.Type, Is.EqualTo(type));
            });
        }

        [Test]
        public void ReadingMetadataConstructor_WhenInvalidId_ThrowsException()
        {
            var sensorId = -1;
            var type = "Test";

            Assert.Throws<ArgumentException>(() =>
            {
                var metadata = new ReadingMetadata(sensorId, type);
            });
        }

        [Test]
        public void ReadingMetadataConstructor_WhenInvalidType_ThrowsException()
        {
            var sensorId = 1;
            var type = "";

            Assert.Throws<ArgumentException>(() =>
            {
                var metadata = new ReadingMetadata(sensorId, type);
            });
        }
    }
}
