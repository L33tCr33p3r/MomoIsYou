using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class RockTile : BaseTile
	{
		public RockTile(int XPos, int YPos)
		{
			TileID = TileID.RockTile;
			TileTexture = new Texture("Textures\\Tile\\RockTile.png");

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
