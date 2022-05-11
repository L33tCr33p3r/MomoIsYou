using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class BoxTile : BaseTile
	{
		public BoxTile(int XPos, int YPos)
		{
			TileID = TileID.BoxTile;
			TileTexture = new Texture("Textures\\Tile\\BoxTile.png");

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
