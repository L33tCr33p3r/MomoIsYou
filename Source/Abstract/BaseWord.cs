using SFML.System;
using SFML.Graphics;

namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseWord : BaseTile
	{
		public override void Draw(RenderWindow Window)
		{
			RectangleShape tileBorder = new RectangleShape()
			{
				Size = new Vector2f(100, 100),
				Position = new Vector2f(XPos * 100, YPos * 100),
				FillColor = Color.Red
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
		public override void Update(Level Level)
		{
			IsYou = false;
			IsStop = false;
			IsPush = true;

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
							foreach (BaseTile k in Level.Map)
							{
								if (typeof(BaseProperty).IsAssignableFrom(k.GetType()))
								{
									BaseProperty PropertyTile = (BaseProperty)k;
									if (TargetTile.TargetID == TileID)
									{
										if ((OperatorTile.XPos == TargetTile.XPos + 1 && OperatorTile.YPos == TargetTile.YPos) || (OperatorTile.XPos == TargetTile.XPos && OperatorTile.YPos == TargetTile.YPos + 1))
										{
											if (OperatorTile.TileID == TileID.IsOperator)
											{
												if ((PropertyTile.XPos == TargetTile.XPos + 2 && PropertyTile.YPos == TargetTile.YPos) || (PropertyTile.XPos == TargetTile.XPos && PropertyTile.YPos == TargetTile.YPos + 2))
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
	}
}
