namespace guiLib;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class StateMachine //THIS CLASS DIRECTS THE FLOW OF MENUS
{
    private RenderWindow win;
    
    private Menu currentMenu; 
    private Menu startMenu;
        
    private Color bgColor; //default background color

    private machineState currentState = machineState.On;
    
    
    public StateMachine(Menu startingMenu, string title, Vector2u? dimensions, Color? defaultBackgroundColor)
    {
        win = new RenderWindow(new VideoMode(dimensions ?? new Vector2u(600, 600)), title, Styles.Default, State.Windowed);
        win.Clear(defaultBackgroundColor ?? Color.Black);
        startMenu = startingMenu;
        currentMenu = startMenu;
        bgColor = defaultBackgroundColor ?? Color.Black;
        
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Title cannot be null or empty.");
        }
    }

    public void navigate(Menu menu)
    {
        Console.WriteLine("Switching to " + menu.getName());
        currentMenu.stopPolling(win);
        currentMenu = menu;
    }

    public void close()
    {
        currentState = machineState.Off;
    }
    
    public void run()
    {
        while (win.IsOpen)
        {
            if (!currentMenu.isActive()) //if the currently selected menu is inactive, activate it
            {
                currentMenu.startPolling(win);
            }
            if (currentMenu.getColor() == Color.Transparent) //if menu has no background color set, set background to machine default
            { 
                win.Clear(bgColor); 
            }
            else if (currentMenu.getColor() != Color.Transparent) //if menu specifies background color
            {
                win.Clear(currentMenu.getColor());
            }
            
            win.DispatchEvents();
            currentMenu.drawButts(win);
            win.Display();
            
            if (currentState == machineState.Off) //close game
            {
                Console.WriteLine("closing game.");
                win.Close();
            }
        }
    }
    
    public void setStart(Menu start)
    {
        startMenu = start;
    }
}