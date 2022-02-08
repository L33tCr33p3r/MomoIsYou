using System;
using System.Collections.Generic;
using System.Text;

namespace MomoIsYou
{
	internal class Level
	{
		public List<Tile>[,] Map;

		public bool Move(Tile StartTile, Direction MoveDir, int yPos, int xPos)
		{
			int yTarg = yPos;
			int xTarg = xPos;
			if (MoveDir == Direction.UP)
			{
				yTarg = yPos - 1;
			}
			else if (MoveDir == Direction.DOWN)
			{
				yTarg = yPos + 1;
			}
			else if (MoveDir == Direction.LEFT)
			{
				xTarg = xPos - 1;
			}
			else if (MoveDir == Direction.RIGHT)
			{
				xTarg = xPos + 1;
			}

			if (MoveCheck(MoveDir, yPos, xPos))
			{
				for(int listPos = 0; listPos < Map[yTarg, xTarg].Capacity; listPos++)
				{
					Tile TargetTile = Map[yTarg, xTarg][listPos];
					if (TargetTile.IsPush) Move(TargetTile, MoveDir, yTarg, xTarg);
				}
				Map[yTarg, xTarg].Add(StartTile);
				Map[yPos, xPos].Remove(StartTile);
				Map[yPos, xPos].TrimExcess();

				return true;
			}
			else return false;
		}
		public bool MoveCheck(Direction MoveDir, int yPos, int xPos)
		{
			int yTarg = yPos;
			int xTarg = xPos;
			if (MoveDir == Direction.UP)
			{
				if (yPos == 0) return false; //Prevent array overflows
				yTarg = yPos - 1;
			}
			else if (MoveDir == Direction.DOWN)
			{
				if (yPos + 1 >= Map.GetLength(0)) return false; //Prevent array overflows
				yTarg = yPos + 1;
			}
			else if (MoveDir == Direction.LEFT)
			{
				if (xPos == 0) return false; //Prevent array overflows
				xTarg = xPos - 1;
			}
			else if (MoveDir == Direction.RIGHT)
			{
				if (xPos + 1 >= Map.GetLength(1)) return false; //Prevent array overflows
				xTarg = xPos + 1;
			}

			foreach (Tile TargetTile in Map[yTarg, xTarg])
			{
				if (TargetTile.IsPush)
				{
					if (!MoveCheck(MoveDir, yTarg, xTarg)) return false;
				}
				else if (TargetTile.IsColide) return false;
			}
			return true;
		}
	}
}