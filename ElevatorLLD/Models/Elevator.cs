using System;
using ElevatorLLD.Enums;

namespace ElevatorLLD.Models
{
	public class Elevator
	{
        public Elevator(int id)
        {
            Id = id;
            CurrentFloor = 0;
            Direction = Direction.Stationary;
            Status = ElevatorStatus.Available;
            Passengers = new();
            Queue = new();
        }

        public int Id { get; private set; }
		public int CurrentFloor { get; private set; }
		public Direction Direction { get; private set; }
        public ElevatorStatus Status { get; private set; }
        public List<Passenger> Passengers { get; private set; }
        public PriorityQueue<int, int> Queue { get; private set; }

        public void AddPassenger(Passenger passenger)
        {
            this.Passengers.Add(passenger);
            Console.WriteLine($"Elevator {Id}: Passenger {passenger.Id} entered the elevator going from floor {passenger.SourceFloor} to floor {passenger.DestinationFloor}.");
        }

        public void RemovePassenger(Passenger passenger)
        {
            this.Passengers.Remove(passenger);
            Console.WriteLine($"Elevator {Id}: Passenger {passenger.Id} exited the elevator.");
        }

        public void HandleRequest(int floor)
        {
            Queue.Enqueue(floor, floor);

            if (Status == ElevatorStatus.Available)
            {
                int nextFloor = Queue.Dequeue();
                MoveToFloor(nextFloor);
            }
        }

        public void MoveToFloor(int floor)
        {
            Console.WriteLine($"Elevator {Id}: Current Floor {CurrentFloor}");
            while (CurrentFloor != floor)
            {
                if (CurrentFloor < floor)
                {
                    CurrentFloor++;
                    Direction = Direction.Up;
                }
                else
                {
                    CurrentFloor--;
                    Direction = Direction.Down;
                }
                Console.WriteLine($"Elevator {Id}: Moved to Floor {CurrentFloor}");
            }

            //Console.WriteLine($"Elevator {Id}: Reached Floor {CurrentFloor}");
            //Thread.Sleep(1000);
        }
    }
}

