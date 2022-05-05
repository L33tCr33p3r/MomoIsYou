using SFML.System;
using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class CrateTile : BaseTile
	{
		public CrateTile(int XPos, int YPos)
		{
			TileID = 2;
			TileColor = Color.Red;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsColide = false;
			IsPush = true;
		}
	}
}
