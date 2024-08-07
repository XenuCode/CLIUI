namespace CLIUI;

public class Canvas : IRenderable
{
    private String _canvasName;
    public List<IWidget> Widgets { get; set; } = new();
    
    public char[] Render(int width, int height)
    {
        var tops= Widgets.Where(x =>
            x.Position == LayoutPosition.LeftTop ||
            x.Position == LayoutPosition.MiddleTop ||
            x.Position == LayoutPosition.RightTop);
        var centers =Widgets.Where(x => 
            x.Position == LayoutPosition.LeftCenter ||
            x.Position == LayoutPosition.MiddleCenter ||
            x.Position == LayoutPosition.RightCenter);
        var bottoms = Widgets.Where(x =>
            x.Position == LayoutPosition.LeftBottom ||
            x.Position == LayoutPosition.MiddleBottom ||
            x.Position == LayoutPosition.RightBottom);
        var levelCount = 0;
        if (tops.Any())
            levelCount++;
        if (centers.Any())
            levelCount++;
        if (bottoms.Any())
            levelCount++;
        var perLevelHeight =(int) Math.Round((double)((height) / levelCount),MidpointRounding.AwayFromZero);

        var topLevelChars = RenderLevel((int) Math.Round((double)((height) / levelCount),MidpointRounding.AwayFromZero),width, tops);
        return topLevelChars;
    }

    private char[] RenderLevel(int perLevelHeight, int width, IEnumerable<IWidget> widgets)
    {
        var perWidgetWidth = (width) / widgets.Count();
        char[] levelChars = new char[perLevelHeight * width];
        Console.WriteLine(levelChars.Length);
        for (int x = 0; x < width*perLevelHeight; x++)
        {
            levelChars[x] = '\u2591';
        }
        int z = 0;
        Console.WriteLine(Console.WindowWidth);
        foreach (var layout in widgets)
        {
            var chars = layout.Render(perWidgetWidth, perLevelHeight);
            for (int y = 0; y < perLevelHeight; y++)
            {
                for (int x = 0; x < perWidgetWidth; x++)
                {
                    levelChars[y * perWidgetWidth + x +z*perWidgetWidth*(y+1)] = chars[y * perWidgetWidth + x];
                }
            }
            z++;
        }
        return levelChars;
    }
}

