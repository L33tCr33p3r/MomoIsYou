namespace MomoIsYou.Source.Abstract
{
	internal abstract class BaseWord : BaseTile
	{
		public override void Reset()
		{
			IsYou = false;
			IsStop = false;
			IsPush = true;
		}
	}
}
