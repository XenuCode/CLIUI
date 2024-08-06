using CLIUI.Helpers;

namespace CLIUI;

public class Window
{
    private Dictionary<int, Canvas> _canvasMap = new();
    private string WindowName;
    
    public Window(string windowName)
    {
        WindowName = windowName;
    }
    
    public void Render()
    {
        ConsoleEvents consoleEvents = new ConsoleEvents();
        consoleEvents.OnConsoleSizeChange += (sender, s) =>
        {
            Console.WriteLine("Changed");
        };
        consoleEvents.StartListening();
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        var chars = _canvasMap[0].Render(width - 2, height - 5);
        
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                Console.Write(chars[x+i*Console.WindowWidth]);
            }
            Console.Write("\n");
        }
    }
}