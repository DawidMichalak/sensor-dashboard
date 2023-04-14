﻿using MediatR;

namespace sensor.Application.Sensors.Commands
{
    public class AddSensorCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
