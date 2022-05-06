using System;
using System.Collections.Generic;
using System.Text;

namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseWord : BaseTile
	{
		public bool IsTarget { get; set; }
		public bool IsOperator { get; set; }
		public bool IsProperty { get; set; }
	}
}
