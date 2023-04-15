using SensorDashboard.Domain.Models;

namespace SensorDashboard.UnitTests.Domain
{
    public class SensorTests
    {
        [Test]
        public void SensorConstructor_ReturnsSensorWithCorrectProperties()
        {
            var id = 1;
            var name = "Test";

            Sensor sensor = new Sensor(id, name);

            Assert.Multiple(() =>
            {
                Assert.That(sensor.Id, Is.EqualTo(id));
                Assert.That(sensor.Name, Is.EqualTo(name));
            });
        }

        [Test]
        public void SensorConstructor_WhenInvalidId_ThrowsException()
        {
            var id = 0;
            var name = "Test";

            Assert.Throws<ArgumentException>(() =>
            {
                Sensor sensor = new Sensor(id, name);
            });
        }

        [Test]
        public void SensorConstructor_WhenInvalidName_ThrowsException()
        {
            var id = 1;
            var name = "";

            Assert.Throws<ArgumentException>(() =>
            {
                Sensor sensor = new Sensor(id, name);
            });
        }
    }
}
