namespace TheatricalPlayersRefactoringKata;

public class Play
{
    public string Name { get; set; }
    public int Lines { get; set; }
    public PlayType Type { get; set; }

    public Play(string name, int lines, PlayType type) {
        this.Name = name;
        this.Lines = lines;
        this.Type = type;
    }
}
