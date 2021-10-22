using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MomoIsYou
{
	class Program
	{
		static void Main()
		{
			int[,] GameSpace = new int[5,5] {
				{00, 00, 00, 00, 00}, 
				{00, 00, 00, 00, 00}, 
				{00, 01, 01, 02, 00}, 
				{00, 00, 00, 00, 00}, 
				{00, 00, 00, 00, 00}
			};
			Console.WriteLine(GameSpace[2, 2]);
		}
	}
}
