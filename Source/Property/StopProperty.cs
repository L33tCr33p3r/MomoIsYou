using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Property
{
	internal class StopProperty : BaseProperty
	{
		public StopProperty(int XPos, int YPos)
		{
			TileID = TileID.PushProperty;
			TileTexture = new Texture("Textures\\Property\\StopProperty.png");

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
