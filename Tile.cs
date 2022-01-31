using SFML.System;
using SFML.Graphics;

namespace MomoIsYou
{
	internal class Tile
	{
		//"Constant" Tile Values
		public int Identifier;
		public Color TileColor;
		public Texture tileTexture;

		//"Dynamic" Tile Values
		public bool IsYou = false;
		public bool IsColide = false;
		public bool IsPush = false;

		public void Render(RenderWindow Window, int x, int y)
		{
			RectangleShape tileBorder = new RectangleShape(new Vector2f(100, 100))
			{
				Position = new Vector2f(x * 100, y * 100),
				FillColor = Color.Black
			};
			Window.Draw(tileBorder);

			RectangleShape tileCenter = new RectangleShape(new Vector2f(90, 90))
			{
				Position = new Vector2f(x * 100 + 5, y * 100 + 5),
				FillColor = TileColor
			};
			Window.Draw(tileCenter);
		}
	}
}