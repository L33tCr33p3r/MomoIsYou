using System;
using System.Collections;
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
			////////////////////////////////////// Set up game variables ////////////////////////////////////

			const int UP = 0;
			const int DOWN = 1;
			const int LEFT = 2;
			const int RIGHT = 3;

			Tile moveTarget;
			int moveDirection;
			int moveXPos;
			int moveYPos;

			Queue moveEvents = new Queue();

			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			//////////////////////////////////// Instantiate tile objects ///////////////////////////////////

			ArrayList tileTypes = new ArrayList();

			Tile air = new Tile();
			air.Identifier = 0;
			air.tileColor = Color.White;
			tileTypes.Add(air);

			Tile momo = new Tile();
			momo.Identifier = 1;
			momo.tileColor = Color.Green;
			tileTypes.Add(momo);

			Tile crate = new Tile();
			crate.Identifier = 2;
			crate.tileColor = Color.Red;
			tileTypes.Add(crate);

			///////////////////////////////////////// Set up the map ////////////////////////////////////////

			int[,] initMap = new int[8, 8] {
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 00, 00, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 02, 02, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 02, 00, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 01, 00},
				{00, 00, 00, 00, 00, 00, 00, 00}
			};

			Tile[,] Map = new Tile[initMap.GetLength(0), initMap.GetLength(1)];

			for (int i = 0; i < initMap.GetLength(0); i++)
			{
				for (int j = 0; j < initMap.GetLength(1); j++)
				{
					foreach (Tile tile in tileTypes)
					{
						if (tile.Identifier == initMap[i, j])
						{
							Map[j, i] = tile;
						}
					}
				}
			}

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				// Run SFML event handlers
				Window.DispatchEvents();

				// User input
				for (int i = 0; i < Map.GetLength(0); i++)
				{
					for (int j = 0; j < Map.GetLength(1); j++)
					{
						if (Map[i, j].isYou)
						{
							if (Keyboard.IsKeyPressed(Keyboard.Key.Up) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = UP;
								moveXPos = i;
								moveYPos = j;
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = DOWN;
								moveXPos = i;
								moveYPos = j;
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = LEFT;
								moveXPos = i;
								moveYPos = j;
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = RIGHT;
								moveXPos = i;
								moveYPos = j;
							}
						}
					}
				}
				
				// Game logic
				
				Move(Map, moveTarget, moveDirection, moveXPos, moveYPos);
				
				
				// Render section
				RectangleShape bg = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(bg);

				for (int i = 0; i < Map.GetLength(0); i++)
				{
					for (int j = 0; j < Map.GetLength(1); j++)
					{
						Map[i, j].Render(Window, i, j);
					}
				}
				Window.Display();
			}
		}
		static void Move(Tile[,] Map, Tile moveType, int moveDir, int xPos, int yPos)
        {
			
        }
		static void OnClose(object sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow Window = (RenderWindow)sender;
			Window.Close();
		}
	}
}
