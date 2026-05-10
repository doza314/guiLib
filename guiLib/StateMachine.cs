namespace guiLib;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class StateMachine //THIS CLASS DIRECTS THE FLOW OF MENUS
{
    private List<Menu> menus = new List<Menu>();
    private List<string> menuNames = new List<string>();
    private RenderWindow win;
    
    private string startingMenu;
    private string currentMenu;
    private int currIndex = 0;
    
    private string buttonClicked;
    private string exitString;
    
    private Color bgColor;

    private void stateDirect()
    {
        menus[currIndex].drawButts(win);
        buttonClicked = menus[currIndex].trigger();

        if (buttonClicked != "" && buttonClicked != exitString)
        {
            for (int i = 0; i < menuNames.Count; i++)
            {
                if (menuNames[i] == buttonClicked && currIndex != i)
                {
                    menus[currIndex].stopPolling(win);
                    currIndex = i;
                    break;
                }
            }

            Console.Write(buttonClicked + "was clicked. Changing Menu.");
        }
        else if (buttonClicked == exitString)
        {
            Console.Write(buttonClicked + "was clicked. Closing game.");
            win.Close();
            return;
        }
    }
    
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

        while (win.IsOpen)
        {
            if (!menus[currIndex].isActive())
            {
                menus[currIndex].startPolling(win);
            }
            
            win.DispatchEvents();
            
            if (menus[currIndex].getColor() == Color.Transparent)
            {
                win.Clear(bgColor);
            }
            else if (menus[currIndex].getColor() != Color.Transparent)
            {
                win.Clear(menus[currIndex].getColor());
            }
               
            stateDirect();
            
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