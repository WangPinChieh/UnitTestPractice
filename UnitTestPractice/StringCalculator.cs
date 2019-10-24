using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestPractice
{
	public class StringCalculator
	{
		private List<int> _invalidInputs;

		public StringCalculator()
		{
			_invalidInputs = new List<int>();
		}

		public int Add(string numbersString)
		{
			if (string.IsNullOrEmpty(numbersString))
				return 0;

			var legalSeparators = GetLegalSeparators(numbersString);

			var numbers = GetNumbers(numbersString, legalSeparators);

			var result = AddAll(numbers);
			
			HandleInvalidNumbers();

			return result;

		}

		private int AddAll(IEnumerable<int> numbers)
		{
			return numbers.Where(IsValid).Sum();
		}

		private void HandleInvalidNumbers()
		{
			if (_invalidInputs.Count > 0)
				throw new NegativeNumberException($"negatives not allowed {string.Join(";", _invalidInputs.ToArray())}");
		}

		private IEnumerable<int> GetNumbers(string numbersString, List<string> legalSeparators)
		{
			return numbersString.Split(legalSeparators.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(m => Convert.ToInt32(m)).ToList();
		}

		private bool IsValid(int number)
		{
			if (number < 0)
			{
				_invalidInputs.Add(number);
				return false;
			}

			return number <= 1000;
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

	public class NegativeNumberException : Exception
	{
		public NegativeNumberException(string negativesNotAllowed) : base(negativesNotAllowed)
		{
		}
	}
}
