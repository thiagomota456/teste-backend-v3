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
        var plays = new Dictionary<int, Play>
        {
            { 1, new Play("Hamlet", 4024, PlayType.Tragedy) },
            { 2, new Play("As You Like It", 2670, PlayType.Comedy) },
            { 3, new Play("Othello", 3560, PlayType.Tragedy) }
        };

        Invoice invoice = new(
            "BigCo",
            new List<Performance>
            {
                new(1, 55),
                new(2, 35),
                new(3, 40),
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

        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.TXT);
        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXmlStatementExample()
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

        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.XML);
        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestJsonStatementExample()
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

        StatementPrinter statementPrinter = new(invoice, plays);
        string result = statementPrinter.Print(PrintType.JSON);
        Approvals.Verify(result);
    }
}
