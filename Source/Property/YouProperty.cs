using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Property
{
	internal class YouProperty : BaseProperty
	{
		public YouProperty(int XPos, int YPos)
		{
			TileID = TileID.YouProperty;
			TileTexture = new Texture("Textures\\Property\\YouProperty.png");

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
