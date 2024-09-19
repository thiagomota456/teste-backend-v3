using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using ApprovalTests;
using ApprovalTests.Reporters;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Presentation;
using TheatricalPlayersRefactoringKata.Services;
using Xunit;
using Xunit.Abstractions;

namespace TheatricalPlayersRefactoringKata.Tests.Presentation;


[ApprovalTests.Namers.UseApprovalSubdirectory(@"..\respostas")]
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
        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.TXT);
        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, PlayType.Tragedy));
        plays.Add("as-like", new Play("As You Like It", 2670, PlayType.Comedy));
        plays.Add("othello", new Play("Othello", 3560, PlayType.Tragedy));
        plays.Add("henry-v", new Play("Henry V", 3227, PlayType.Historical));
        plays.Add("john", new Play("King John", 2648, PlayType.Historical));
        plays.Add("richard-iii", new Play("Richard III", 3718, PlayType.Historical));

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
                new Performance("henry-v", 20),
                new Performance("john", 39),
                new Performance("henry-v", 20)
            }
        );

        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.TXT);
        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXmlStatementExample()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, PlayType.Tragedy));
        plays.Add("as-like", new Play("As You Like It", 2670, PlayType.Comedy));
        plays.Add("othello", new Play("Othello", 3560, PlayType.Tragedy));
        plays.Add("henry-v", new Play("Henry V", 3227, PlayType.Historical));
        plays.Add("john", new Play("King John", 2648, PlayType.Historical));
        plays.Add("richard-iii", new Play("Richard III", 3718, PlayType.Historical));

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
                new Performance("henry-v", 20),
                new Performance("john", 39),
                new Performance("henry-v", 20)
            }
        );

        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.XML);
        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestJsonStatementExample()
    {
        var plays = new Dictionary<string, Play>();
        plays.Add("hamlet", new Play("Hamlet", 4024, PlayType.Tragedy));
        plays.Add("as-like", new Play("As You Like It", 2670, PlayType.Comedy));
        plays.Add("othello", new Play("Othello", 3560, PlayType.Tragedy));
        plays.Add("henry-v", new Play("Henry V", 3227, PlayType.Historical));
        plays.Add("john", new Play("King John", 2648, PlayType.Historical));
        plays.Add("richard-iii", new Play("Richard III", 3718, PlayType.Historical));

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40),
                new Performance("henry-v", 20),
                new Performance("john", 39),
                new Performance("henry-v", 20)
            }
        );

        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.JSON);
        Approvals.Verify(result);
    }
}
