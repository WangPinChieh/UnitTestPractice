using System;
using System.Collections.Generic;

namespace UnitTestPractice
{
	public class AliceAndBobUtility
	{
		public int[] CompareTriplets(List<int> aliceTriplet, List<int> bobTriplet)
		{
			var alicePoints = 0;
			var bobPoints = 0;
			var arrayLength = aliceTriplet.Count;
			for (int i = 0; i < arrayLength; i++)
			{
				var result = aliceTriplet[i] - bobTriplet[i];
				if (result < 0)
					bobPoints += 1;
				else if (result > 0)
					alicePoints += 1;
			}

			return new int[] {alicePoints, bobPoints};
		}
	}
}