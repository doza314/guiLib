using System.Diagnostics.Tracing;

namespace guiLib;

using System;
using System.
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

public class Button(Vector2u position, Vector2u dimensions, string filePath)
{
    private var texture = new Texture(filePath);
    private var pos = position;
    private var dims = dimensions;

    public bool poll()
    {
        
    }
}