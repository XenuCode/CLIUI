namespace CLIUI;

public class Layout : IRenderable
{
    public LayoutPosition Position { get; set; }

    private int PreferredSize { get; set; } = 0;
    public Layout(LayoutPosition position)
    {
        Position = position;
    }

    public char[] Render(int width, int height)
    {
        throw new NotImplementedException();
    }
}