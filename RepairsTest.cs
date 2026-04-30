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

		[TestMethod]
		public void TestNoGaps()
		{
			int[,] grid = {
				{1, 1, 1 },
				{1, 1, 1 },
				{1, 1, 1 }
			};
			var k = 1;
			Repairs.MinRepairs(grid, k).Should().Be(0);
		}

		[TestMethod]
		public void TestFillIt()
		{
			int[,] grid =
			{
				{ 0, 0, 0, 0 }
			};
			var k = 0;
			Repairs.MinRepairs(grid, k).Should().Be(4);
		}

		[TestMethod]
		public void TestStraightLine()
		{
			int[,] grid = {
				{1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 }
			};
			Repairs.MinRepairs(grid, 7).Should().Be(0);
			Repairs.MinRepairs(grid, 6).Should().Be(1);
			Repairs.MinRepairs(grid, 5).Should().Be(1);
			Repairs.MinRepairs(grid, 4).Should().Be(1);
			Repairs.MinRepairs(grid, 3).Should().Be(1);
			Repairs.MinRepairs(grid, 2).Should().Be(2);
			Repairs.MinRepairs(grid, 1).Should().Be(3);
		}

		[TestMethod]
		public void TestBigBrokenSection()
		{
			int[,] grid = {
				{1, 0, 0, 0 },
				{0, 0, 0, 0 }
			};
			Repairs.MinRepairs(grid, 7).Should().Be(0);
			Repairs.MinRepairs(grid, 6).Should().Be(1);
			Repairs.MinRepairs(grid, 5).Should().Be(1);
			Repairs.MinRepairs(grid, 4).Should().Be(2);
			Repairs.MinRepairs(grid, 3).Should().Be(2);
			Repairs.MinRepairs(grid, 2).Should().Be(3);
			Repairs.MinRepairs(grid, 1).Should().Be(3);
		}

		[TestMethod]
		public void TestBiggerBrokenSection()
		{
			int[,] grid =
			{
				{0, 0 , 1, 0},
				{0, 0, 0, 0 },
				{0, 0, 0, 0 }
			};
			// 11 broken tiles in a 3 x 4 space.
			Repairs.MinRepairs(grid, 10).Should().Be(1);
			Repairs.MinRepairs(grid, 9).Should().Be(1);
			Repairs.MinRepairs(grid, 8).Should().Be(2);
			Repairs.MinRepairs(grid, 7).Should().Be(2);
			Repairs.MinRepairs(grid, 6).Should().Be(2);
			Repairs.MinRepairs(grid, 5).Should().Be(2);
			Repairs.MinRepairs(grid, 4).Should().Be(3);
			Repairs.MinRepairs(grid, 3).Should().Be(4);
			Repairs.MinRepairs(grid, 2).Should().Be(4);
			Repairs.MinRepairs(grid, 1).Should().Be(5);
		}

		[TestMethod]
		public void TestMassiveBrokenSection()
		{
			int[,] grid =
			{
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0}
			};
			// 36 broken tiles in a 6 x 6 space
			Repairs.MinRepairs(grid, 34).Should().Be(2);
			Repairs.MinRepairs(grid, 33).Should().Be(2);
			Repairs.MinRepairs(grid, 32).Should().Be(3);
			Repairs.MinRepairs(grid, 31).Should().Be(3);
			Repairs.MinRepairs(grid, 30).Should().Be(3);
			Repairs.MinRepairs(grid, 29).Should().Be(4);
			Repairs.MinRepairs(grid, 26).Should().Be(4);
			Repairs.MinRepairs(grid, 25).Should().Be(5);
			Repairs.MinRepairs(grid, 21).Should().Be(5);
			Repairs.MinRepairs(grid, 20).Should().Be(6);
			Repairs.MinRepairs(grid, 15).Should().Be(6);
		}

		[TestMethod]
		public void TestDiagonalsDontConnect()
		{
			int[,] grid =
			{
				{1, 1, 1, 0, 0 },
				{1, 1, 0, 1, 0 },
				{0, 1, 0, 0, 1 },
				{0, 0, 1, 1, 1 },
			};
			// 3 distinct groups of 3 broken tiles, each in a 2x2 space
			Repairs.MinRepairs(grid, 3).Should().Be(0);
			Repairs.MinRepairs(grid, 2).Should().Be(3);
			Repairs.MinRepairs(grid, 1).Should().Be(3);
		}

		[TestMethod]
		public void TestHGap()
		{
			int[,] grid =
			{
				{1, 0, 0, 0, 0 },
				{1, 1, 1, 0, 1 },
				{0, 0, 0, 0, 1 }
			};
			// 9 broken tiles in a 3 x 5 space
			Repairs.MinRepairs(grid, 5).Should().Be(1);
			Repairs.MinRepairs(grid, 4).Should().Be(1);
			Repairs.MinRepairs(grid, 3).Should().Be(2);
			Repairs.MinRepairs(grid, 2).Should().Be(2);
			Repairs.MinRepairs(grid, 1).Should().Be(4);
		}

		[TestMethod]
		public void TestZigZagHGap()
		{
			int[,] grid =
			{
				{1, 0, 0, 0, 0 },
				{1, 1, 0, 0, 1 },
				{0, 0, 0, 1, 1 }
			};
			// 9 broken tiles in a 3 x 5 space
			Repairs.MinRepairs(grid, 5).Should().Be(1);
			Repairs.MinRepairs(grid, 4).Should().Be(2);
			Repairs.MinRepairs(grid, 3).Should().Be(2);
			Repairs.MinRepairs(grid, 2).Should().Be(3);
			Repairs.MinRepairs(grid, 1).Should().Be(4);
		}

		[TestMethod]
		public void TestThickerHGap()
		{
			int[,] grid =
			{
				{1, 0, 0, 0, 0 },
				{1, 1, 0, 0, 1 },
				{1, 0, 0, 0, 1 }
			};
			// 9 broken tiles in a 3 x 4 space
			Repairs.MinRepairs(grid, 5).Should().Be(2);
			Repairs.MinRepairs(grid, 4).Should().Be(2);
			Repairs.MinRepairs(grid, 3).Should().Be(3);
			Repairs.MinRepairs(grid, 2).Should().Be(3);
			Repairs.MinRepairs(grid, 1).Should().Be(4);
		}

		[TestMethod]
		public void TestThickZigZag()
		{
			int[,] grid =
			{
				{1, 0, 0, 0, 1 },
				{1, 0, 0, 0, 1 },
				{1, 1, 0, 0, 0 }
			};
			// 9 broken tiles in a 3 x 4 space
			Repairs.MinRepairs(grid, 5).Should().Be(2);
			Repairs.MinRepairs(grid, 4).Should().Be(2);
			Repairs.MinRepairs(grid, 3).Should().Be(3);
			Repairs.MinRepairs(grid, 2).Should().Be(3);
			Repairs.MinRepairs(grid, 1).Should().Be(4);
		}

		[TestMethod]
		public void TestTileAdjacent()
		{
			Repairs.Tile c1 = new Repairs.Tile(1, 1);
			c1.IsAdjacent(new Repairs.Tile(1, 2)).Should().Be(true);
			c1.IsAdjacent(new Repairs.Tile(1, 0)).Should().Be(true);
			c1.IsAdjacent(new Repairs.Tile(1, 3)).Should().Be(false);
			c1.IsAdjacent(new Repairs.Tile(2, 1)).Should().Be(true);
			c1.IsAdjacent(new Repairs.Tile(0, 1)).Should().Be(true);
			c1.IsAdjacent(new Repairs.Tile(2, 2)).Should().Be(false);
			c1.IsAdjacent(new Repairs.Tile(0, 0)).Should().Be(false);
		}

		[TestMethod]
		public void TestRegionAdjacent()
		{
			Repairs.Region r1 = new Repairs.Region(new Repairs.Tile(1, 1));
			r1.AddTile(new Repairs.Tile(1, 2));
			r1.IsAdjacent(new Repairs.Tile(1, 3)).Should().Be(true);
			r1.IsAdjacent(new Repairs.Tile(1, 0)).Should().Be(true);
			r1.IsAdjacent(new Repairs.Tile(2, 2)).Should().Be(true);
			r1.IsAdjacent(new Repairs.Tile(1, 4)).Should().Be(false);
			r1.IsAdjacent(new Repairs.Tile(3, 2)).Should().Be(false);

			Repairs.Region r2 = new Repairs.Region(new Repairs.Tile(1, 4));
			r2.AddTile(new Repairs.Tile(1, 3));

			r1.IsAdjacent(r2).Should().Be(true);

			Repairs.Region r3 = new Repairs.Region(new Repairs.Tile(1, 4));
			r3.AddTile(new Repairs.Tile(1, 5));

			r1.IsAdjacent(r3).Should().Be(false);
		}

		[TestMethod]
		public void TestGenerateRemovalIndices()
		{
			Repairs.GenerateRemovalIndices(3, 1).Should().BeEquivalentTo(new List<int[]> { new int[] { 0 }, new int[] { 1 }, new int[] { 2 } });
			Repairs.GenerateRemovalIndices(3, 2).Should().BeEquivalentTo(new List<int[]> { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 } });
			Repairs.GenerateRemovalIndices(5, 3).Should().BeEquivalentTo(new List<int[]> { 
				new int[] { 0, 1, 2 },
				new int[] { 0, 1, 3 },
				new int[] { 0, 1, 4 },
				new int[] { 0, 2, 3 },
				new int[] { 0, 2, 4 },
				new int[] { 0, 3, 4 },
				new int[] { 1, 2, 3 },
				new int[] { 1, 2, 4 },
				new int[] { 1, 3, 4 },
				new int[] { 2, 3, 4 },
			});
		}
	}
}
