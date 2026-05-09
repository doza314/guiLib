using SFML.Window;

namespace guiLib;
using SFML.System;
using SFML.Graphics;

public class Menu
{
  private Texture bgTexture;
  private List<Button> butts = new List<Button>();
  private SFML.Graphics.Color color;
  
  private string name = "";
  
  public Menu(string menuName, string? bgImageName = null) //bgImageName for menus with custom background images.
  {
    name = menuName;
    if (bgImageName != null)
    {
      color = SFML.Graphics.Color.Green;
    }
  }
  
  //Setters
  public void setName(string name)
  {
    this.name = name;
  }

  public void setBgColor(Color color)
  {
    this.color = color;
  }
  
  public void addButton(Button button)
    {
      butts.Add(button);
    }
  //Getters
  public string getName()
  {
    return name;
  }
  public SFML.Graphics.Color getColor()
  {
    return color;
  }
  
  //MAIN TRIGGER METHOD
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

  

  public void drawButts(RenderWindow win)
  {
    foreach (Button button in butts)
    {
      button.drawSprite(win);
    }
  }
}



