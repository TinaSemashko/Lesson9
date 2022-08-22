using System;
using System.Text.RegularExpressions;

void Print(string pattern, string[] data)
{
    try
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (Regex.IsMatch(data[i], pattern, RegexOptions.IgnoreCase))
            {
                if (pattern == "patternTel") Console.WriteLine(data[i] + " " + data[i - 1]);
                else Console.WriteLine(data[i] + " " + data[i + 1]);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

try
{
    Console.WriteLine("What do you want find (fname, lname, tel)");
    string typeSearch = Console.ReadLine();
    if (typeSearch == null || (typeSearch != "fname" && typeSearch != "lname" && typeSearch != "tel"))
    {
        throw new Exception("Inserted wrong value");
    }
    else
    {
        Console.WriteLine("Insert " + typeSearch);
        string input = Console.ReadLine();


        string patternFName = @".+?(" + input + ")([A-Za-z_]+)?\\s";
        string patternLName = @"\s.+?(" + input + ")([A-Za-z_]+)?";
        string patternTel = @"[^A-Za-z]+(" + input + ")([0-9]+)?";

        var data = new string[]
        {
    "Martin Pan ",
    "+12398764999",
    "Piter Pan",
    "+12345678999",
    "Gorge Piter",
    "+13435465566",
    "Grit Delon",
    "+43743989393"
        };

        switch (typeSearch)
        {
            case "fname":
                try
                {
                    Print(patternFName, data);
                }
                catch
                {
                    Console.WriteLine("Somethin wrong with " + patternFName);
                }
                break;

            case "lname":
                try
                {
                    Print(patternLName, data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "tel":
                Print(patternTel, data);
                break;
        }
    }
}

catch (Exception e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
    throw;
}



//checked
