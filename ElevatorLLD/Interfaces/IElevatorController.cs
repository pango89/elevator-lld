using ElevatorLLD.Models;

namespace ElevatorLLD.Interfaces
{
	public interface IElevatorController
	{
		Elevator? RequestElevator(int floor);
		void DisplayCurrentPositions();
    }
}

