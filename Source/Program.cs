using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using MomoIsYou.Source.Abstract;
using MomoIsYou.Source.Tile;

namespace MomoIsYou.Source
{
	internal class Program
	{
		static int Main()
		{
			//////////////////////////////////////// Open SFML Window ///////////////////////////////////////

			RenderWindow Window = new RenderWindow(new VideoMode(800, 800), "Momo is You");
			Window.Closed += new EventHandler(OnClose);

			///////////////////////////////////////// Set up the map ////////////////////////////////////////

			Level Level = new Level(8, 8);

			Level.Map.Add(new MomoTile(0, 0));

			Level.Map.Add(new RockTile(1, 1));

			Level.Map.Add(new CrateTile(2, 2));

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				// User input
				
				foreach (BaseTile Tile in Level.Map)
				{
					if (Tile.IsYou)
					{
						if (Keyboard.IsKeyPressed(Keyboard.Key.Up) == true)
						{
							Tile.Move(Direction.Up, Level);
						}
						else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
						{
							Tile.Move(Direction.Down, Level);
						}
						else if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
						{
							Tile.Move(Direction.Left, Level);
						}
						else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
						{
							Tile.Move(Direction.Right, Level);
						}
					}
				}

				// Render section
				RectangleShape Background = new RectangleShape(new Vector2f(800, 800)) { FillColor = Color.White };
				Window.Draw(Background);
				
				foreach (BaseTile Tile in Level.Map) Tile.Draw(Window);
				
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
