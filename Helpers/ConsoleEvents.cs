namespace CLIUI.Helpers;

public class ConsoleEvents
{
    public event EventHandler<WindowSize>? OnConsoleSizeChange;
    protected virtual void ConsoleSizeChange(WindowSize e)
    {
        // Make a temporary copy of the event to avoid possibility of
        // a race condition if the last subscriber unsubscribes
        // immediately after the null check and before the event is raised.
        EventHandler<WindowSize>? raiseEvent = OnConsoleSizeChange;

        // Event will be null if there are no subscribers
        if (raiseEvent != null)
        { 
            raiseEvent(this,e);
        }
    }

    public void StartListening()
    {
        new Thread(o =>
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            while (true)
            {
                if (Console.WindowWidth != width || Console.WindowHeight != height)
                {
                    width = Console.WindowWidth;
                    height = Console.WindowHeight;
                    OnConsoleSizeChange?.Invoke(this, new WindowSize(width, height)); // Corrected line
                }
                Thread.Sleep(10);
            }
        }).Start();
    }
}

public class WindowSize
{
    public WindowSize(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; set; }
    public int Height { get; set; }
}