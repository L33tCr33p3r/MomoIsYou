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

			Queue moveEvents = new Queue();
			const int UP = 0;
			const int DOWN = 1;
			const int LEFT = 2;
			const int RIGHT = 3;

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
							Map[i, j] = tile;
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
								moveEvents.Enqueue((Map, Map[i, j], UP, (i, j)));
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
							{
								moveEvents.Enqueue((Map, Map[i, j], DOWN, (i, j)));
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
							{
								moveEvents.Enqueue((Map, Map[i, j], LEFT, (i, j)));
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
							{
								moveEvents.Enqueue((Map, Map[i, j], RIGHT, (i, j)));
							}
						}
					}
				}

				// Game logic
				foreach (Tuple eventArgs in moveEvents)
                {
					Move(moveEvents.Dequeue());
                }

				// Render section
				RectangleShape bg = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(bg);

				for (int i = 0; i < Map.GetLength(0); i++)
				{
					for (int j = 0; j < Map.GetLength(1); j++)
					{
						Map[i, j].Render(Window, j, i);
					}
				}
				Window.Display();
			}
		}
		static void Move(Tuple moveArgs)
        {
			Tile[,] Map;
			Tile MoveTileType;
			int moveDirection;
			int xPos;
			int yPos;
			(Map, MoveTileType, moveDirection, (xPos, yPos)) = moveArgs;
        }
		static void OnClose(object sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow Window = (RenderWindow)sender;
			Window.Close();
		}
	}
}
