public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value == Data)
        {
            // Do not insert duplicates
            return;
        }
        else if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data)
            return Left != null && Left.Contains(value);
        else // value > Data
            return Right != null && Right.Contains(value);
    }

    // Problem 4: GetHeight
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}