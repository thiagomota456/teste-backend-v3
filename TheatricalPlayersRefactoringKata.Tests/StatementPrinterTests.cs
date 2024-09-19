using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using ApprovalTests;
using ApprovalTests.Reporters;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Presentation;
using TheatricalPlayersRefactoringKata.Services;
using Xunit;
using Xunit.Abstractions;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play("Hamlet", 4024, PlayType.Tragedy) },
            { "as-like", new Play("As You Like It", 2670, PlayType.Comedy) },
            { "othello", new Play("Othello", 3560, PlayType.Tragedy) }
        };

        Invoice invoice = new(
            "BigCo",
            new List<Performance>
            {
                new("hamlet", 55),
                new("as-like", 35),
                new("othello", 40),
            }
        );
        //BillingService billingService = new BillingService();
        //var re = BillingService.Calculate(invoice, plays);
        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.TXT);
        Approvals.Verify(result);
     }

    //[Fact]
    //[UseReporter(typeof(DiffReporter))]
    //public void TestTextStatementExample()
    //{
    //    var plays = new Dictionary<string, Play>();
    //    plays.Add("hamlet", new Play("Hamlet", 4024, "tragedy"));
    //    plays.Add("as-like", new Play("As You Like It", 2670, "comedy"));
    //    plays.Add("othello", new Play("Othello", 3560, "tragedy"));
    //    plays.Add("henry-v", new Play("Henry V", 3227, "history"));
    //    plays.Add("john", new Play("King John", 2648, "history"));
    //    plays.Add("richard-iii", new Play("Richard III", 3718, "history"));

    //    Invoice invoice = new Invoice(
    //        "BigCo",
    //        new List<Performance>
    //        {
    //            new Performance("hamlet", 55),
    //            new Performance("as-like", 35),
    //            new Performance("othello", 40),
    //            new Performance("henry-v", 20),
    //            new Performance("john", 39),
    //            new Performance("henry-v", 20)
    //        }
    //    );

    //    StatementPrinter statementPrinter = new StatementPrinter();
    //    var result = statementPrinter.Print(invoice, plays);

    //    Approvals.Verify(result);
    //}
}
