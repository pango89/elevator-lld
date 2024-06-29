using ElevatorLLD.Models;

namespace ElevatorLLD.Factories
{
	public class ElevatorFactory
	{
		public static Elevator CreateElevator(int id)
		{
			return new Elevator(id);
		}
	}
}

