namespace guiLib;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class StateMachine //THIS CLASS DIRECTS THE FLOW OF MENUS
{
    private List<Menu> menus = new List<Menu>();

    public StateMachine()
    {
        
    }
    
    public void AddMenu(Menu menu)
    {
      menus.Add(menu);
    }

}