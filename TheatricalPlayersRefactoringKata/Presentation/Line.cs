using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKata.Presentation
{
    public class Line
    {
        public string Name;
        public decimal Value;
        public int Seats;
        public int EarnedCredits;

        public Line(string name, decimal value, int seats, int earnedCredits)
        {
            Name = name;
            Value = value;
            Seats = seats;
            EarnedCredits = earnedCredits;
        }
    }
}
