using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnitTestPractice;

namespace Tests
{
	[TestFixture]
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void when_input_empty_string()
		{
			var actual = new StringCalculator().Add(string.Empty);
			var expected = 0;

			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void when_pass_1_should_return_1()
		{
			var actual = new StringCalculator().Add("1");
			var expected = 1;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void when_pass_1_and_2_should_return_3()
		{
			var actual = new StringCalculator().Add("1,2");
			var expected = 3;

			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void processing_addition_with_different_separators()
		{
			var actual = new StringCalculator().Add("1,2\n3");
			var expected = 6;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void support_different_delimiters_with_empty_string()
		{

			var actual = new StringCalculator().Add(";\n1;2");
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

		[Test]
		public void calling_add_with_negative_number_is_not_allowed()
		{
			var negativeNumberException = Assert.Throws<NegativeNumberException>(() => new StringCalculator().Add("-1,-2"), "negatives not allowed");
			Assert.That(negativeNumberException.Message, Is.EqualTo("negatives not allowed -1;-2"));
		}

		[Test]
		public void number_over_1000_should_be_ignored()
		{
			var actual = new StringCalculator().Add("2,1001");
			var expected = 2;
			Assert.AreEqual(expected, actual);
		}
	}
}