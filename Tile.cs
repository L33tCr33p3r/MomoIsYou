using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace MomoIsYou
{
    class Tile
    {
		public int mapIdentifier;
		public Color tileColor;
		public Texture tileTexture;
		public bool isPush = false;
		public bool isChainPush = false;

		public void RenderSolid(RenderWindow Window, int i, int j)
        {
			RectangleShape tileBorder = new RectangleShape(new Vector2f(100, 100));
			tileBorder.Position = new Vector2f(j * 100, i * 100);
			tileBorder.FillColor = Color.Black;
			Window.Draw(tileBorder);
			RectangleShape tileCenter = new RectangleShape(new Vector2f(90, 90));
			tileCenter.Position = new Vector2f(j * 100 + 5, i * 100 + 5);
			tileCenter.FillColor = tileColor;
			Window.Draw(tileCenter);
		}
    }
}
