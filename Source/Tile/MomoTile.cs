using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class MomoTile : BaseTile
	{
		public MomoTile(int XPos, int YPos)
		{
			TileID = TileID.MomoTile;
			TileTexture = new Texture("Textures\\Tile\\MomoTile.png");

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
