using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Presentation;

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

        public static Statement Calculate(Invoice invoice, Dictionary<string, Play> plays)
        {
            Statement statement = new();
            statement.TheaterCompany = invoice.Customer;

            var totalAmount = 0;

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayId];
                var lines = Math.Clamp(play.Lines, MIN_LINES, MAX_LINES);
                var thisAmount = lines * BASE_VALUE_DIVISOR;
                var credits = EarnedCredits(perf, play);
                statement.Credits += credits;

                switch (play.Type)
                {
                    case PlayType.Tragedy:
                        thisAmount = TragedyCalculation(perf, thisAmount);
                        break;

                    case PlayType.Comedy:
                        thisAmount = ComedyCalculation(perf, thisAmount);
                        break;

                    case PlayType.Historical:
                        thisAmount = ComedyCalculation(perf, thisAmount) + TragedyCalculation(perf, thisAmount);
                        break;
                    default:
                        throw new Exception("unknown type: " + play.Type.ToString());

                }

                statement.Lines.Add(new Line(play.Name, ((decimal)thisAmount / 100), perf.Audience, credits));
                totalAmount += thisAmount;
            }

            statement.Amount = Convert.ToDecimal((decimal)totalAmount / 100);
            return statement;
        }

        public static int ComedyCalculation(Performance perf, int thisAmount)
        {
            if (perf.Audience > COMEDY_AUDIENCE_THRESHOLD)
            {
                thisAmount += 10000 + 500 * (perf.Audience - COMEDY_AUDIENCE_THRESHOLD);
            }
            thisAmount += 300 * perf.Audience;
            return thisAmount;
        }

        public static int TragedyCalculation(Performance perf, int thisAmount)
        {
            if (perf.Audience > TRAGEDY_AUDIENCE_THRESHOLD)
            {
                thisAmount += 1000 * (perf.Audience - TRAGEDY_AUDIENCE_THRESHOLD);
            }

            return thisAmount;
        }

        public static int EarnedCredits(Performance perf, Play play)
        {
            int credits = Math.Max(perf.Audience - AUDIENCE_CREDIT_THRESHOLD, 0);

            if (play.Type == PlayType.Comedy)
            {
                credits += (int)Math.Floor((decimal)perf.Audience / COMEDY_BONUS_DIVISOR);
            }

            return credits;
        }
    }
}
