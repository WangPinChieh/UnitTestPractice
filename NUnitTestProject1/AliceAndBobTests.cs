using System.Collections.Generic;
using ExpectedObjects;
using NUnit.Framework;
using UnitTestPractice;

namespace Tests
{
	[TestFixture]
	public class AliceAndBobTests
	{
		private List<int> _alice;
		private List<int> _bob;

		[Test]
		public void should_get_result_correctly()
		{
			var aliceAndBobUtility = new AliceAndBobUtility();
			GivenAliceTriplet(new List<int>() {5, 6, 7});
			GivenBobTriplet(new List<int>() {3, 6, 10});
			var actual = aliceAndBobUtility.CompareTriplets(_alice, _bob);
			var expected = new List<int> {1, 1};
			expected.ToExpectedObject().ShouldMatch(actual);
		}

		private void GivenBobTriplet(List<int> triplet)
		{
			_bob = triplet;
		}

		private void GivenAliceTriplet(List<int> triplet)
		{
			_alice = triplet;
		}
	}
}