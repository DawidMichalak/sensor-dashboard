﻿namespace sensor.Domain.Models
{
    public class Reading
    {
        public string? Id { get; init; }
        public int Value { get; init; }
        public DateTime Timestamp { get; init; }
        public ReadingMetadata Metadata { get; init; }
    }
}