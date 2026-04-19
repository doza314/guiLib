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
}