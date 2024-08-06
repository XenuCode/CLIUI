namespace CLIUI.Widgets;

public class TextWidget: IWidget
{
    public TextWidget(string text)
    {
        Text = text;
    }

    private string Text { get; set; } 
    public LayoutPosition Position { get; set; }
    public char[] Render(int width, int height)
    {
        char[] chars = new char[width * height]; 
        int textLength = Text.Length;
        var centreWidth = width / 2;
        var centreHeight = height / 2;
        int start = centreWidth - Text.Length/2;
        for (int x = 0; x < width*height; x++)
        {
            chars[x] = '\u2591';
        }
        for (int i = 0; i < textLength; i++)
        {
            chars[start + width * centreHeight] = Text[i];
            start++;
        }

        return chars;
    }
}