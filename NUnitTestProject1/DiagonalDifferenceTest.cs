using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class DiagonalDifferenceTest
	{
		[Test]
		public void should_add_up_diagonal_difference_2_2()
		{
			List<List<int>> arr = new List<List<int>>()
			{
				new List<int>() {1, 2},
				new List<int>() {4, 5}
			};

			var expected = 0;
			var actual = new DiagonalDifferenceUtility().SumUp(arr);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void should_add_up_diagonal_difference_3_3()
		{
			List<List<int>> arr = new List<List<int>>()
			{
				new List<int>() {1, 2, 3},
				new List<int>() {4, 5, 6},
				new List<int>() {7, 8, 9}
			};

			var expected = 0;
			var actual = new DiagonalDifferenceUtility().SumUp(arr);

			Assert.AreEqual(expected, actual);

		}
	}

	public class DiagonalDifferenceUtility
	{
		public int SumUp(List<List<int>> input)
		{
			var size = input.Count();
			var leftToRightSum = 0;
			var leftToRightIndex = 0;
			var rightToLeftSum = 0;
			var rightToLeftIndex = size - 1;
			for (var i = 0; i < size; i++)
			{
				leftToRightSum += input[i][leftToRightIndex];
				leftToRightIndex++;

				rightToLeftSum += input[i][rightToLeftIndex];
				rightToLeftIndex--;
			}
			return Math.Abs(leftToRightSum - rightToLeftSum);

		}
	}
}