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

    public void StartRendering()
    {
        ConsoleEvents consoleEvents = new ConsoleEvents();
        consoleEvents.OnConsoleSizeChange += (sender, windowSize) =>
        {
            Console.WriteLine(Console.WindowHeight);
            Render( windowSize);
        };
        consoleEvents.StartListening();
        Render(new WindowSize(Console.WindowWidth,Console.WindowHeight));
    }
    private void Render(WindowSize? windowSize)
    {
        Console.Clear();
        if (windowSize is null) {
            windowSize = new WindowSize(Console.WindowWidth, Console.WindowHeight);
        }
        int renderWidth = windowSize.Width - 2;
        int renderHeight = windowSize.Height - 4;
        var chars = _canvasMap[0].Render(renderWidth, renderHeight);
        
        for (int i = 0; i < renderHeight; i++)
        {
            for (int x = 0; x < renderWidth; x++)
            {
                if (x == 0 && i == 0) {
                    Console.Write('\u250C');
                }else if (x==0 && i!=renderHeight-1) {
                    Console.Write('\u2502');
                }else if (i == renderHeight - 1 && x == 0) {
                    Console.Write('\u2514');
                }

                Console.Write(chars[x+i*renderWidth]);
                if (i == 0 & x == renderWidth - 1) {
                    Console.Write('\u2510');
                }else if (x == renderWidth - 1 && i != renderHeight - 1) {
                    Console.Write('\u2502');
                }else if (i == renderHeight - 1 && x == renderWidth - 1) {
                    Console.Write('\u2518');
                }
            }
            Console.Write("\n");
        }
    }

    /// <summary>
    /// Adds a new canvas with specified index
    /// </summary>
    /// <param name="canvas">Canvas that's to be added</param>
    /// <param name="index">Canvas's index number</param>
    public void AddCanvas(Canvas canvas, int index)
    {
        _canvasMap.Add(index,canvas);
    }
}