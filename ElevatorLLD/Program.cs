using ElevatorLLD.Interfaces;
using ElevatorLLD.Models;
using ElevatorLLD.Strategies;

internal class Program
{
    private static void Main(string[] args)
    {
        IElevatorController elevatorSystem = new ElevatorSystem(3, new ClosestElevatorStrategy());
        elevatorSystem.DisplayCurrentPositions();

        Move(elevatorSystem, 1, 2, 5);
        Move(elevatorSystem, 2, 1, 15);
        Move(elevatorSystem, 3, 12, 4);
        Move(elevatorSystem, 3, 1, 0);

        Console.ReadLine();
    }

    private static void Move(IElevatorController elevatorSystem, int passengerId, int source, int destination)
    {
        Passenger passenger = new Passenger(passengerId, source, destination);
        Elevator? elevator = passenger.RequestElevator(elevatorSystem);
        elevator?.HandleRequest(passenger.SourceFloor);
        passenger.EnterElevator(elevator);
        elevator?.HandleRequest(passenger.DestinationFloor);
        passenger.ExitElevator(elevator);
        elevatorSystem.DisplayCurrentPositions();
    }
}