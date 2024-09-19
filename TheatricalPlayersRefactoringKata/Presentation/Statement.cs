using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Presentation
{
    public class Statement
    {
        public Statement(string theaterCompany)
        {
            TheaterCompany = theaterCompany;
        }

        public Statement() { }


        public string TheaterCompany { get; set; }
        public List<Line> Lines { get; set; }
        public decimal Amount { get; set; }
        public int Credits { get; set; }
    }
}
