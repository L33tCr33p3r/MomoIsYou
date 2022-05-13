using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Target
{
    internal class RockTarget : BaseTarget
    {
		public RockTarget(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.RockTarget;
			TileTexture = new Texture("Textures\\Target\\RockTarget.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;

			TargetID = TileID.RockTile;
		}
	}
}
