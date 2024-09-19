namespace TheatricalPlayersRefactoringKata.Domain;

public class Performance
{
    public string PlayId { get; set; }
    public int Audience { get; set; }

    public Performance(string playID, int audience)
    {
        PlayId = playID;
        Audience = audience;
    }

}
