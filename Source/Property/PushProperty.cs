using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Property
{
	internal class PushProperty : BaseProperty
	{
		public PushProperty(int XPos, int YPos)
		{
			TileID = TileID.PushProperty;
			TileColor = Color.Yellow;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
