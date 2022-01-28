using System;
using System.Collections.Generic;
using System.Text;

namespace MomoIsYou
{
	internal class MoveArg
	{
		public Direction moveDirection;
		public int xPos;
		public int yPos;
		public MoveArg(Direction moveDirection, int xPos, int yPos)
        {
			this.moveDirection = moveDirection;
			this.xPos = xPos;
			this.yPos = yPos;
        }
	}
}
