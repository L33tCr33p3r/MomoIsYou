using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Operator
{
	internal class IsOperator : BaseOperator
	{
		public IsOperator(int XPos, int YPos)
		{
			TileID = TileID.IsOperator;
			TileTexture = new Texture("Textures\\Operator\\IsOperator.png");

			this.XPos = XPos;
			this.YPos = YPos;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
	}
}
