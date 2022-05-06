using System;
using System.Collections.Generic;
using System.Text;

namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseTarget : BaseWord
	{
		public TileID TargetID { get; set; }
	}
}
