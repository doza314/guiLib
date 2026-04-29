using SFML.Window;

namespace guiLib;
using SFML.System;
using SFML.Graphics;

public class Menu
{
  private SFML.Graphics.Color bgColor;
  private Texture bgTexture;
  private List<Button> butts = new List<Button>();
  
  public Menu(string title, Vector2u dimensions, string? bgImageName = null, SFML.Graphics.Color? backgroundColor = null)
  {
    if (bgImageName == null && backgroundColor == null)
    {
      bgColor = SFML.Graphics.Color.Black;
    }
  }
  
  public void clickChecking(RenderWindow win)
  {
    win.MouseButtonPressed += (sender, e) => //left mouse click event
    {
      foreach (Button butt in butts)
      {
        if (e.Button == Mouse.Button.Left)
        {
          if (butt.getBounds().Contains(e.Position))
          {
            butt.setState(ButtonState.Active);
            if (butt.selected())
            {
              
            }
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
            butt.setState(ButtonState.Selected);
            
            break;
          }
          else
          {
            butt.setState(ButtonState.Idle);
          }
        }
      }
    };
  }
}