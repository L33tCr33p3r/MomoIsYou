using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Target
{
    internal class CrateTarget : BaseTarget
    {
		public CrateTarget(int XPos, int YPos)
		{
			TileID = TileID.CrateTarget;
			TileColor = Color.Red;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;

			TargetID = TileID.CrateTile;
		}
	}
}
