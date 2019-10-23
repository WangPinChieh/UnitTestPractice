using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnitTestPractice;

namespace Tests
{
	[TestFixture]
	public class Tests
	{
		private StringCalculator _stringCalculator;
		[SetUp]
		public void Setup()
		{
			_stringCalculator = new StringCalculator();
		}

		[Test]
		public void when_input_empty_string()
		{
			var actual = _stringCalculator.Add(string.Empty);
			var expected = 0;

			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void when_pass_1_should_return_1()
		{
			var actual = _stringCalculator.Add("1");
			var expected = 1;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void when_pass_1_and_2_should_return_3()
		{
			var actual = _stringCalculator.Add("1,2");
			var expected = 3;

			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void processing_addition_with_different_separators()
		{
			var actual = _stringCalculator.Add("1,2\n3");
			var expected = 6;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void support_different_delimiters_with_empty_string()
		{

			var actual = _stringCalculator.Add(";\n1;2");
			var expected = 3;

			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void test_regular_expression()
		{
			var regex = new Regex(@"^(.{1})\n(.*)$");

			var input = ";\n1;1";
			var match = regex.Match(input);
			var separator = string.Empty;

			if (match.Success)
				separator = match.Groups[1].Value;

			Assert.AreEqual(";", separator);
		}

	}
}