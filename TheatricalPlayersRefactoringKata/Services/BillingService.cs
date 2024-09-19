using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Services
{
    public class BillingService
    {
        private const int MIN_LINES = 1000;
        private const int MAX_LINES = 4000;

        private const int BASE_VALUE_DIVISOR = 10;

        private const int TRAGEDY_AUDIENCE_THRESHOLD = 30;

        private const int COMEDY_AUDIENCE_THRESHOLD = 20;

        private const int AUDIENCE_CREDIT_THRESHOLD = 30;
        private const int COMEDY_BONUS_DIVISOR = 5;

        public Statement Calculate(Invoice invoice, Dictionary<string, Play> plays)
        {
            Statement statement = new();

            var totalAmount = 0;
            var volumeCredits = 0;

            statement.Lines = new();

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayId];
                var lines = Math.Clamp(play.Lines, MIN_LINES, MAX_LINES);
                var thisAmount = lines * BASE_VALUE_DIVISOR;

                volumeCredits += Math.Max(perf.Audience - AUDIENCE_CREDIT_THRESHOLD, 0);

                switch (play.Type)
                {
                    case PlayType.Tragedy:
                        if(perf.Audience > TRAGEDY_AUDIENCE_THRESHOLD)
                        {
                            thisAmount += 1000 * (perf.Audience - TRAGEDY_AUDIENCE_THRESHOLD);
                        }
                    break;

                    case PlayType.Comedy:
                        if(perf.Audience > COMEDY_AUDIENCE_THRESHOLD)
                        {
                            thisAmount += 10000 + 500 * (perf.Audience - COMEDY_AUDIENCE_THRESHOLD);
                        }
                        thisAmount += 300 * perf.Audience;
                        volumeCredits += (int)Math.Floor((decimal)perf.Audience / COMEDY_BONUS_DIVISOR);
                    break;

                }

                statement.Lines.Add(new Line(play.Name, thisAmount / 100, perf.Audience));
                totalAmount += thisAmount;
            }

            statement.Amount = Convert.ToDecimal(totalAmount / 100);
            statement.Credits = volumeCredits;
            return statement;
        }
    }
}
