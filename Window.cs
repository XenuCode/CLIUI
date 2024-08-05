namespace CLIUI;

public class Window
{
    private Dictionary<int, Canvas> _canvasMap = new();
    private string WindowName;
    

    public Window(string windowName)
    {
        WindowName = windowName;
    } 
}