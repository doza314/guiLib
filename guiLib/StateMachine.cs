namespace guiLib;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class StateMachine //THIS CLASS DIRECTS THE FLOW OF MENUS
{
    private List<Menu> menus = new List<Menu>();
    private List<string> menuNames = new List<string>();
    private RenderWindow win;
    private Vector2f dimensions;
    private string startingMenu;
    private string currentMenu;
    private string buttonClicked;
    private string exitString;
    private Color bgColor;

    public StateMachine(string Title, Vector2u dimensions, Color? defaultBackgroundColor, string startMenu)
    {
        win = new RenderWindow(new VideoMode(dimensions), Title, Styles.Default, State.Windowed);
        win.Clear(defaultBackgroundColor ?? Color.Black);
        startingMenu = startMenu;
        currentMenu = startMenu;
        bgColor = defaultBackgroundColor ?? Color.Black;
    }

    public void Run()
    {
        if (menus.Count == 0)
        {
            Console.WriteLine("No menus have been added.");
            return;
        }

        foreach (Menu menu in menus)
        {
            menu.eventPoll(win);
        }
        
        while (win.IsOpen)
        {
            win.DispatchEvents();
            win.Clear(bgColor);
            
            foreach (Menu menu in menus)
            {
                
                if (menu.getName() == currentMenu)
                {
                    menu.drawButts(win);
                    
                    buttonClicked = menu.trigger(win);
                   
                    if (buttonClicked != "" && buttonClicked != exitString)
                    {
                        currentMenu = buttonClicked;
                        Console.Write(buttonClicked + "was clicked. Changing Menu.");
                    }
                    else if (buttonClicked == exitString)
                    {
                        Console.Write(buttonClicked + "was clicked. Closing game.");
                        win.Close();
                        return;
                    }
                }
            }
            
            win.Display();
        }
    }

    public void setStart(string? menuName = "")
    {
        startingMenu = menuName;
    }

    public void AddMenu(Menu menu)
    {
        menus.Add(menu);
        menuNames.Add(menu.getName());
    }
    
    public void RemoveMenu(string name)
    {
        foreach (Menu menu in menus)
        {
            if (menu.getName() == name)
            {
                menus.Remove(menu);
            }
        }
    }
    
    public void setExit(string? exitButtonName = "")
    {
        exitString = exitButtonName;
    }
}