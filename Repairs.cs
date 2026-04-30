namespace cassidoo_2026_04_27
{
	internal class Repairs
	{
		public static int MinRepairs(int[,] grid, int k)
		{
			// Algorithm:
			// First, find all broken regions.
			// For each broken region, try filling in ever increasing numbers of tiles randomly until we find a solution.
			// For the entire grid, return the sums of the minimums for every broken region.

			List<Region> brokenRegions = [];
			for (int r = 0; r < grid.GetLength(0); r++)
			{
				for (int c = 0; c < grid.GetLength(1); c++)
				{
					if (grid[r, c] == 0)
					{
						Tile t = new Tile(r, c);
						List<Region> adjacentRegions = brokenRegions.FindAll(region => region.IsAdjacent(t));
						if (adjacentRegions.Count == 0)
						{
							brokenRegions.Add(new Region(t));
						}
						else
						{

						}
					}
				}
			}

			return -1;
		}

		public class Tile(int row, int col)
		{
			public readonly int Row = row;
			public readonly int Col = col;

			public bool IsAdjacent(Tile c)
			{
				int rowDiff = Math.Abs(Row - c.Row);
				int colDiff = Math.Abs(Col - c.Col);
				return (rowDiff == 0 && colDiff == 1) || (rowDiff == 1 && colDiff == 0);
			}
		}

		public class Region
		{
			readonly List<Tile> Tiles = [];

			public Region(Tile c)
			{
				AddTile(c);
			}

			public void AddTile(Tile c)
			{
				Tiles.Add(c);
			}

			public void AddRegion(Region r)
			{
				Tiles.AddRange(r.Tiles);
			}

			public bool IsAdjacent(Tile c)
			{
				return Tiles.Any(t => t.IsAdjacent(c));
			}

			public bool IsAdjacent(Region r)
			{
				return r.Tiles.Any(t => IsAdjacent(t));
			}
		}
	}
}
