using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class BoxTile : BaseTile
	{
		public BoxTile(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.BoxTile;
			TileTexture = new Texture("Textures\\Tile\\BoxTile.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
