using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public  class Line
    {
        public string Name;
        public decimal Value;
        public int Seats;

        public Line(string name, decimal value, int seats)
        {
            this.Name = name;
            this.Value = value;
            this.Seats = seats;
        }
    }
}
