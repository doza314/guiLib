namespace guiLib;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

var window = new RenderWindow(new VideoMode(new Vector2u(800, 600)), "Title");
Button butt = new Button()
while (window.IsOpen)
{
    window.DispatchEvents();
    window.Clear(Color.Black);
    window.Display();
    
    string? quit = Console.ReadLine();
    
    if (quit == "q")
    {
        window.Close();
        Environment.Exit(0);
    }
}



