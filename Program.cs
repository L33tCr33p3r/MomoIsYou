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
			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			/////////////////////////////// Set up a playing area in an array ///////////////////////////////

			int[,] Map = new int[8, 8] {
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 00, 00, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 02, 02, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 02, 00, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 01, 00},
				{00, 00, 00, 00, 00, 00, 00, 00}
			};

			//////////////////////////////////// Instantiate tile objects ///////////////////////////////////

			Tile momo = new Tile();
			momo.mapIdentifier = 1;
			momo.tileColor = Color.Green;

			Tile crate = new Tile();
			crate.mapIdentifier = 2;
			crate.tileColor = Color.Red;

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				// Run Event Handlers
				Window.DispatchEvents();

				// Game Logic

				for (int i = 0; i < 8; i++)
                {
					for (int j = 0; j < 8; j++)
                    {
						if (Map[i, j] == 1)
                        {
							
                        }
                    }
                }

				// Render section
				RectangleShape bg = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(bg);

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (Map[i, j] == 1)
						{
							momo.RenderSolid(Window, i, j);
						}
						if (Map[i, j] == 2)
						{
							crate.RenderSolid(Window, i, j);
						}
					}
				}
				Window.Display();
			}
		}
		static void OnClose(object sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow Window = (RenderWindow)sender;
			Window.Close();
		}
	}
}
