using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace MomoIsYou.Source.Interface
{
	internal interface ITile
	{
		public int Identifier { get; set; }
		public Color TileColor { get; set; }
		public Texture TileTexture { get; set; }

		public bool IsYou { get; set; }
		public bool IsColide { get; set; }
		public bool IsPush { get; set; }

		public void Draw(RenderWindow Window, int x, int y);
	}
}
