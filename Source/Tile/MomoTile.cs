using SFML.System;
using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class MomoTile : BaseTile
	{
		public MomoTile(int XPos, int YPos)
		{
			TileID = 1;
			TileColor = Color.Green;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = true;
			IsColide = false;
			IsPush = false;
		}
	}
}
