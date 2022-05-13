using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Target
{
	internal class MomoTarget : BaseTarget
	{
		public MomoTarget(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.MomoTarget;
			TileTexture = new Texture("Textures\\Target\\MomoTarget.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;

			TargetID = TileID.MomoTile;
		}
	}
}
