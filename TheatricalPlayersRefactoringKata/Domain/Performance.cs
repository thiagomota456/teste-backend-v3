namespace TheatricalPlayersRefactoringKata.Domain;

public class Performance
{
    public int Id { get; set; }
    public string PlayId { get; set; }
    public int Audience { get; set; }

    public Performance() { }

    public Performance(string playID, int audience)
    {
        PlayId = playID;
        Audience = audience;
    }

}
