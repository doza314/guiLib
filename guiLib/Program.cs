using SFML.Graphics;
using SFML.System;
using SFML.Window;
using guiLib;

RenderWindow window = new RenderWindow(new VideoMode(new Vector2u(800, 600)), "Title");

Button butt = new Button(new Vector2f(400, 300), new Vector2f(150, 50), "res/button.png");

while (window.IsOpen)
{
    window.DispatchEvents();
    window.Clear(Color.Black);
    butt.drawSprite(window);
    window.Display();
    
    string? quit = Console.ReadLine();
    
    if (quit == "q")
    { 
        window.Close();
        Environment.Exit(0);
    }
}



