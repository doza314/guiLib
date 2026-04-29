using System.Diagnostics.Tracing;

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

    private string idleString;
    private string activeString;
    private Texture idleTexture;
    private Texture activeTexture;
    private Vector2f pos;
    private Vector2f dims;
    private Sprite sprite;
    private bool on = false;
    private bool isToggle = false;
    private string name;

    public Button(Vector2f position, Vector2f dimensions, string buttonName, bool toggleable, )
    {
        name = buttonName;
        isToggle = toggleable;
        idleString = "res/" + buttonName + ".png";
        activeString = "res/" + buttonName + "_pressed.png";

        idleTexture = new Texture(idleString);
        activeTexture = new Texture(activeString);

        pos = position;
        dims = dimensions;

        sprite = new Sprite(idleTexture); //just default to idle texture
        sprite.Origin = new Vector2f(0, 0); //origin of sprite in top-left corner
        sprite.Position = pos;
    }

    public void setState(ButtonState buttState)
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
            case ButtonState.Selected:
                sprite.Texture = idleTexture;
                break;
            default:
                break;
        }
    }

    public ButtonState getState()
    {
        return state;
    }
    
    public FloatRect getBounds()
    {
        return sprite.GetGlobalBounds();
    }

    public void drawSprite(RenderWindow win)
    {
        win.Draw(sprite);
    }

    public bool selected()
    {
        if (!isToggle)
        {
            return true;
        }
        else
        {
            return false;
        }   
    }
}