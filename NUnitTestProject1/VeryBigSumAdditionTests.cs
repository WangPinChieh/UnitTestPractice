using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using UnitTestPractice;

namespace Tests
{
	[TestFixture]
	public class VeryBigSumAdditionTests
	{
		[Test]
		public void should_add_up()
		{
			var ary = new long[] {1000000001, 1000000002, 1000000003, 1000000004, 1000000005};

			var actual = new VeryBigSumAdditionUtility().SumUp(ary);
			var expected = 5000000015;

			Assert.AreEqual(expected, actual);
		}
	}

}