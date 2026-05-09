using SFML.Window;

namespace guiLib;
using SFML.System;
using SFML.Graphics;

public class Menu
{
  private Texture bgTexture;
  private List<Button> butts = new List<Button>();
  private Color color;
  private string name;
  
  public Menu(string menuName, string? bgImageName = null) //bgImageName for menus with custom background images.
  {
    name = menuName;
    if (bgImageName != null)
    {
      color = Color.Green; //green arbitrarily picked as default
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
  public Color getColor()
  {
    return color;
  }
  
  
  //MAIN TRIGGER METHOD
  public string triggerTransition(RenderWindow win)
  {
    string buttonClicked = "";
    
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
            butt.setState(ButtonState.Idle);
            buttonClicked = butt.getName();
            break;
          }
          else
          {
            butt.setState(ButtonState.Idle);
          }
        }
      }
    };
    
    return buttonClicked;
  }
  
  
  //MISC. FUNCTIONALITY
  public void drawButts(RenderWindow win)
  {
    foreach (Button button in butts)
    {
      button.drawSprite(win);
    }
  }
}



