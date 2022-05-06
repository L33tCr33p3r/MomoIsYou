using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Target
{
	internal class MomoTarget : BaseTarget
	{
		public MomoTarget(int XPos, int YPos)
		{
			TileID = TileID.MomoTarget;
			TileColor = Color.Green;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
