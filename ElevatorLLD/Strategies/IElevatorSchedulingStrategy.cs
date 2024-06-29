using System;
using ElevatorLLD.Models;

namespace ElevatorLLD.Strategies
{
    public interface IElevatorSchedulingStrategy
    {
        Elevator? ScheduleElevator(ElevatorSystem system, int floor);
    }
}

