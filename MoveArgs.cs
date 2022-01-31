namespace MomoIsYou
{
	internal struct MoveArgs
	{
		public Tile MoveTile;
		public Direction MoveDirection;
		public int xPos;
		public int yPos;

		public MoveArgs(Tile MoveTile, Direction MoveDirection, int xPos, int yPos)
		{
			this.MoveTile = MoveTile;
			this.MoveDirection = MoveDirection;
			this.xPos = xPos;
			this.yPos = yPos;
		}
	}
}