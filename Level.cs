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
			if (MoveDir == Direction.UP)
			{
				if (MoveCheck(MoveDir, yPos, xPos))
				{
					foreach (Tile TargetTile in Map[yPos - 1, xPos])
					{
						if (TargetTile.IsPush) Move(TargetTile, MoveDir, yPos - 1, xPos);
					}
					Map[yPos - 1, xPos].Add(StartTile);
					Map[yPos, xPos].Remove(StartTile);
					return true;
				}
				else return false;
			}
			if (MoveDir == Direction.DOWN)
			{
				if (MoveCheck(MoveDir, yPos, xPos))
				{
					foreach (Tile TargetTile in Map[yPos + 1, xPos])
					{
						if (TargetTile.IsPush) Move(TargetTile, MoveDir, yPos + 1, xPos);
					}
					Map[yPos + 1, xPos].Add(StartTile);
					Map[yPos, xPos].Remove(StartTile);
					return true;
				}
				else return false;
			}
			if (MoveDir == Direction.LEFT)
			{
				if (MoveCheck(MoveDir, yPos, xPos))
				{
					foreach (Tile TargetTile in Map[yPos, xPos - 1])
					{
						if (TargetTile.IsPush) Move(TargetTile, MoveDir, yPos, xPos - 1);
					}
					Map[yPos, xPos - 1].Add(StartTile);
					Map[yPos, xPos].Remove(StartTile);
					return true;
				}
				else return false;
			}
			if (MoveDir == Direction.RIGHT)
			{
				if (MoveCheck(MoveDir, yPos, xPos))
				{
					foreach (Tile TargetTile in Map[yPos, xPos + 1])
					{
						if (TargetTile.IsPush) Move(TargetTile, MoveDir, yPos, xPos + 1);
					}
					Map[yPos, xPos + 1].Add(StartTile);
					Map[yPos, xPos].Remove(StartTile);
					return true;
				}
				else return false;
			}
			else return false;
        }
		public bool MoveCheck(Direction MoveDir, int yPos, int xPos)
		{
			if (MoveDir == Direction.UP)
			{
				if (yPos == 0) return false; //Prevent array overflows
				foreach (Tile TargetTile in Map[yPos - 1, xPos])
				{
					if (TargetTile.IsPush)
					{
						if (!MoveCheck(MoveDir, yPos - 1, xPos)) return false;
					}
					else if (TargetTile.IsColide) return false;
				}
				return true;
			}
			else if (MoveDir == Direction.DOWN)
			{
				if (yPos + 1 >= Map.GetLength(0)) return false; //Prevent array overflows
				foreach (Tile TargetTile in Map[yPos + 1, xPos])
				{
					if (TargetTile.IsPush)
					{
						if (!MoveCheck(MoveDir, yPos + 1, xPos)) return false;
					}
					else if (TargetTile.IsColide) return false;
				}
				return true;
			}
			else if (MoveDir == Direction.LEFT)
			{
				if (xPos == 0) return false; //Prevent array overflows
				foreach (Tile TargetTile in Map[xPos - 1, yPos])
				{
					if (TargetTile.IsPush)
					{
						if (!MoveCheck(MoveDir, xPos - 1, yPos)) return false;
					}
					else if (TargetTile.IsColide) return false;
				}
				return true;
			}
			else if (MoveDir == Direction.RIGHT)
			{
				if (xPos + 1 >= Map.GetLength(0)) return false; //Prevent array overflows
				foreach (Tile TargetTile in Map[xPos + 1, yPos])
				{
					if (TargetTile.IsPush)
					{
						if (!MoveCheck(MoveDir, xPos + 1, yPos)) return false;
					}
					else if (TargetTile.IsColide) return false;
				}
				return true;
			}
			else return false;
		}
	}
}