using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Presentation;

namespace TheatricalPlayersRefactoringKataAPI.Model
{
    public class CalculateInput
    {
        public CalculateInput() { }
        public PrintType PrintType { get; set; }
        public int InvoceToCalculate { get; set; }
        public int[] Plays { get; set; }
        public string CultureInfo = "en-US";

    }
}
