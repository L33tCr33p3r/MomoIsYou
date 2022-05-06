using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Property
{
	internal class YouProperty : BaseProperty
	{
		public YouProperty(int XPos, int YPos)
		{
			TileID = TileID.YouProperty;
			TileColor = Color.Cyan;
			TileTexture = null;

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
