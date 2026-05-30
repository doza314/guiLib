using SFML.Window;

namespace guiLib;
using SFML.System;
using SFML.Graphics;

public class Menu
{
  private Texture bgTexture;
  private string bgString;
  private List<Button> butts = new List<Button>();
  private Color color = Color.Transparent;
  private string name;

  private bool active = false;

  public Menu(string menuName, string? bgImageName = null) //bgImageName for menus with custom background images.
  {
    name = menuName;
    bgString = "res/" + bgImageName + ".png";
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


  //MAIN TRIGGER METHODS
  private void onMousePressed(object? sender, MouseButtonEventArgs e) 
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
  }

  private void onMouseReleased(object? sender, MouseButtonEventArgs e)
  {

      foreach (Button butt in butts)
      {
        if (e.Button == Mouse.Button.Left)
        {
          if (butt.getBounds().Contains(e.Position) && butt.getState() == ButtonState.Active)
          {
            butt.setState(ButtonState.Idle);
            butt.onClick();
            break;
          }
          else
          {
            butt.setState(ButtonState.Idle);
          }
        }
      }
  }
  
  public void startPolling(RenderWindow win)
  {
      active = true;
      win.MouseButtonPressed += onMousePressed;
      win.MouseButtonReleased += onMouseReleased;
  }

  public void stopPolling(RenderWindow win)
  {
    active = false;
    win.MouseButtonPressed -= onMousePressed;
    win.MouseButtonReleased -= onMouseReleased;
  }
  
  public bool isActive()
  {
    return active;
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



