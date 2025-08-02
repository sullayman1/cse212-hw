using System.Text.RegularExpressions;
public static partial class Recursion
{
    //                                              ‖
    //                                              v
    public static int SumSquaresRecursive(int n) => n <= 0 ? 0 : n * n + SumSquaresRecursive(n - 1);
    //                                              ^
    //                                              ‖

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size) results.Add(word);
        else foreach (char l in letters) PermutationsChoose(results, letters.Remove(letters.IndexOf(l), 1), size, word + l);
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= [];
        return s <= 3 ? s < 3 ? s : 4 : remember.TryGetValue(s, out var m) ? m : remember[s] = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
    }
    /* My obsession with making everything one-line brought about this nonsense:

      public static decimal CountWaysToClimb(int s) => CountWaysToClimb(s, []);
      public static decimal CountWaysToClimb(int s, Dictionary<int, decimal> remember) => s <= 3 ? s < 3 ? s : 4 
      : remember.TryGetValue(s, out var m) ? m : remember[s] = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

    ...I think I have a problem */

    [GeneratedRegex(@"\*")] private static partial Regex r();
    public static void WildcardBinary(string pattern, List<string> results)
    {
        if (!pattern.Contains('*')) results.Add(pattern);
        else foreach (string i in new[] { "0", "1" }) WildcardBinary(r().Replace(pattern, i, 1), results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        currPath ??= [];
        currPath.Add((x, y));
        if (maze.IsEnd(x, y)) results.Add(currPath.AsString());
        else foreach ((int dx, int dy) in new[] { (0, -1), (0, 1), (-1, 0), (1, 0) }) if (maze.IsValidMove(currPath, dx + x, dy + y)) SolveMaze(results, maze, dx + x, dy + y, currPath);
        currPath.Remove((x, y));
    }
}