using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class CrateTile : BaseTile
	{
		public CrateTile(int XPos, int YPos)
		{
			TileID = TileID.CrateTile;
			TileColor = Color.Red;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
