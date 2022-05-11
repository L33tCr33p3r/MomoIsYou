using System;
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

			Level.Map.Add(new MomoTile(0, 0));

			Level.Map.Add(new RockTile(1, 1));

			Level.Map.Add(new BoxTile(2, 2));

			Level.Map.Add(new MomoTarget(5, 7));

			Level.Map.Add(new IsOperator(6, 7));

			Level.Map.Add(new YouProperty(7, 7));

			/////////////////////////////////////////// Game Loop ///////////////////////////////////////////

			while (Window.IsOpen)
			{
				Window.DispatchEvents();

				foreach (BaseTile Tile in Level.Map)
				{
					Tile.Update(Level);
				}

				if (Clock.ElapsedTime > Time.FromSeconds(0.15f))
				{
					foreach (BaseTile Tile in Level.Map)
					{
						if (Tile.IsYou)
						{
							if (Keyboard.IsKeyPressed(Keyboard.Key.Up) == true)
							{
								Tile.Move(Direction.Up, Level);
								Clock.Restart();
							}
							else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) == true)
							{
								Tile.Move(Direction.Down, Level);
								Clock.Restart();
							}
							else if (Keyboard.IsKeyPressed(Keyboard.Key.Left) == true)
							{
								Tile.Move(Direction.Left, Level);
								Clock.Restart();
							}
							else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) == true)
							{
								Tile.Move(Direction.Right, Level);
								Clock.Restart();
							}
						}
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
