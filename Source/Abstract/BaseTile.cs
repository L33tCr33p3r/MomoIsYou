﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseTile
	{
		public int TileID { get; set; }
		public Color TileColor { get; set; }
		public Texture TileTexture { get; set; }

		public int XPos { get; set; }
		public int YPos { get; set; }

		public bool IsYou { get; set; }
		public bool IsColide { get; set; }
		public bool IsPush { get; set; }

		public void Draw(RenderWindow Window)
		{
			RectangleShape tileBorder = new RectangleShape()
			{
				Size = new Vector2f(100, 100),
				Position = new Vector2f(XPos * 100, YPos * 100),
				FillColor = Color.Black
			};
			Window.Draw(tileBorder);

			RectangleShape tileCenter = new RectangleShape()
			{
				Size = new Vector2f(90, 90),
				Position = new Vector2f(XPos * 100 + 5, YPos * 100 + 5),
				FillColor = TileColor
			};
			Window.Draw(tileCenter);
		}
		public bool Move(Direction MoveDirection, Level Level)
		{
			if (PushCheck(MoveDirection, Level))
			{
				Push(MoveDirection, Level);
				return true;
			}
			else return false;
		}
		private void Push(Direction MoveDirection, Level Level)
		{
			int XTarget = XPos;
			int YTarget = YPos;

			if (MoveDirection == Direction.Up) YTarget = YPos - 1;
			else if (MoveDirection == Direction.Down) YTarget = YPos + 1;
			else if (MoveDirection == Direction.Left) XTarget = XPos - 1;
			else if (MoveDirection == Direction.Right) XTarget = XPos + 1;

			foreach (BaseTile TargetTile in Level.Map)
			{
				if (TargetTile.XPos == XTarget && TargetTile.YPos == YTarget)
				{
					TargetTile.Push(MoveDirection, Level);
				}
			}
			XPos = XTarget;
			YPos = YTarget;
		}
		private bool PushCheck(Direction MoveDirection, Level Level)
		{
			int XTarget = XPos;
			int YTarget = YPos;

			if (MoveDirection == Direction.Up)
			{
				if (YPos == 0) return false;
				else YTarget = YPos - 1;
			}
			else if (MoveDirection == Direction.Down)
			{
				if (YPos + 1 >= Level.MaxY) return false;
				else YTarget = YPos + 1;
			}
			else if (MoveDirection == Direction.Left)
			{
				if (XPos == 0) return false;
				else XTarget = XPos - 1;
			}
			else if (MoveDirection == Direction.Right)
			{
				if (XPos + 1 >= Level.MaxX) return false;
				else XTarget = XPos + 1;
			}

			foreach (BaseTile TargetTile in Level.Map)
			{
				if (TargetTile.XPos == XTarget && TargetTile.YPos == YTarget)
				{
					if (TargetTile.IsPush)
					{
						if (!TargetTile.PushCheck(MoveDirection, Level)) return false;
					}
					else if (TargetTile.IsColide) return false;
				}
			}
			return true;
		}
	}
}