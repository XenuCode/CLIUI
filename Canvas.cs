namespace CLIUI;

public class Canvas : IRenderable
{
    private String _canvasName;
    private List<Layout> _layouts;

    public char[] Render(int width, int height)
    {
        var tops= _layouts.Where(x =>
            x.Position == LayoutPosition.LeftTop ||
            x.Position == LayoutPosition.MiddleTop ||
            x.Position == LayoutPosition.RightTop);
        var centers =_layouts.Where(x => 
            x.Position == LayoutPosition.LeftCenter ||
            x.Position == LayoutPosition.MiddleCenter ||
            x.Position == LayoutPosition.RightCenter);
        var bottoms = _layouts.Where(x =>
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
        var perLevelHeight = (height - levelCount - 1) / levelCount;

        var topLevelChars = RenderLevel(perLevelHeight,width, tops);
        throw new NotImplementedException();
    }

    public char[] RenderLevel(int perLevelHeight, int width, IEnumerable<Layout> layouts)
    {
        var perLevelWidth = (width - layouts.Count() - 1) / layouts.Count();
        char[] levelChars = new char[perLevelHeight * width];
        foreach (var layout in layouts)
        {
            var chars = layout.Render(perLevelWidth, perLevelHeight);
        }

        throw new NotImplementedException();    }
}