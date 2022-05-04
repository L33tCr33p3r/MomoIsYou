using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using MomoIsYou.Source.Interface;
using MomoIsYou.Source.Tile;

namespace MomoIsYou.Source
{
	internal class Program
	{
		static bool Debug { get; } = false;
		static int Main()
		{
			////////////////////////////////////// Set up game variables ////////////////////////////////////

			List<MoveArgs> MoveEvents = new List<MoveArgs>();
			
			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			///////////////////////////////////////// Set up the map ////////////////////////////////////////

			Level Level = new Level();

			Level.Map.Add(new MomoTile());

			Level.Map.Add(new RockTile());

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				// User input
				for (int i = 0; i < Level.Map.GetLength(0); i++)
				{
					for (int j = 0; j < Level.Map.GetLength(1); j++)
					{
						foreach (ITile Tile in Level.Map[i, j])
						{
							if (Tile.IsYou)
							{
								if (Keyboard.IsKeyPressed(Keyboard.Key.Up) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.Up, i, j));
								}
								else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.Down, i, j));
								}
								else if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.Left, i, j));
								}
								else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
								{
									MoveEvents.Add(new MoveArgs(Tile, Direction.Right, i, j));
								}
							}
						}
					}
				}
				
				// Game logic
				foreach (MoveArgs MoveEvent in MoveEvents)
				{
					Level.Move(MoveEvent, Debug);
					if (Debug) Console.Clear();
				}
				MoveEvents.Clear();

				// Render section
				RectangleShape Background = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(Background);

				for (int i = 0; i < Level.Map.GetLength(0); i++)
				{
					for (int j = 0; j < Level.Map.GetLength(1); j++)
					{
						foreach (ITile Tile in Level.Map[i, j]) Tile.Draw(Window, j, i);
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
			RenderWindow Window = (RenderWindow)Sender;
			Window.Close();
		}
	}
}
