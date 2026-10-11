public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: ignore duplicates
    public void Insert(int value)
    {
        if (value == Data)
            return;

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2: recursive search
    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
            return Left is not null && Left.Contains(value);

        return Right is not null && Right.Contains(value);
    }

    // Problem 4: 1 + the taller of the two subtrees
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}