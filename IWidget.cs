namespace CLIUI;

public interface IWidget
{
    public LayoutPosition Position { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns>Array of characters in continuous manner, LTR</returns>
    public char[] Render(int width, int height);
}