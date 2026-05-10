using System.Reflection.Metadata.Ecma335;

namespace guiLib;

using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;



/*
I like my buttons to have idle, active, and selected states.

- "Idle" is what it sounds like. Just existing. Doing nothing. Waiting for interaction.

- "Active" is when the user is holding left-click within the bounds of the button dimensions (basically "actively" being pressed).
If the user's cursor exits the bounds of the button while in the active state, the button will be released back 
to the idle state. If left-click is released while the cursor is within bounds of the button, the button will then go to "selected" state. 

- "Selected" is when the user releases left-click while in the active state, meaning the button has been "selected" by 
the user. The button carries out whatever function it's associated with and then returns to idle state.

I'll probably make a toggle switch variant, too.
*/

//INPUT PARAMETERS: POSITION (X,Y), DIMENSIONS (X,Y), FILE PATH

public class Button
{
    private ButtonState state = ButtonState.Idle; //0 = idle, 1 = active, 2 = selected
    
    private string name;
    
    private string fileName;
    private string idleString;
    private string activeString;
    private Texture idleTexture;
    private Texture activeTexture;
    private Texture fallbackTexture = new Texture(new Vector2u(1, 1));
    
    private Vector2f pos;
    private Vector2f scale;
    
    private Sprite sprite;

    private Shape shape;
    private Color color;

    //button texture file name will default to buttonName + ".png"
    public Button(Vector2f position, string buttonName) //NAME STRING CORRESPONDS TO THE ASSOCIATED MENU
    {
        name = buttonName;
        idleString = "res/" + buttonName + ".png";
        activeString = "res/" + buttonName + "_pressed.png";
        
        sprite = new Sprite(fallbackTexture);

        try
        {
            idleTexture = new Texture(idleString);
            sprite.Texture = new Texture(idleTexture);
        }
        catch
        {
            Console.WriteLine("Could not find " + idleString);
        }

        try
        {
            activeTexture = new Texture(activeString);
        }
        catch
        {
            Console.WriteLine("Could not find " + activeString);
        }

        pos = position;
        
        sprite.Origin = new Vector2f(0, 0); //origin of sprite in top-left corner
        sprite.Position = pos;
    }

    
    //SETTERS
    public void textureFileOverride(string filename)
    {
        fileName = filename.Replace("res/", "")
            .Replace("_pressed", "")
            .Replace(".png", "")
            .Replace(".jpeg", "")
            .Replace(".jpg", "");
        
        idleString = "res/" + fileName + ".png";
        idleTexture = new Texture(idleString);
        
        activeString = "res/" + fileName + "_pressed.png";
        activeTexture = new Texture(activeString);
        
        sprite.Dispose();
        sprite = new Sprite(idleTexture);
        sprite.Origin = new Vector2f(0, 0);
        sprite.Position = pos;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public void setPosition(Vector2f position)
    {
        pos = position;
    }

    public void setScale(Vector2f spriteScale)
    {
        scale = spriteScale;
        sprite.Scale = scale;
    }

    public void setState(ButtonState buttState, bool? adjustTexture = true)
    {
        this.state = buttState;

        switch (state)
        {
            case ButtonState.Active:
 
                sprite.Texture = activeTexture;
                break;
            case ButtonState.Idle:
                sprite.Texture = idleTexture;
                break;
            default:
                break;
        }
    }

   

    //GETTERS
    public string getName()
    {
        return name;
    }
    
    public string getActiveString()
    {
        return activeString;
    }

    public string getIdleString()
    {
        return idleString;
    }
    
    public Vector2f getPosition()
    {
        return pos;
    }

    public Vector2f getScale()
    {
        return scale;
    }

    public ButtonState getState()
    {
        return state;
    }
    
    public FloatRect getBounds()
    {
        return sprite.GetGlobalBounds();
    }

    
    //DRAW BUTTON
    public void drawSprite(RenderWindow win)
    {
        win.Draw(sprite);
    }
}