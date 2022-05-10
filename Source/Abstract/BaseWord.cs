using SFML.System;
using SFML.Graphics;

namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseWord : BaseTile
	{
		public override void Draw(RenderWindow Window)
		{
			RectangleShape tileBorder = new RectangleShape()
			{
				Size = new Vector2f(100, 100),
				Position = new Vector2f(XPos * 100, YPos * 100),
				FillColor = Color.Red
			};
			Window.Draw(tileBorder);

			RectangleShape tileCenter = new RectangleShape()
			{
				Size = new Vector2f(90, 90),
				Position = new Vector2f(XPos * 100 + 5, YPos * 100 + 5),
				FillColor = TileColor
			};
			Window.Draw(tileCenter);
		}
		public override void Reset()
		{
			IsYou = false;
			IsStop = false;
			IsPush = true;
		}
	}
}
