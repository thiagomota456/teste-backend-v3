using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Presentation;
using TheatricalPlayersRefactoringKata.Services;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests.Services
{
    public class BillingServiceTests
    {
        Play playTragedy = new Play("Hamlet", 4024, PlayType.Tragedy);
        Performance performanceTragedy = new Performance(1, 55);
        int thisAmountTragedy = 4000 * 10;


        //Teste Tragedy

        [Fact]
        public void EarnedCreditsTragedy()
        {
            int credits = BillingService.EarnedCredits(performanceTragedy, playTragedy);
            Assert.Equal(25, credits);
        }

        [Fact]
        public void TragedyCalculationTest()
        {
            var result = BillingService.TragedyCalculation(performanceTragedy, thisAmountTragedy);
            Assert.Equal(650, result/100);
        }

        //Teste Comedy

        Play playComedy = new Play("As You Like It", 2670, PlayType.Comedy);
        Performance performanceComedy = new Performance(2, 35);
        int thisAmountComedy = 2670 * 10;
        
        [Fact]
        public void EarnedCreditsComedy()
        {
            int credits = BillingService.EarnedCredits(performanceComedy, playComedy);
            Assert.Equal(12, credits);
        }

        [Fact]
        public void ComedyCalculationTest()
        {
            var result = BillingService.ComedyCalculation(performanceComedy, thisAmountComedy);
            Assert.Equal(547, result/100);
        }

        //Historical

        Play playHistorical = new Play("Henry V", 3227, PlayType.Historical);
        Performance performanceHistorical = new Performance(4, 20);
        int thisAmountHistorical = 3227 * 10;

        [Fact]
        public void EarnedCreditsHistorical()
        {
            int credits = BillingService.EarnedCredits(performanceHistorical, playHistorical);
            Assert.Equal(0, credits);
        }

        [Fact]
        public void HistoricalCalculationTest()
        {
            var result = BillingService.ComedyCalculation(performanceHistorical, thisAmountHistorical) + BillingService.TragedyCalculation(performanceHistorical, thisAmountHistorical);
            Assert.Equal(705.4, result / 100.0);
        }

        //All class
        [Fact]
        public void TestClassBillingService()
        {
            var plays = new Dictionary<int, Play>();
            plays.Add(1, new Play("Hamlet", 4024, PlayType.Tragedy));
            plays.Add(2, new Play("As You Like It", 2670, PlayType.Comedy));
            plays.Add(3, new Play("Othello", 3560, PlayType.Tragedy));
            plays.Add(4, new Play("Henry V", 3227, PlayType.Historical));
            plays.Add(5, new Play("King John", 2648, PlayType.Historical));
            plays.Add(6, new Play("Richard III", 3718, PlayType.Historical));

            Invoice invoice = new Invoice(
                "BigCo",
                new List<Performance>
                {
                new Performance(1, 55),
                new Performance(2, 35),
                new Performance(3, 40),
                new Performance(4, 20),
                new Performance(5, 39),
                new Performance(4, 20)
                }
            );

            var result = JsonConvert.SerializeObject(BillingService.Calculate(invoice, plays), Formatting.Indented);
            var respostaJson = File.ReadAllText(Directory.GetCurrentDirectory()+ @"\respostas\BigCo.json");
            Assert.Equal(result, respostaJson);
        }
    }
}
