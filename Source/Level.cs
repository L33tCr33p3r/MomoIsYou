using System;
using System.Collections.Generic;
using System.Text;
using MomoIsYou.Source.Interface;

namespace MomoIsYou.Source
{
	internal class Level
	{
		public List<ITile>[,] Map;

		public bool Move(ITile StartTile, Direction MoveDir, int yPos, int xPos, bool Debug, int RecurseDepth = 0)
		{
			int yTarg = yPos;
			int xTarg = xPos;

			if (MoveDir == Direction.UP) yTarg = yPos - 1;
			else if (MoveDir == Direction.DOWN) yTarg = yPos + 1;
			else if (MoveDir == Direction.LEFT) xTarg = xPos - 1;
			else if (MoveDir == Direction.RIGHT) xTarg = xPos + 1;
			
			if (MoveCheck(MoveDir, yPos, xPos))
			{
				List<ITile> TargSpace = Map[yTarg, xTarg];
				List<ITile> SelfSpace = Map[yPos, xPos];
				int listPos = 0;
				int MaxTargIndex = TargSpace.Count - 1;
				while (listPos <= MaxTargIndex)
				{
					if (Debug)
					{
						Console.WriteLine(listPos);
						Console.WriteLine(MaxTargIndex);
						Console.WriteLine(RecurseDepth);
						Console.WriteLine(TargSpace.Count);
						Console.WriteLine(TargSpace.Capacity);
						Console.WriteLine();
					}
					
					ITile TargetTile = TargSpace[listPos];
					if (TargetTile.IsPush)
					{
						Move(TargetTile, MoveDir, yTarg, xTarg, Debug, RecurseDepth + 1);
						MaxTargIndex--;
					}
					else listPos++;
				}
				TargSpace.Add(StartTile);
				SelfSpace.Remove(StartTile);
				SelfSpace.TrimExcess();
				TargSpace.TrimExcess();

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
				if (yPos == 0) return false;
				yTarg = yPos - 1;
			}
			else if (MoveDir == Direction.DOWN)
			{
				if (yPos + 1 >= Map.GetLength(0)) return false;
				yTarg = yPos + 1;
			}
			else if (MoveDir == Direction.LEFT)
			{
				if (xPos == 0) return false;
				xTarg = xPos - 1;
			}
			else if (MoveDir == Direction.RIGHT)
			{
				if (xPos + 1 >= Map.GetLength(1)) return false;
				xTarg = xPos + 1;
			}

			foreach (ITile TargetTile in Map[yTarg, xTarg])
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