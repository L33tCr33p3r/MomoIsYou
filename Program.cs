using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;


namespace MomoIsYou
{
	class Program
	{
		static void Main()
		{
			//Open SFML Window
			RenderWindow Window = new RenderWindow(new VideoMode(500, 500), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			//Set up a (basic) playing area in an array
			int[,] GameSpace = new int[5, 5] {
				{00, 00, 00, 00, 00},
				{00, 00, 00, 00, 00},
				{00, 01, 02, 02, 00},
				{00, 00, 00, 00, 00},
				{00, 00, 00, 00, 00}
			};

			//Game Loop
			while(Window.IsOpen)
			{

            }
		}
		static void OnClose(object sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow window = (RenderWindow)sender;
			window.Close();
		}
	}
}
