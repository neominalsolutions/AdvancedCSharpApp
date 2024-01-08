using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.Regexx
{
  public static class RegexSample
  {
    public static void RegexExample()
    {
      string input = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

      string pattern = @"\b\w+\b";

      MatchCollection matches = Regex.Matches(input, pattern);

      Console.WriteLine($"Kelime adeti : {matches.Count}");

      string replacedString = Regex.Replace(input, "Lorem", "Akedaş");

      Console.WriteLine(replacedString);

      string password = "MyP@ssw0rd";

      string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

      if (Regex.IsMatch(password, passwordPattern)){
        Console.WriteLine("Valid Parol");
      }

    }
  }
}
