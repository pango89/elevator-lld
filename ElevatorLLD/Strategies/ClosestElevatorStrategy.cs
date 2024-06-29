using ElevatorLLD.Models;

namespace ElevatorLLD.Strategies
{
	public class ClosestElevatorStrategy : IElevatorSchedulingStrategy
    {
        public Elevator? ScheduleElevator(ElevatorSystem system, int floor)
        {
            Elevator? closestElevator = null;

            int minDistance = int.MaxValue;

            foreach (Elevator elevator in system.Elevators)
            {
                int currDistance = Math.Abs(elevator.CurrentFloor - floor);
                if (currDistance < minDistance)
                {
                    minDistance = currDistance;
                    closestElevator = elevator;
                }
            }

            return closestElevator;
        }
    }
}

