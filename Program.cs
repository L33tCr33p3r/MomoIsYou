using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
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
			//////////////////////////////////// Instantiate tile objects ///////////////////////////////////

			ArrayList tileTypes = new ArrayList();

			Tile air = new Tile();
			air.Identifier = 0;
			air.tileColor = Color.White;
			air.isYou = false;
			air.isColide = false;
			air.isPush = false;
			tileTypes.Add(air);

			Tile momo = new Tile();
			momo.Identifier = 1;
			momo.tileColor = Color.Green;
			momo.isYou = true;
			momo.isColide = true;
			momo.isPush = true;
			tileTypes.Add(momo);

			Tile crate = new Tile();
			crate.Identifier = 2;
			crate.tileColor = Color.Red;
			crate.isYou = false;
			crate.isColide = true;
			crate.isPush = true;
			tileTypes.Add(crate);

			Tile rock = new Tile();
			rock.Identifier = 3;
			rock.tileColor = Color.Blue;
			rock.isYou = false;
			rock.isColide = true;
			rock.isPush = false;
			tileTypes.Add(rock);

			////////////////////////////////////// Set up game variables ////////////////////////////////////

			List<MoveArg> moveEvents = new List<MoveArg>();

			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			///////////////////////////////////////// Set up the map ////////////////////////////////////////

			int[,] initMap = new int[8, 8] {
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 00, 00, 00, 00, 00},
				{00, 00, 00, 00, 03, 00, 01, 00},
				{00, 00, 02, 03, 03, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 01, 00},
				{00, 00, 02, 02, 00, 02, 00, 00},
				{00, 00, 00, 00, 02, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 00, 00}
			};

			Tile[,] map = new Tile[initMap.GetLength(0), initMap.GetLength(1)];

			for (int i = 0; i < initMap.GetLength(0); i++)
			{
				for (int j = 0; j < initMap.GetLength(1); j++)
				{
					foreach (Tile tile in tileTypes)
					{
						if (tile.Identifier == initMap[i, j])
						{
							map[j, i] = tile;
						}
					}
				}
			}

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				// User input
				for (int i = 0; i < map.GetLength(0); i++)
				{
					for (int j = 0; j < map.GetLength(1); j++)
					{
						if (map[i, j].isYou)
						{
							if (Keyboard.IsKeyPressed(Keyboard.Key.Up) == true)
							{
								moveEvents.Add(new MoveArg(Direction.UP, i, j));
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
							{
								moveEvents.Add(new MoveArg(Direction.DOWN, i, j));
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
							{
								moveEvents.Add(new MoveArg(Direction.LEFT, i, j));
							}
							if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
							{
								moveEvents.Add(new MoveArg(Direction.RIGHT, i, j));
							}
						}
					}
				}
				
				// Game logic
				foreach (MoveArg moveEvent in moveEvents)
				{
					Push(map, moveEvent.moveDirection, moveEvent.xPos, moveEvent.yPos);
				}
				moveEvents.Clear();

				// Render section
				RectangleShape bg = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(bg);

				for (int i = 0; i < map.GetLength(0); i++)
				{
					for (int j = 0; j < map.GetLength(1); j++)
					{
						map[i, j].Render(Window, i, j);
					}
				}
				Window.Display();

				// Run SFML event handlers
				Window.WaitAndDispatchEvents();
			}
		}
		static bool Push(Tile[,] map, Direction moveDir, int xPos, int yPos)
		{
			if (moveDir == Direction.UP)
			{
				if (yPos == 0)
				{
					return false;
				}
				else if (map[xPos, yPos - 1].isColide)
				{
					if (map[xPos, yPos - 1].isPush)
					{
						bool safeCheck = Push(map, moveDir, xPos, yPos - 1);
						if (safeCheck)
						{
							Tile self = map[xPos, yPos];
							Tile destination = map[xPos, yPos - 1];
							map[xPos, yPos - 1] = self;
							map[xPos, yPos] = destination;
							return true;
						}
						else return false;
					}
					else return false;
				}
				else
				{
					Tile self = map[xPos, yPos];
					Tile destination = map[xPos, yPos - 1];
					map[xPos, yPos - 1] = self;
					map[xPos, yPos] = destination;
					return true;
				}
			}
			else if (moveDir == Direction.DOWN)
			{
				if (yPos + 1 >= map.GetLength(0))
				{
					return false;
				}
				else if (map[xPos, yPos + 1].isColide)
				{
					if (map[xPos, yPos + 1].isPush)
					{
						bool safeCheck = Push(map, moveDir, xPos, yPos + 1);
						if (safeCheck)
						{
							Tile self = map[xPos, yPos];
							Tile destination = map[xPos, yPos + 1];
							map[xPos, yPos + 1] = self;
							map[xPos, yPos] = destination;
							return true;
						}
						else return false;
					}
					else return false;
				}
				else
				{
					Tile self = map[xPos, yPos];
					Tile destination = map[xPos, yPos + 1];
					map[xPos, yPos + 1] = self;
					map[xPos, yPos] = destination;
					return true;
				}
			}
			else if (moveDir == Direction.LEFT)
			{
				if (xPos == 0)
				{
					return false;
				}
				else if (map[xPos - 1, yPos].isColide)
				{
					if (map[xPos - 1, yPos].isPush)
					{
						bool safeCheck = Push(map, moveDir, xPos - 1, yPos);
						if (safeCheck)
						{
							Tile self = map[xPos, yPos];
							Tile destination = map[xPos - 1, yPos];
							map[xPos - 1, yPos] = self;
							map[xPos, yPos] = destination;
							return true;
						}
						else return false;
					}
					else return false;
				}
				else
				{
					Tile self = map[xPos, yPos];
					Tile destination = map[xPos - 1, yPos];
					map[xPos - 1, yPos] = self;
					map[xPos, yPos] = destination;
					return true;
				}
			}
			else if (moveDir == Direction.RIGHT)
			{
				if (xPos + 1 >= map.GetLength(1))
				{
					return false;
				}
				else if (map[xPos + 1, yPos].isColide)
				{
					if (map[xPos + 1, yPos].isPush)
					{
						bool safeCheck = Push(map, moveDir, xPos + 1, yPos);
						if (safeCheck)
						{
							Tile self = map[xPos, yPos];
							Tile destination = map[xPos + 1, yPos];
							map[xPos + 1, yPos] = self;
							map[xPos, yPos] = destination;
							return true;
						}
						else return false;
					}
					else return false;
				}
				else
				{
					Tile self = map[xPos, yPos];
					Tile destination = map[xPos + 1, yPos];
					map[xPos + 1, yPos] = self;
					map[xPos, yPos] = destination;
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
