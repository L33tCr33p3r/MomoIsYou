using System;
using System.Collections.Generic;
using System.Text;

namespace MomoIsYou
{
	internal class Level
	{
		public List<Tile>[,] Map;

		public bool Move(Tile StartTile, Direction MoveDir, int yPos, int xPos, int RecurseDepth = 0)
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
				List<Tile> TargSpace = Map[yTarg, xTarg];
				List<Tile> SelfSpace = Map[yPos, xPos];
				TargSpace.TrimExcess();
				int listPos = 0;
				int MaxTargIndex = TargSpace.Capacity - 1;
				while (listPos <= MaxTargIndex)
				{
					Console.WriteLine(listPos);
					Console.WriteLine(MaxTargIndex);
					Console.WriteLine(RecurseDepth);
					Console.WriteLine();

					if (listPos > MaxTargIndex) break;
					Tile TargetTile = TargSpace[listPos];
					if (TargetTile.IsPush)
					{
						Move(TargetTile, MoveDir, yTarg, xTarg, RecurseDepth + 1);
						MaxTargIndex--;
					}
					else listPos++;
				}
				TargSpace.Add(StartTile);
				SelfSpace.Remove(StartTile);
				SelfSpace.TrimExcess();

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