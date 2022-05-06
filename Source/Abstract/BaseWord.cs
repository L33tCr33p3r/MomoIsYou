using System;
using System.Collections.Generic;
using System.Text;

namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseWord : BaseTile
	{
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
										if ((OperatorTile.XPos == XPos + 1 && OperatorTile.YPos == YPos) || (OperatorTile.XPos == XPos && OperatorTile.YPos == YPos + 1))
										{
											if (OperatorTile.TileID == TileID.IsOperator)
											{
												if ((PropertyTile.XPos == XPos + 2 && PropertyTile.YPos == YPos) || (PropertyTile.XPos == XPos && PropertyTile.YPos == YPos + 2))
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
