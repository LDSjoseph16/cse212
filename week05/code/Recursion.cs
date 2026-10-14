using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: sum of 1^2 + 2^2 + ... + n^2 using recursion.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: nothing left to add
        if (n <= 0)
            return 0;

        // n squared plus the answer for the smaller problem (n - 1)
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: insert all permutations of length 'size' from 'letters' into results.
    /// 'word' is the permutation built so far.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: the word is long enough, so save it
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each remaining letter next, removing it so it can't be reused
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: count ways to climb 's' stairs taking 1, 2, or 3 steps at a time,
    /// using memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Create the memo dictionary the first time through
        remember ??= new Dictionary<int, decimal>();

        // If we already solved this size, reuse the answer
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion, passing 'remember' along so every call shares it
        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        // Save the answer before returning
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: insert all binary strings that match the wildcard 'pattern' into results.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcard left, so this is a finished binary string
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace the first '*' with '0', then with '1', and recurse on each
        string before = pattern[..index];
        string after = pattern[(index + 1)..];
        WildcardBinary(before + "0" + after, results);
        WildcardBinary(before + "1" + after, results);
    }

    /// <summary>
    /// Problem 5: use recursion to insert all paths that start at (0,0)
    /// and end at the 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Step onto this square
        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            // Found a complete path, so save it
            results.Add(currPath.AsString());
        }
        else
        {
            // Try each direction: left, right, up, down
            if (maze.IsValidMove(currPath, x - 1, y))
                SolveMaze(results, maze, x - 1, y, currPath);
            if (maze.IsValidMove(currPath, x + 1, y))
                SolveMaze(results, maze, x + 1, y, currPath);
            if (maze.IsValidMove(currPath, x, y - 1))
                SolveMaze(results, maze, x, y - 1, currPath);
            if (maze.IsValidMove(currPath, x, y + 1))
                SolveMaze(results, maze, x, y + 1, currPath);
        }

        // Backtrack: step off this square so other paths can use it
        currPath.RemoveAt(currPath.Count - 1);
    }
}