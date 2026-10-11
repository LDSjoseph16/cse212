[TestClass]
public class PriorityQueue_Tests
{
    // Test Result Summary: PASSED. 
    // Requirement 1: Enqueue adds items to the back of the queue correctly.
    [TestMethod]
    public void TestPriorityQueue_Enqueue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        Assert.AreEqual("[A (Pri:1), B (Pri:2)]", pq.ToString());
    }

    // Test Result Summary: PASSED.
    // Requirement 2: Dequeue removes the item with the highest priority.
    [TestMethod]
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);
        
        string result = pq.Dequeue();
        Assert.AreEqual("High", result);
    }

    // Test Result Summary: PASSED.
    // Requirement 3: FIFO tie-breaking: if priorities match, the item closest to the front is removed first.
    [TestMethod]
    public void TestPriorityQueue_TieBreaker()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("FirstInLine", 5);
        pq.Enqueue("SecondInLine", 5);
        pq.Enqueue("LowPriority", 1);

        string result1 = pq.Dequeue();
        string result2 = pq.Dequeue();

        Assert.AreEqual("FirstInLine", result1);
        Assert.AreEqual("SecondInLine", result2);
    }

    // Test Result Summary: PASSED.
    // Requirement 4: Empty queue throws InvalidOperationException with message "The queue is empty."
    [TestMethod]
    public void TestPriorityQueue_EmptyException()
    {
        var pq = new PriorityQueue();
        
        try
        {
            pq.Dequeue();
            Assert.Fail("Expected an InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}