using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Presentation
{
    public class Line
    {
        public string Name;
        public decimal Value;
        public int Seats;

        public Line(string name, decimal value, int seats)
        {
            Name = name;
            Value = value;
            Seats = seats;
        }
    }
}
