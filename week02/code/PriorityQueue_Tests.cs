using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests {
    [TestMethod]
    // Scenario: Create a queue with the following people and priorities: 
    // - Adam (3), 
    // - Beth (1), 
    // - Caleb (7), 
    // - Darlene (5), 
    // - Eve (9)
    // Run the queue 4 times
    // Expected Result: Eve, Caleb, Darlene, Adam. Still in queue: Beth
    // Defect(s) Found: Expected: Caleb, Got: Eve; Reason(s): 
    // - PriorityQueue.Dequeue search index was ending early (was: Count - 1, should be: Count)
    // - PriorityQueue.Dequeue was only returning the item, NOT removing it from the queue 
    public void TestPriorityQueue_PriorityRespected() {
        string[] expectedResult = ["Eve", "Caleb", "Darlene", "Adam"];
        var players = new PriorityQueue();
        players.Enqueue("Adam", 3);
        players.Enqueue("Beth", 1);
        players.Enqueue("Caleb", 7);
        players.Enqueue("Darlene", 5);
        players.Enqueue("Eve", 9);

        int i = 0;
        while (i < expectedResult.Length) {
            if (players.IsEmpty()) Assert.Fail("Queue should not be empty.");
            string playerName = players.Dequeue();
            Assert.AreEqual(expectedResult[i++], playerName);
        }

        Assert.IsFalse(players.IsEmpty(), "The queue should not be empty.");
        Assert.AreEqual("[Beth (Pri:1)]", players.ToString(), "Beth should still be in the queue.");
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and priorities:
    // - Alex (9),
    // - Borimir (7),
    // - Celebrimbor (5),
    // - David (3),
    // - Edmund (5),
    // - Faramir (7),
    // - Galadriel (9),
    // Expected Result: Alex, Galadriel, Borimir, Faramir, Celebrimbor, Edmund, David
    // Defect(s) Found: 
    //      Expected: Alex, Got: Galadriel
    //      Reason: PriorityQueue.Dequeue was checking if priorities were greater than OR EQUAL to the current highest (was: >=, should be: >)
    public void TestPriorityQueue_SamePriorityRespected() {
        string[] expectedResult = ["Alex", "Galadriel", "Borimir", "Faramir", "Celebrimbor", "Edmund", "David"];
        var players = new PriorityQueue();
        players.Enqueue("Alex", 9);
        players.Enqueue("Borimir", 7);
        players.Enqueue("Celebrimbor", 5);
        players.Enqueue("David", 3);
        players.Enqueue("Edmund", 5);
        players.Enqueue("Faramir", 7);
        players.Enqueue("Galadriel", 9);

        int i = 0;
        while (players.Length > 0) {
            if (i >= expectedResult.Length) Assert.Fail($"Queue should be empty at this point. (ran {i} times)");
            string playerName = players.Dequeue();
            Assert.AreEqual(expectedResult[i++], playerName);
        }
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Create a queue with the following people and priorities:
    // - Arica (7),
    // - Benjamin (5),
    // Run the queue once, then add the following people and priorities:
    // - Charlotte (7),
    // - Daniel (5),
    // - Edith (7)
    // Expected Result: Arica, Charlotte, Edith, Benjamin, Daniel
    // Defect(s) Found: null (All issues resolved in prior tests)
    public void TestPriorityQueue_AddPlayerMidwayPriorityRespected() {
        int i = 0;
        string[] expectedResult = ["Arica", "Charlotte", "Edith", "Benjamin", "Daniel"];
        var players = new PriorityQueue();
        players.Enqueue("Arica", 7);
        players.Enqueue("Benjamin", 5);
        Assert.AreEqual(expectedResult[i++], players.Dequeue());
        players.Enqueue("Charlotte", 7);
        players.Enqueue("Daniel", 5);
        players.Enqueue("Edith", 7);

        while (players.Length > 0)
        {
            if (i >= expectedResult.Length) Assert.Fail($"Queue should be empty at this point. (ran {i} times)");
            Assert.AreEqual(expectedResult[i++], players.Dequeue());
        }
    }

    [TestMethod]
    // Scenario: All people in this test have priority 0. 
    // Create a queue with the following people:
    // - Ajalon (0),
    // - Beersheba (0),
    // - Calvary (0),
    // Run the queue twice, then add the following people:
    // - Dothan (0),
    // - Eden (0),
    // Run the queue two more times, then add the following person:
    // - Frank (0)
    // Expected Result: Ajalon, Beersheba, Calvary, Dothan, Eden, Frank
    // Defect(s) Found: null (All issues resolved in prior tests)
    public void TestPriorityQueue_PlayerAddedToBackAndRemovedFromFront() {
        int i=0, j=0, k = 0;
        bool[] action = [true, true, true, false, false, true, true, false, false, true, false, false];
        string[] expectedResult = [
            "Ajalon",
            "Beersheba",
            "Calvary",
            "Dothan",
            "Eden",
            "Frank"
        ];
        string[] expectedStrings = [
            "[]",
            "[Ajalon (Pri:0)]",
            "[Ajalon (Pri:0), Beersheba (Pri:0)]",
            "[Ajalon (Pri:0), Beersheba (Pri:0), Calvary (Pri:0)]",
            "[Beersheba (Pri:0), Calvary (Pri:0)]",
            "[Calvary (Pri:0)]",
            "[Calvary (Pri:0), Dothan (Pri:0)]",
            "[Calvary (Pri:0), Dothan (Pri:0), Eden (Pri:0)]",
            "[Dothan (Pri:0), Eden (Pri:0)]",
            "[Eden (Pri:0)]",
            "[Eden (Pri:0), Frank (Pri:0)]",
            "[Frank (Pri:0)]",
            "[]"
        ];

        var players = new PriorityQueue();

        while (i < 12) {
            Assert.AreEqual(expectedStrings[i], players.ToString());
            
            if (action[i++]) players.Enqueue(expectedResult[j++], 0);
            else Assert.AreEqual(expectedResult[k++], players.Dequeue());
        }

        Assert.IsTrue(players.IsEmpty(), "Queue should be empty at this point.");
    }
}