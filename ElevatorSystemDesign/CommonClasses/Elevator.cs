using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorSystemDesign.CommonClasses
{
    class Elevator
    {
        private int location = 0;
        private Direction direction = Direction.Up;
        private State state = State.Stopped;
        private DoorState door = DoorState.Closed;

		private Thread processingThread;
		private Thread listeningThread;

		public class Request
		{
			public long time;
			public int floor;
			public Direction direction;

			public Request(long time, int floor, Direction direction)
			{
				this.time = time;
				this.floor = floor;
				this.direction = direction;
			}
		}
	}
}
