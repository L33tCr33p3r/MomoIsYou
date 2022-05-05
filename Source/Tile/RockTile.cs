using SFML.System;
using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class RockTile : BaseTile
	{
		public RockTile(int XPos, int YPos)
		{
			TileID = 3;
			TileColor = Color.Blue;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsColide = true;
			IsPush = false;
		}
	}
}
