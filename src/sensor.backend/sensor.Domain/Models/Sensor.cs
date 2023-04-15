namespace sensor.Domain.Models
{
    public class Sensor
    {
        public int Id { get; }
        public string Name { get; }

        public Sensor(int id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive number", nameof(id));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            Id = id;
            Name = name;
        }
    }
}
