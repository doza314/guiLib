namespace guiLib;

public class Transition //This class acts as the main unit that couples the menu and their corresponding trigger
{
    private string sharedName = "";
    private Button button;
    private Menu menu;
    
    public Transition(string name)
    {
        sharedName = name;
    }
    
    
}