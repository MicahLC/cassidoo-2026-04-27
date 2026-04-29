using FluentAssertions;

namespace cassidoo_2026_04_27
{
	[TestClass]
	public sealed class RepairsTest
	{
		[TestMethod]
		public void TestEmailExample1()
		{
			int[,] grid = {
				{ 1, 0, 0, 1 },
				{ 1, 0, 0, 1 },
				{ 1, 1, 0, 1 },
				{ 0, 1, 1, 1 },
			};
			var k = 2;

			Repairs.MinRepairs(grid, k).Should().Be(2);
		}

		[TestMethod]
		public void TestEmailExample2()
		{
			int[,] newGrid = {
				{ 1, 0, 0, 1},
				{ 1, 0, 0, 1},
				{ 1, 1, 0, 1},
				{ 0, 0, 1, 1},
			};
			var newK = 1;

			Repairs.MinRepairs(newGrid, newK).Should().Be(3);
		}
	}
}
