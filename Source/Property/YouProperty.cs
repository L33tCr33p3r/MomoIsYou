using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Property
{
	internal class YouProperty : BaseProperty
	{
		public YouProperty(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.YouProperty;
			TileTexture = new Texture("Textures\\Property\\YouProperty.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
