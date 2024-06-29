using System;
namespace ElevatorLLD.Models
{
	public class PassengerRequest
	{
        public PassengerRequest(Passenger passenger, int source, int destination)
        {
            Passenger = passenger;
            Source = source;
            Destination = destination;
        }

        public Passenger Passenger { get; private set; }
		public int Source { get; private set; }
		public int Destination { get; private set; }
    }
}

