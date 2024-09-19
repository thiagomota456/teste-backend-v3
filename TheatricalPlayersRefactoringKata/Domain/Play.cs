namespace TheatricalPlayersRefactoringKata.Domain;

public class Play
{
    public string Name { get; set; }
    public int Lines { get; set; }
    public PlayType Type { get; set; }

    public Play(string name, int lines, PlayType type)
    {
        Name = name;
        Lines = lines;
        Type = type;
    }
}
