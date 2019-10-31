using System.Collections.Generic;

namespace UnitTestPractice
{
	public class StepsOrganizer
	{
		private readonly int _numOfSteps;
		public StepsOrganizer(int numOfSteps)
		{
			_numOfSteps = numOfSteps;
		}

		public int GetResult()
		{
			return GetNumOfWays(0, _numOfSteps);
		}

		private int GetNumOfWays(int currentIndex, int numOfStepsLeft)
		{
			if (numOfStepsLeft == 0)
			{
				return currentIndex == 0 ? 1 : 0;
			}

			numOfStepsLeft--;
			return GetNumOfWays(MoveLeft(currentIndex), numOfStepsLeft) + GetNumOfWays(MoveRight(currentIndex), numOfStepsLeft) + GetNumOfWays(Stay(currentIndex), numOfStepsLeft);
		}

		private int MoveRight(int currentIndex)
		{
			return currentIndex + 1;
		}

		private int MoveLeft(int currentIndex)
		{
			return currentIndex - 1;
		}

		private int Stay(int currentIndex)
		{
			return currentIndex;
		}
	}
}