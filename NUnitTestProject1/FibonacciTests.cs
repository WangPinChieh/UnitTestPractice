using System.Diagnostics;
using NUnit.Framework;
using UnitTestPractice;

namespace Tests
{
	[TestFixture]
	public class FibonacciTests
	{
		[Test]
		public void when_input_0_should_return_0()
		{
			var actual = new FibonacciHelper().GetSum(0);
			var expected = 0;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void when_input_1_should_return_1()
		{
			var actual = new FibonacciHelper().GetSum(1);
			var expected = 1;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void when_input_2_should_return_1()
		{
			var actual = new FibonacciHelper().GetSum(2);
			var expected = 1;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void when_input_3_should_return_2()
		{
			var actual = new FibonacciHelper().GetSum(3);
			var expected = 2;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void when_input_12_should_return_144()
		{
			var actual = new FibonacciHelper().GetSum(12);
			var expected = 144;

			Assert.AreEqual(expected, actual);
		}
	}
}