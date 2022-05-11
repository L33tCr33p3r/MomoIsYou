using System;
using SFML.System;
using SFML.Graphics;

namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseTile
	{
		public TileID TileID { get; set; }
		public Texture TileTexture { get; set; }

		public int XPos { get; set; }
		public int YPos { get; set; }

		public bool IsYou { get; set; }
		public bool IsStop { get; set; }
		public bool IsPush { get; set; }

		public void Draw(RenderWindow Window)
		{
			Sprite Sprite = new Sprite()
			{
				Texture = TileTexture,
				Position = new Vector2f(XPos * 100, YPos * 100),
			};
			Window.Draw(Sprite);
		}
		public void Update(Level Level)
		{
			Reset();

			foreach (BaseTile i in Level.Map)
			{
				if (typeof(BaseTarget).IsAssignableFrom(i.GetType()))
				{
					BaseTarget TargetTile = (BaseTarget)i;
					foreach (BaseTile j in Level.Map)
					{
						if (typeof(BaseOperator).IsAssignableFrom(j.GetType()))
						{
							BaseOperator OperatorTile = (BaseOperator)j;
							if (OperatorTile.XPos == TargetTile.XPos + 1 && OperatorTile.YPos == TargetTile.YPos)
							{
								foreach (BaseTile k in Level.Map)
								{
									if (typeof(BaseProperty).IsAssignableFrom(k.GetType()))
									{
										BaseProperty PropertyTile = (BaseProperty)k;
										if (TargetTile.TargetID == TileID)
										{
											if (OperatorTile.TileID == TileID.IsOperator)
											{
												if (PropertyTile.XPos == OperatorTile.XPos + 1 && PropertyTile.YPos == OperatorTile.YPos)
												{
													if (PropertyTile.TileID == TileID.YouProperty) IsYou = true;
													if (PropertyTile.TileID == TileID.StopProperty) IsStop = true;
													if (PropertyTile.TileID == TileID.PushProperty) IsPush = true;
												}
											}
										}
									}
								}
							}
							else if (OperatorTile.XPos == TargetTile.XPos && OperatorTile.YPos == TargetTile.YPos + 1)
							{
								foreach (BaseTile k in Level.Map)
								{
									if (typeof(BaseProperty).IsAssignableFrom(k.GetType()))
									{
										BaseProperty PropertyTile = (BaseProperty)k;
										if (TargetTile.TargetID == TileID)
										{
											if (OperatorTile.TileID == TileID.IsOperator)
											{
												if (PropertyTile.XPos == OperatorTile.XPos && PropertyTile.YPos == OperatorTile.YPos + 1)
												{
													if (PropertyTile.TileID == TileID.YouProperty) IsYou = true;
													if (PropertyTile.TileID == TileID.StopProperty) IsStop = true;
													if (PropertyTile.TileID == TileID.PushProperty) IsPush = true;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		public virtual void Reset()
		{
			IsYou = false;
			IsStop = false;
			IsPush = false;
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
				if ((TargetTile.XPos == XTarget && TargetTile.YPos == YTarget) && TargetTile.IsPush)
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
					else if (TargetTile.IsStop) return false;
				}
			}
			return true;
		}
	}
}
