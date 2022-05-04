using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace MomoIsYou.Source.Interface
{
	internal interface ITile
	{
		public static int Identifier { get; }
		public static Color TileColor { get; }
		public static Texture TileTexture { get; }

		public bool IsYou { get; set; }
		public bool IsColide { get; set; }
		public bool IsPush { get; set; }

		public void Draw(RenderWindow Window, int x, int y);
	}
}
