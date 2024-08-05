namespace CLIUI;

public interface IWidget
{
    public LayoutPosition Position { get; set; }

    public string Render()
    {
        //TODO IMPLEMNTATIONE
        return "-----\n" +
               "|ads|\n" +
               "-----\n";
    }
}