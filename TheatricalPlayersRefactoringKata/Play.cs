namespace TheatricalPlayersRefactoringKata;

public class Play
{
    private string _name;
    private int _lines;
    private string _type;

    public string Name { get; set; }
    public int Lines { get; set; }
    public PlayType Type { get; set; }

    public Play(string name, int lines, PlayType type) {
        this.Name = name;
        this.Lines = lines;
        this.Type = type;
    }
}
