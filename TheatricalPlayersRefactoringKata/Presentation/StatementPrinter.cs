using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Services;

namespace TheatricalPlayersRefactoringKata.Presentation;

public class StatementPrinter
{
    public Invoice InvoceToCalculate { get; set; }
    public Dictionary<string, Play> Plays { get; set; }
    public CultureInfo CultureInfo { get; set; }

    public StatementPrinter(Invoice invoceToCalculate, Dictionary<string, Play> plays, CultureInfo cultureInfo)
    {
        InvoceToCalculate = invoceToCalculate;
        Plays = plays;
        CultureInfo = cultureInfo;
    }

    public StatementPrinter(Invoice invoceToCalculate, Dictionary<string, Play> plays)
    {
        InvoceToCalculate = invoceToCalculate;
        Plays = plays;
        CultureInfo = new CultureInfo("en-US");
    }
    public string Print(PrintType printType)
    {
        var result = BillingService.Calculate(this.InvoceToCalculate, this.Plays);

        switch (printType) {

            case PrintType.TXT:
                return PrintTxt(result);
            case PrintType.XML:
                throw new Exception("Not Implemeted");
            default:
                throw new Exception("Not Implemeted");
        }
       
    }

    internal string PrintTxt(Statement statement)
    {
        var stringTxt = $"Statement for {statement.TheaterCompany}\n";
        foreach (var line in statement.Lines)
        {
            stringTxt += $"  {line.Name}: {line.Value.ToString("C", CultureInfo)} ({line.Seats} seats)\n";
        }
        stringTxt += $"Amount owed is {statement.Amount.ToString("C", CultureInfo)}\n";
        stringTxt += $"You earned {statement.Credits} credits\n";

        return stringTxt;
    }
}
