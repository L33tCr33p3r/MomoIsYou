using SFML.System;
using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Tile
{
	internal class MomoTile : BaseTile
	{
		public MomoTile(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.MomoTile;
			TileTexture = new Texture("Textures\\Tile\\MomoTile.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;
		}
		public override void Draw(RenderWindow Window)
		{
			Sprite Sprite = new Sprite()
			{
				Texture = TileTexture,
				Position = new Vector2f(XPos * 100, YPos * 100),
				Scale = new Vector2f(4f, 4f),
				TextureRect = new IntRect(0, 0, 24, 24),
			};
			if (FaceDirection == Direction.Right) Sprite.TextureRect = new IntRect(0, 0, 24, 24);
			else if (FaceDirection == Direction.Up) Sprite.TextureRect = new IntRect(24, 0, 24, 24);
			else if (FaceDirection == Direction.Left) Sprite.TextureRect = new IntRect(48, 0, 24, 24);
			else if (FaceDirection == Direction.Down) Sprite.TextureRect = new IntRect(72, 0, 24, 24);
			Window.Draw(Sprite);
		}
	}
}
