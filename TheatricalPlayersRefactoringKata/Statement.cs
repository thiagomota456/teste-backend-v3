using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class Statement
    {
        public string TheaterCompany { get; set; }
        public Line[] Lines { get; set; }
        public decimal Amount { get; set; }
        public int Credits { get; set; }
    }
}
