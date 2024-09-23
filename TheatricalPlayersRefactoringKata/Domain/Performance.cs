namespace TheatricalPlayersRefactoringKata.Domain;

public class Performance
{
    public int Id { get; set; }
    public int PlayId { get; set; }
    public int Audience { get; set; }

    public Performance() { }

    public Performance(int playID, int audience)
    {
        PlayId = playID;
        Audience = audience;
    }

}
