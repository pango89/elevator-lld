using System;
using ElevatorLLD.Interfaces;

namespace ElevatorLLD.Models
{
	public class Passenger
	{
        public Passenger(int id, int sourceFloor, int destinationFloor)
        {
            Id = id;
            SourceFloor = sourceFloor;
            DestinationFloor = destinationFloor;
            IsInsideElevator = false;
        }

        public int Id { get; private set; }
		public int SourceFloor { get; private set; }
		public int DestinationFloor { get; private set; }
		public bool IsInsideElevator { get; private set; }

        public Elevator? RequestElevator(IElevatorController elevatorController)
        {
            if (IsInsideElevator)
            {
                Console.WriteLine($"Passenger {Id}: Already inside an elevator.");
                return null;
            }

            Console.WriteLine($"Passenger {Id}: Requesting an elevator to go from floor {SourceFloor} to floor {DestinationFloor}");
            Elevator? elevator = elevatorController.RequestElevator(SourceFloor);

            if (elevator == null)
            {
                Console.WriteLine($"Passenger {Id}: No available elevators. Waiting...");
                return null;
            }

            return elevator;
        }

        public void EnterElevator(Elevator elevator)
        {
            if (IsInsideElevator)
            {
                Console.WriteLine($"Passenger {Id}: Already inside the elevator {elevator.Id}.");
                return;
            }

            elevator.AddPassenger(this);
            IsInsideElevator = true;
            Console.WriteLine($"Passenger {Id}: Entering elevator {elevator.Id} at floor {elevator.CurrentFloor}");
        }

        public void ExitElevator(Elevator elevator)
        {
            if (!IsInsideElevator)
            {
                Console.WriteLine($"Passenger {Id}: Not inside any elevator.");
                return;
            }

            elevator.RemovePassenger(this);
            IsInsideElevator = false;

            Console.WriteLine($"Passenger {Id}: Exiting elevator {elevator.Id} at floor {elevator.CurrentFloor}");
        }
    }
}

