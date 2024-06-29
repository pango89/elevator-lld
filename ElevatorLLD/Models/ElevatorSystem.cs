using System;
using ElevatorLLD.Factories;
using ElevatorLLD.Interfaces;
using ElevatorLLD.Strategies;

namespace ElevatorLLD.Models
{
    public class ElevatorSystem : IElevatorController
    {
        public int BottomFloor { get; private set; }
        public int TopFloor { get; private set; }
        public List<Elevator> Elevators { get; private set; }
        private readonly IElevatorSchedulingStrategy schedulingStrategy;

        public ElevatorSystem(int elevatorCount, IElevatorSchedulingStrategy schedulingStrategy)
        {
            this.BottomFloor = 0;
            this.TopFloor = 15;
            this.Elevators = new();

            for (int i = 1; i <= elevatorCount; i++)
                this.Elevators.Add(ElevatorFactory.CreateElevator(i));

            this.schedulingStrategy = schedulingStrategy;
        }

        public Elevator? RequestElevator(int floor)
        {
            return schedulingStrategy.ScheduleElevator(this, floor);
        }

        public void DisplayCurrentPositions()
        {
            Console.WriteLine("**********************");
            for (int i = TopFloor; i >= BottomFloor; i--)
            {
                List<Elevator> elevators = Elevators.FindAll(x => x.CurrentFloor == i);
                if (elevators != null && elevators.Count > 0)
                {
                    Console.WriteLine("Floor {0} = [{1}]", i, string.Join(", ", elevators.Select(x => x.Id)));
                }
                else
                {
                    Console.WriteLine("Floor {0} = []", i);
                }
            }
            Console.WriteLine("**********************");
        }
    }
}

