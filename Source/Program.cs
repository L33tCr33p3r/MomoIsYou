using System;
using System.IO;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using MomoIsYou.Source.Abstract;
using MomoIsYou.Source.Operator;
using MomoIsYou.Source.Property;
using MomoIsYou.Source.Target;
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

			Clock Clock = new Clock();

			///////////////////////////////////////// Set up the map ////////////////////////////////////////

			Level Level = new Level(8, 8);

			//////// TILES //////// (objects like the momo sprite, box sprite, etc)
			Level.Map.Add(new MomoTile(0, 0));
			Level.Map.Add(new RockTile(1, 1));
			Level.Map.Add(new BoxTile(2, 2));


			//////// TARGETS //////// (object text like "MOMO", "ROCK", etc)
			Level.Map.Add(new MomoTarget(4, 6));
			Level.Map.Add(new RockTarget(4, 2));


			//////// OPERATORS //////// (for now, this is only the "IS" text)
			Level.Map.Add(new IsOperator(5, 6));
			Level.Map.Add(new IsOperator(4, 3));


			//////// PROPERTIES //////// (adjective text, such as "YOU", "PUSH", etc)
			Level.Map.Add(new YouProperty(6, 6));
			Level.Map.Add(new PushProperty(4, 4));

			Console.WriteLine(Directory.GetCurrentDirectory());

			Level.Maplog.Add(new List<BaseTile>(Level.Map));

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				Window.DispatchEvents();

				if (Clock.ElapsedTime > Time.FromSeconds(0.15f))
				{
					bool IsUpPressed = Keyboard.IsKeyPressed(Keyboard.Key.Up);
					bool IsDownPressed = Keyboard.IsKeyPressed(Keyboard.Key.Down);
					bool IsLeftPressed = Keyboard.IsKeyPressed(Keyboard.Key.Left);
					bool IsRightPressed = Keyboard.IsKeyPressed(Keyboard.Key.Right);

					bool IsSpacePressed = Keyboard.IsKeyPressed(Keyboard.Key.Space);

					bool IsZPressed = Keyboard.IsKeyPressed(Keyboard.Key.Z);

					foreach (BaseTile Tile in Level.Map)
					{
						Tile.Update(Level);
					}

					if (IsUpPressed)
					{
						foreach (BaseTile Tile in Level.Map)
						{
							if (Tile.IsYou) Tile.Move(Direction.Up, Level);
						}
						Level.Maplog.Add(new List<BaseTile>(Level.Map));
						Clock.Restart();
					}
					else if (IsDownPressed)
					{
						foreach (BaseTile Tile in Level.Map)
						{
							if (Tile.IsYou) Tile.Move(Direction.Down, Level);
						}
						Level.Maplog.Add(new List<BaseTile>(Level.Map));
						Clock.Restart();
					}
					else if (IsLeftPressed)
					{
						foreach (BaseTile Tile in Level.Map)
						{
							if (Tile.IsYou) Tile.Move(Direction.Left, Level);
						}
						Level.Maplog.Add(new List<BaseTile>(Level.Map));
						Clock.Restart();
					}
					else if (IsRightPressed)
					{
						foreach (BaseTile Tile in Level.Map)
						{
							if (Tile.IsYou) Tile.Move(Direction.Right, Level);
						}
						Level.Maplog.Add(new List<BaseTile>(Level.Map));
						Clock.Restart();
					}
					else if (IsSpacePressed)
					{
						Level.Maplog.Add(new List<BaseTile>(Level.Map));
						Clock.Restart();
					}
					else if (IsZPressed)
					{
						Console.WriteLine(Level.Maplog.Count);
						Level.Map = new List<BaseTile>(Level.Maplog[^1]);
						Level.Maplog.RemoveAt(Level.Maplog.Count - 1);
						Clock.Restart();
					}
				}

				Window.Clear();

				foreach (BaseTile Tile in Level.Map) Tile.Draw(Window);
				
				Window.Display();
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
