using SFML.Window;

namespace guiLib;
using SFML.System;
using SFML.Graphics;

public class Menu
{
  private Texture bgTexture;
  private List<Button> butts = new List<Button>();
  
  private string name = "";
  
  public Menu(string menuName, string? bgImageName = null) //bgImageName for menus with custom background images.
  {
    name = menuName;
    if (bgImageName != null)
    {
      
    }
  }
  
  public string triggerTransition(RenderWindow win)
  {
    string nextMenu = "";
    
    win.MouseButtonPressed += (sender, e) => //left mouse click event
    {
      foreach (Button butt in butts)
      {
        if (e.Button == Mouse.Button.Left)
        {
          if (butt.getBounds().Contains(e.Position))
          {
            butt.setState(ButtonState.Active);
            break;
          }
        }
      }
    };
    
    win.MouseButtonReleased += (sender, e) => //left mouse released from clicking
    {
      foreach (Button butt in butts)
      {
        if (e.Button == Mouse.Button.Left)
        {
          if (butt.getBounds().Contains(e.Position) && butt.getState() == ButtonState.Active)
          {
            nextMenu = butt.getName();
            break;
          }
          else
          {
            butt.setState(ButtonState.Idle);
          }
        }
      }
    };
    
    return nextMenu;
  }

  public void addButton(Button button)
  {
    butts.Add(button);
  }

  public void draw(RenderWindow win)
  {
    foreach (Button button in butts)
    {
      button.draw(win);
    }
  }
}



