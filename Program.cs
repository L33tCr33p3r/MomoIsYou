using System;
using System.Collections;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace MomoIsYou
{
	class Program
	{
		static void Main()
		{
			//////////////////////////////////// Instantiate tile objects ///////////////////////////////////

			List<Tile> TileTypes = new List<Tile>();

			Tile Momo = new Tile
			{
				Identifier = 1,
				TileColor = Color.Green,
				IsYou = true,
				IsColide = false,
				IsPush = false
			};
			TileTypes.Add(Momo);

			Tile Crate = new Tile
			{
				Identifier = 2,
				TileColor = Color.Red,
				IsYou = false,
				IsColide = false,
				IsPush = true
			};
			TileTypes.Add(Crate);

			Tile Rock = new Tile
			{
				Identifier = 3,
				TileColor = Color.Blue,
				IsYou = false,
				IsColide = true,
				IsPush = false
			};
			TileTypes.Add(Rock);

			////////////////////////////////////// Set up game variables ////////////////////////////////////

			List<MoveArgs> MoveEvents = new List<MoveArgs>();

			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			///////////////////////////////////////// Set up the map ////////////////////////////////////////

			int[,] InitMap = new int[8, 8] {
				{00, 00, 00, 00, 00, 00, 00, 00},
				{00, 00, 02, 00, 00, 00, 00, 00},
				{00, 00, 00, 00, 03, 00, 01, 00},
				{00, 00, 02, 03, 03, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 01, 00},
				{00, 00, 02, 02, 00, 02, 00, 00},
				{00, 00, 00, 00, 02, 00, 00, 00},
				{00, 00, 00, 00, 00, 00, 00, 00}
			};

			Level Level = new Level();
			Level.Map = new List<Tile>[8, 8];

			for (int i = 0; i < InitMap.GetLength(0); i++)
			{
				for (int j = 0; j < InitMap.GetLength(1); j++)
				{
					Level.Map[i, j] = new List<Tile>();
					Level.Map[i, j].TrimExcess();
					foreach (Tile tile in TileTypes)
					{
						if (tile.Identifier == InitMap[i, j])
						{
							Level.Map[i, j].Add(tile);
						}
					}
				}
			}

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				// User input
				for (int i = 0; i < Level.Map.GetLength(0); i++)
				{
					for (int j = 0; j < Level.Map.GetLength(1); j++)
					{
						foreach (Tile Tile in Level.Map[i, j])
						{
							if (Tile.IsYou)
							{
								if (Keyboard.IsKeyPressed(Keyboard.Key.Up) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.UP, i, j));
								}
								else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.DOWN, i, j));
								}
								else if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.LEFT, i, j));
								}
								else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.RIGHT, i, j));
								}
							}
						}
					}
				}
				
				// Game logic
				foreach (MoveArgs MoveEvent in MoveEvents)
				{
					Level.Move(MoveEvent.MoveTile, MoveEvent.MoveDirection, MoveEvent.xPos, MoveEvent.yPos);
				}
				MoveEvents.Clear();

				// Render section
				RectangleShape bg = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(bg);

				for (int i = 0; i < Level.Map.GetLength(0); i++)
				{
					for (int j = 0; j < Level.Map.GetLength(1); j++)
					{
						foreach (Tile Tile in Level.Map[i, j]) Tile.Render(Window, j, i);
					}
				}
				Window.Display();

				// Run SFML event handlers
				Window.WaitAndDispatchEvents();
			}
		}
		static void OnClose(object Sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow Window = (RenderWindow)Sender;
			Window.Close();
		}
	}
}