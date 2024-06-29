using ElevatorLLD.Models;
using ElevatorLLD.Enums;

namespace ElevatorLLD.Strategies
{
	public class FCFSElevatorStrategy : IElevatorSchedulingStrategy
    {
        public Elevator? ScheduleElevator(ElevatorSystem system, int floor)
        {
            foreach (Elevator elevator in system.Elevators)
                if (elevator.Status == ElevatorStatus.Available)
                    return elevator;

            return null;
        }
    }
}

