using System.Linq;

namespace UnitTestPractice
{
	public class VeryBigSumAdditionUtility
	{
		public long SumUp(long[] inputs)
		{
			var sum = inputs.Sum();
			return sum;
		}
	}
}