using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class RockTile : BaseTile
	{
		public RockTile(int XPos, int YPos)
		{
			TileID = TileID.RockTile;
			TileColor = Color.Blue;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = true;
			IsPush = false;
		}
	}
}
