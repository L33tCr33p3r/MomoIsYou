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
		const int UP = 0;
		const int DOWN = 1;
		const int LEFT = 2;
		const int RIGHT = 3;
		static void Main()
		{
			//////////////////////////////////// Instantiate tile objects ///////////////////////////////////

			ArrayList tileTypes = new ArrayList();

			Tile air = new Tile();
			air.Identifier = 0;
			air.tileColor = Color.White;
			tileTypes.Add(air);

			Tile momo = new Tile();
			momo.Identifier = 1;
			momo.tileColor = Color.Green;
			momo.isColide = true;
			momo.isYou = true;
			tileTypes.Add(momo);

			Tile crate = new Tile();
			crate.Identifier = 2;
			crate.tileColor = Color.Red;
			crate.isColide = true;
			crate.isYou = false;
			tileTypes.Add(crate);

			////////////////////////////////////// Set up game variables ////////////////////////////////////

			Tile moveTarget;
			int moveDirection;
			int moveXPos;
			int moveYPos;

			(int, int, int) moveArgs = (UP, 0, 0);

			Queue moveEvents = new Queue();

			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);
			//Window.SetFramerateLimit(5);

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

				// User input
				for (int i = 0; i < Map.GetLength(0); i++)
				{
					for (int j = 0; j < Map.GetLength(1); j++)
					{
						if (Map[i, j].isYou)
						{
							Window.WaitAndDispatchEvents();
							if (Keyboard.IsKeyPressed(Keyboard.Key.Up) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = UP;
								moveXPos = i;
								moveYPos = j;
								moveArgs = (UP, i, j);

								moveEvents.Enqueue(1);
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = DOWN;
								moveXPos = i;
								moveYPos = j;
								moveArgs = (DOWN, i, j);

								moveEvents.Enqueue(1);
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = LEFT;
								moveXPos = i;
								moveYPos = j;
								moveArgs = (LEFT, i, j);

								moveEvents.Enqueue(1);
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
							{
								moveTarget = Map[i, j];
								moveDirection = RIGHT;
								moveXPos = i;
								moveYPos = j;
								moveArgs = (RIGHT, i, j);

								moveEvents.Enqueue(1);
							}
						}
					}
				}
				
				// Game logic
				foreach (object moveEvent in moveEvents)
                {
					(moveDirection, moveXPos, moveYPos) = moveArgs;
					Move(Map, moveDirection, moveXPos, moveYPos);
				}
				moveEvents.Clear();
			}
		}
		static bool Move(Tile[,] Map, int moveDir, int xPos, int yPos)
        {

			if (moveDir == UP)
			{
				if (yPos == 0)
				{
					return false;
				}
				else if (Map[xPos, yPos - 1].isColide)
				{
					if (Map[xPos, yPos - 1].isPush)
					{
						Move(Map, moveDir, xPos, yPos - 1);
						return true;
					}
					return false;
				}
				else
				{
					Tile self = Map[xPos, yPos];
					Tile destination = Map[xPos, yPos - 1];
					Map[xPos, yPos - 1] = self;
					Map[xPos, yPos] = destination;
					return true;
				}
			}
			else if (moveDir == DOWN)
			{
				if (yPos + 1 >= Map.GetLength(0))
				{
					return false;
				}
				else if (Map[xPos, yPos + 1].isColide)
				{
					return false;
				}
				else
				{
					Tile self = Map[xPos, yPos];
					Tile destination = Map[xPos, yPos + 1];
					Map[xPos, yPos + 1] = self;
					Map[xPos, yPos] = destination;
					return true;
				}
			}
			else if (moveDir == LEFT)
			{
				if (xPos == 0)
				{
					return false;
				}
				else if (Map[xPos - 1, yPos].isColide)
				{
					return false;
				}
				else
				{
					Tile self = Map[xPos, yPos];
					Tile destination = Map[xPos - 1, yPos];
					Map[xPos - 1, yPos] = self;
					Map[xPos, yPos] = destination;
					return true;
				}
			}
			else if (moveDir == RIGHT)
			{
				if (xPos + 1 >= Map.GetLength(1))
				{
					return false;
				}
				else if (Map[xPos + 1, yPos].isColide)
				{
					return false;
				}
				else
				{
					Tile self = Map[xPos, yPos];
					Tile destination = Map[xPos + 1, yPos];
					Map[xPos + 1, yPos] = self;
					Map[xPos, yPos] = destination;
					return true;
				}
			}
			else return false;
		}
		static void OnClose(object sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow Window = (RenderWindow)sender;
			Window.Close();
		}
	}
}
