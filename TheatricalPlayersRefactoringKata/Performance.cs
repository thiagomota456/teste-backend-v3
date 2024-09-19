namespace TheatricalPlayersRefactoringKata;

public class Performance
{
    public string PlayId { get; set; }
    public int Audience {  get; set; }

    public Performance(string playID, int audience)
    {
        this.PlayId = playID;
        this.Audience = audience;
    }

}
