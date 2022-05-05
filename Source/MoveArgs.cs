using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source
{
	internal struct MoveArgs
	{
		public BaseTile MoveTile;
		public Direction MoveDirection;
		public int xPos;
		public int yPos;

		public MoveArgs(BaseTile MoveTile, Direction MoveDirection, int xPos, int yPos)
		{
			this.MoveTile = MoveTile;
			this.MoveDirection = MoveDirection;
			this.xPos = xPos;
			this.yPos = yPos;
		}
	}
}