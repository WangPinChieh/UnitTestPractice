using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestPractice
{
	public class StringCalculator
	{
		public int Add(string numbersString)
		{
			if (string.IsNullOrEmpty(numbersString))
				return 0;

			var legalSeparators = GetLegalSeparators(numbersString);

			var result = 0;
			var splitStrings = numbersString.Split(legalSeparators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			foreach (var s in splitStrings)
			{
				result += Convert.ToInt32(s);
			}

			return result;

		}

		private List<string> GetLegalSeparators(string numbersString)
		{
			var legalSeparators = new List<string>() { ",", "\n" };

			var regex = new Regex(@"^(.{1})\n(.*)$");
			var match = regex.Match(numbersString);
			if (match.Success)
			{
				legalSeparators.Add(match.Groups[1].Value);
			}

			return legalSeparators;
		}
	}
}
