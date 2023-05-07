using SensorDashboard.Domain.Models;

namespace SensorDashboard.UnitTests.Domain
{
    public class ConfigurationItemTests
    {
        [Test]
        public void ConfigurationItemConstructor_ReturnsConfigurationItemWithCorrectProperties()
        {
            var sensorId = 1;
            var name = "Test";

            var metadata = new ConfigurationItem(name, sensorId);

            Assert.Multiple(() =>
            {
                Assert.That(metadata.SensorId, Is.EqualTo(sensorId));
                Assert.That(metadata.Name, Is.EqualTo(name));
            });
        }

        [Test]
        public void ConfigurationItemConstructor_WhenInvalidId_ThrowsException()
        {
            var sensorId = 10;
            var name = "";

            Assert.Throws<ArgumentException>(() =>
            {
                var metadata = new ConfigurationItem(name, sensorId);
            });
        }
    }
}
