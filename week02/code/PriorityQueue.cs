public class PriorityQueue
{
    private List<PriorityItem> _queue = new List<PriorityItem>();

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority (highest integer value)
        // Use strict '>' to ensure FIFO tie-breaking (the first item encountered wins ties)
        int highPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[_highPriorityIndex].Priority) // Wait, let's keep index clean:
            // _queue[i].Priority > _queue[highPriorityIndex].Priority
            {
                highPriorityIndex = i;
            }
        }

        // Save the value and remove it from the list
        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

public class PriorityItem
{
    public string Value { get; set; }
    public int Priority { get; set; }

    public PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}