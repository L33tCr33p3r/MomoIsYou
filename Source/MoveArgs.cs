using MomoIsYou.Source.Interface;

namespace MomoIsYou.Source
{
	internal struct MoveArgs
	{
		public ITile MoveTile;
		public Direction MoveDirection;
		public int xPos;
		public int yPos;

		public MoveArgs(ITile MoveTile, Direction MoveDirection, int xPos, int yPos)
		{
			this.MoveTile = MoveTile;
			this.MoveDirection = MoveDirection;
			this.xPos = xPos;
			this.yPos = yPos;
		}
	}
}