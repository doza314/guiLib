namespace guiLib;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class StateMachine //THIS CLASS DIRECTS THE FLOW OF MENUS
{
    private List<Menu> menus = new List<Menu>();
    private RenderWindow window;
    private Vector2f dimensions;
    public StateMachine(string Title, Vector2u dimensions, SFML.Graphics.Color? defaultBackgroundColor = null)
    {
        
    }
    
    public void AddMenu(Menu menu)
    {
      menus.Add(menu);
    }

}