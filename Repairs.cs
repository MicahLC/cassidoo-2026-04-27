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
						else if (adjacentRegions.Count == 1)
						{
							adjacentRegions[0].AddTile(t);
						}
						else
						{
							adjacentRegions[0].AddTile(t);
							for (int i = 1; i < adjacentRegions.Count; i++)
							{
								adjacentRegions[0].AddRegion(adjacentRegions[i]);
								brokenRegions.Remove(adjacentRegions[i]);
							}
						}
					}
				}
			}

			int runningSum = 0;
			foreach (var region in brokenRegions)
			{
				int regionSize = region.Size;
				if (regionSize > k)
				{
					// let's break it down and add it.
					// need some way to try and remove increasing numbers of tiles and recalculate the subregions of the broken region and see if that gets us to what we want.
					if (k == 0)
					{
						runningSum += regionSize;
					}
					else if (k == 1)
					{
						runningSum += regionSize / 2;
					}
					else
					{
						int maxRepairs = Math.Min(regionSize - k, regionSize / k + 1);
						// generate indices to remove.
						for (int removeCount = 1; removeCount <= maxRepairs; removeCount++)
						{
							List<int[]> allPossibleRemovalIndices = GenerateRemovalIndices(regionSize, removeCount);
							foreach (var indicesToRemove in allPossibleRemovalIndices)
							{
								// TODO: reread this code, it might need more writing done.
								List<Region> splitRegions = region.RepairAndRecalculate(indicesToRemove);
								if (splitRegions.All(r => r.Size <= k))
								{
									runningSum += removeCount;
									break;
								}
							}
						}
					}
				}
			}

			return runningSum;
		}

		public static List<int[]> GenerateRemovalIndices(int regionSize, int removeCount)
		{
			List<int[]> result = new List<int[]>();
			int[] original = new int[removeCount];
			IterateRemaining(result, original, 0, 0, regionSize);
			return result;
		}

		private static void IterateRemaining(List<int[]> list, int[] array, int index, int rangeStart, int rangeEnd)
		{
			if (index == array.Length - 1)
			{
				// we're on the last index, just need to iterate and add
				for (int i = rangeStart; i < rangeEnd; i++)
				{
					array[index] = i;
					int[] copy = new int[array.Length];
					array.CopyTo(copy, 0);
					list.Add(copy);
				}
				return;
			}
			for (int i = rangeStart; i < rangeEnd; ++i)
			{
				array[index] = i;
				IterateRemaining(list, array, index + 1, i + 1, rangeEnd);
			}
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

			public int Size { get { return Tiles.Count; } }

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

			internal List<Region> RepairAndRecalculate(int[] indicesToRemove)
			{
				List<Region> results = new List<Region>();
				List<Tile> tiles = [.. Tiles];
				for (int i = 0; i < indicesToRemove.Length; i++)
				{
					tiles.Remove(Tiles[i]);
				}
				foreach (Tile t in tiles)
				{
					if (results.Count == 0)
					{
						results.Add(new Region(t));
					}
					else
					{
						List<Region> adjacentRegions = results.FindAll(r => r.IsAdjacent(t));
						if (adjacentRegions.Count == 0)
						{
							results.Add(new Region(t));
						}
						else if (adjacentRegions.Count == 1)
						{
							adjacentRegions[0].AddTile(t);
						}
						else
						{
							adjacentRegions[0].AddTile(t);
							for (int i = 1; i < adjacentRegions.Count; i++)
							{
								adjacentRegions[0].AddRegion(adjacentRegions[i]);
								results.Remove(adjacentRegions[i]);
							}
						}
					}
				}
				return results;
			}
		}
	}
}
