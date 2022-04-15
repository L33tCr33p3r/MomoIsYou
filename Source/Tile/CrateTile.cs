using SFML.System;
using SFML.Graphics;
using MomoIsYou.Source.Interface;

namespace MomoIsYou.Source.Tile
{
    internal class CrateTile : ITile
    {
		public int Identifier { get; set; }
		public Color TileColor { get; set; }
		public Texture TileTexture { get; set; }
		public bool IsYou { get; set; }
		public bool IsColide { get; set; }
		public bool IsPush { get; set; }

		public CrateTile(bool IsYou = false, bool IsColide = false, bool IsPush = false)
		{
			Identifier = 2;
			TileColor = Color.Red;
			TileTexture = null;

			this.IsYou = IsYou;
			this.IsColide = IsColide;
			this.IsPush = IsPush;
		}
		public void Draw(RenderWindow Window, int x, int y)
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
