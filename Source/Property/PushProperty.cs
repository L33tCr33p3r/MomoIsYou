using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Property
{
	internal class PushProperty : BaseProperty
	{
		public PushProperty(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.PushProperty;
			TileTexture = new Texture("Textures\\Property\\PushProperty.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
