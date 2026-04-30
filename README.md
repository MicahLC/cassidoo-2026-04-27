# Introduction

This project is a solution to the interview question posed in the ["rendezvous with cassidoo" newsletter sent on 2026-04-27](https://buttondown.com/cassidoo/archive/u1f57a-there-is-power-in-being-robbed-still/).

# Question

You are given a 2D grid where `1` represents an intact tile and `0` represents a broken tile. A "broken region" is a group of connected `0`s (connected horizontally or vertically). Find the minimum number of tiles you need to repair to ensure no broken region has an area larger than `k`.

## Examples

```
const grid = [
  [1, 0, 0, 1],
  [1, 0, 0, 1],
  [1, 1, 0, 1],
  [0, 1, 1, 1],
];
const k = 2;

let newGrid = [
  [1, 0, 0, 1],
  [1, 0, 0, 1],
  [1, 1, 0, 1],
  [0, 0, 1, 1],
];
let newK = 1;

minRepairs(grid, k)
> 2

minRepairs(newGrid, newK)
> 3
```

# Solution

I went with the brute force approach. First step is to find all the distinct broken regions. Then for each region, if it's not already the correct size, iterate through all possible tile repair scenarios until we find one that works. I did this by taking my list of broken tiles representing a region and generating a set of all indices of tiles we could remove from that list, without duplication (no need to generate both `[0, 1]` and `[1, 0]`). Then remove those tiles from the region, regroup the tiles to see what new regions we have, and count the size of the new regions. If they're all small enough, then we've found a solution and we're done. If not, keep increasing the number of tiles we remove until we find a solution.

## Future optimization

One of the tests with a 6x6 broken region runs for 15 seconds. This code is not optimal! If I had to optimize it, I would look at using a graph to represent the tiles, which would make the regroup and recalculate step much faster. There might also be an algorithm based on some graph theory that would let you find a solution much faster, but I wasn't sure.