using SFML.System;
using SFML.Graphics;
using MomoIsYou.Source.Interface;

namespace MomoIsYou.Source.Tile
{
    internal class RockTile : ITile
    {
		public static int TileID { get; } = 3;
		public static Color TileColor { get; } = Color.Blue;
		public static Texture TileTexture { get; } = null;

		public int XPos { get; set; }
		public int YPos { get; set; }

		public bool IsYou { get; set; }
		public bool IsColide { get; set; }
		public bool IsPush { get; set; }

		public RockTile(bool IsYou = false, bool IsColide = true, bool IsPush = false)
		{
			this.IsYou = IsYou;
			this.IsColide = IsColide;
			this.IsPush = IsPush;
		}
		public void Draw(RenderWindow Window, int x, int y)
		{
			RectangleShape tileBorder = new RectangleShape()
			{
				Size = new Vector2f(100, 100),
				Position = new Vector2f(x * 100, y * 100),
				FillColor = Color.Black
			};
			Window.Draw(tileBorder);

			RectangleShape tileCenter = new RectangleShape()
			{
				Size = new Vector2f(90, 90),
				Position = new Vector2f(x * 100 + 5, y * 100 + 5),
				FillColor = TileColor
			};
			Window.Draw(tileCenter);
		}
	}
}
