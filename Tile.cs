using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace MomoIsYou
{
    class Tile
    {
		public int Identifier;
		public Color tileColor;
		public Texture tileTexture;

		public bool isYou = false;
		public bool isColide = false;
		public bool isPush = false;
		public bool isChainPush = false;

		public void Push(object[,] Map)
        {

        }
		public void Render(RenderWindow Window, int x, int y)
        {
			RectangleShape tileBorder = new RectangleShape(new Vector2f(100, 100));
			tileBorder.Position = new Vector2f(x * 100, y * 100);
			tileBorder.FillColor = Color.Black;
			Window.Draw(tileBorder);

			RectangleShape tileCenter = new RectangleShape(new Vector2f(90, 90));
			tileCenter.Position = new Vector2f(x * 100 + 5, y * 100 + 5);
			tileCenter.FillColor = tileColor;
			Window.Draw(tileCenter);
		}
    }
}
