using System;
using System.Collections.Generic;
using System.Text;
using MomoIsYou.Source.Abstract;

namespace MomoIsYou.Source
{
	internal class Level
	{
		public int MaxX { get; set; }
		public int MaxY { get; set; }
		public List<BaseTile> Map { get; set; } = new List<BaseTile>();
		
		public Level(int MaxX, int MaxY)
		{
			this.MaxX = MaxX;
			this.MaxY = MaxY;
		}
		public Level(Level Copy)
		{
			MaxX = Copy.MaxX;
			MaxY = Copy.MaxY;
			Map = Copy.Map;
		}
	}
}
