using System;
using System.Collections;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using MomoIsYou.Source.Interface;
using MomoIsYou.Source.Tile;

namespace MomoIsYou.Source
{
	internal class Program
	{
		static int Main()
		{
			//////////////////////////////////// Instantiate tile objects ///////////////////////////////////

			List<ITile> TileTypes = new List<ITile>();

			MomoTile Momo = new MomoTile(true, false, false);
			TileTypes.Add(Momo);

			CrateTile Crate = new CrateTile(false, false, true);
			TileTypes.Add(Crate);

			RockTile Rock = new RockTile(false, true, false);
			TileTypes.Add(Rock);

			////////////////////////////////////// Set up game variables ////////////////////////////////////

			List<MoveArgs> MoveEvents = new List<MoveArgs>();
			bool Debug = false;

			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			///////////////////////////////////////// Set up the map ////////////////////////////////////////

			int[,] InitMap = new int[8, 8] { 
				{ 00, 00, 00, 00, 00, 00, 00, 00 }, 
				{ 00, 00, 02, 00, 00, 00, 00, 00 }, 
				{ 00, 00, 00, 00, 00, 00, 01, 00 }, 
				{ 00, 00, 02, 00, 03, 00, 00, 00 }, 
				{ 00, 00, 00, 03, 03, 00, 00, 00 }, 
				{ 00, 00, 02, 02, 00, 02, 00, 00 }, 
				{ 00, 00, 00, 00, 02, 00, 00, 00 }, 
				{ 00, 00, 00, 00, 00, 00, 00, 00 } 
			};

			Level Level = new Level
			{
				Map = new List<ITile>[8, 8]
			};

			for (int i = 0; i < InitMap.GetLength(0); i++)
			{
				for (int j = 0; j < InitMap.GetLength(1); j++)
				{
					Level.Map[i, j] = new List<ITile>();
					Level.Map[i, j].TrimExcess();
					foreach (MomoTile tile in TileTypes)
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
						foreach (MomoTile Tile in Level.Map[i, j])
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
					Level.Move(MoveEvent.MoveTile, MoveEvent.MoveDirection, MoveEvent.xPos, MoveEvent.yPos, Debug);
					if (Debug) Console.Clear();
				}
				MoveEvents.Clear();

				// Render section
				RectangleShape bg = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(bg);

				for (int i = 0; i < Level.Map.GetLength(0); i++)
				{
					for (int j = 0; j < Level.Map.GetLength(1); j++)
					{
						foreach (MomoTile Tile in Level.Map[i, j]) Tile.Draw(Window, j, i);
					}
				}
				Window.Display();

				// Run SFML event handlers
				Window.WaitAndDispatchEvents();
			}
			return 0;
		}
		static void OnClose(object Sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow Window = (RenderWindow)Sender;
			Window.Close();
		}
	}
}