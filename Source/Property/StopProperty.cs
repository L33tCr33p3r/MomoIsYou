using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Property
{
	internal class StopProperty : BaseProperty
	{
		public StopProperty(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.PushProperty;
			TileTexture = new Texture("Textures\\Property\\StopProperty.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
