﻿using SFML.Graphics;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source.Target
{
    internal class BoxTarget : BaseTarget
    {
		public BoxTarget(int XPos, int YPos, Direction FaceDirection = Direction.Right)
		{
			TileID = TileID.BoxTarget;
			TileTexture = new Texture("Textures\\Target\\BoxTarget.png");

			this.XPos = XPos;
			this.YPos = YPos;
			this.FaceDirection = FaceDirection;

			IsYou = false;
			IsStop = false;
			IsPush = false;

			TargetID = TileID.BoxTile;
		}
	}
}
