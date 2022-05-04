using System;
using System.Collections.Generic;
using System.Text;
using MomoIsYou.Source.Interface;

namespace MomoIsYou.Source
{
	internal class Level
	{
		public List<ITile> TileList { get; set; } = new List<ITile>();
		public List<ITile>[,] Map { get; set; }

		public Level(int YSize, int XSize)
		{
			Map = new List<ITile>[YSize, XSize];
			for (int i = 0; i < YSize; i++)
			{
				for (int j = 0; j < XSize; j++)
				{
					Map[i, j] = new List<ITile>();
				}
			}
		}
		public bool Move(MoveArgs MoveArgs, bool Debug, int RecurseDepth = 0)
		{
			ITile MoveTile = MoveArgs.MoveTile;
			Direction MoveDirection = MoveArgs.MoveDirection;
			int xPos = MoveArgs.xPos;
			int yPos = MoveArgs.yPos;

			int yTarg = yPos;
			int xTarg = xPos;

			if (MoveDirection == Direction.Up) yTarg = yPos - 1;
			else if (MoveDirection == Direction.Down) yTarg = yPos + 1;
			else if (MoveDirection == Direction.Left) xTarg = xPos - 1;
			else if (MoveDirection == Direction.Right) xTarg = xPos + 1;
			
			if (MoveCheck(MoveDirection, yPos, xPos))
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
						Move(new MoveArgs(), Debug, RecurseDepth + 1);
						MaxTargIndex--;
					}
					else listPos++;
				}
				TargSpace.Add(MoveTile);
				SelfSpace.Remove(MoveTile);
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
			if (MoveDir == Direction.Up)
			{
				if (yPos == 0) return false;
				yTarg = yPos - 1;
			}
			else if (MoveDir == Direction.Down)
			{
				if (yPos + 1 >= Map.GetLength(0)) return false;
				yTarg = yPos + 1;
			}
			else if (MoveDir == Direction.Left)
			{
				if (xPos == 0) return false;
				xTarg = xPos - 1;
			}
			else if (MoveDir == Direction.Right)
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
