namespace UnitTestPractice
{
	public class FibonacciHelper
	{
		public int GetSum(int index)
		{
			int result = 0;

			if (index == 0 || index == 1)
				return index;

			result += GetSum(index - 2) + GetSum(index - 1);

			return result;
		}
	}
}