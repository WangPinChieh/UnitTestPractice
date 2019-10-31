using NUnit.Framework;
using UnitTestPractice;

namespace Tests
{
	[TestFixture]
	public class StepsOrganizerTests
	{
		[Test]
		public void when_input_1_step_should_return_1()
		{
			var stepsOrganizer = new StepsOrganizer(1);
			var actual = stepsOrganizer.GetResult();
			var expected = 1;

			Assert.AreEqual(expected, actual);
		}

		[Test] public void when_input_2_steps_should_return_3()
		{
			var stepsOrganizer = new StepsOrganizer(2);
			var actual = stepsOrganizer.GetResult();
			var expected = 3;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void when_input_3_steps_should_return_7()
		{
			var stepsOrganizer = new StepsOrganizer(3);
			var actual = stepsOrganizer.GetResult();
			var expected = 7;

			Assert.AreEqual(expected, actual);
		}
	}
}