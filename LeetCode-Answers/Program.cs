Console.WriteLine("LeetCode Answers");
Console.WriteLine("----------------");

// MERGE K SORTED LISTS

// Create sample linked lists
// List 1: 1 -> 4 -> 5
ListNode list1 = new ListNode(1, new ListNode(4, new ListNode(5)));

// List 2: 1 -> 3 -> 4
ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

// List 3: 2 -> 6
ListNode list3 = new ListNode(2, new ListNode(6));

// Merge all lists
ListNode merged = MergeKLists(new ListNode[] { list1, list2, list3 });

// Print the merged result
Console.WriteLine("\nMerged List: ");
while (merged != null) {
    Console.Write(merged.val);
    if (merged.next != null) Console.Write(" -> ");
    merged = merged.next;
}
Console.WriteLine();
 
 static ListNode MergeKLists(ListNode[] lists) {
        
        if (lists == null || lists.Length == 0) return null;

        // Min-Priority Queue: Stores (Node, Value)
        // The second parameter 'int' defines the priority (ascending by default)
        var priorityQueue = new PriorityQueue<ListNode, int>();

        // 1. Add the head of each non-empty list to the heap
        foreach (var head in lists) {
            if (head != null) {
                priorityQueue.Enqueue(head, head.val);
            }
        }

        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        // 2. Extract the minimum and move to the next node in that specific list
        while (priorityQueue.Count > 0) {
            ListNode smallestNode = priorityQueue.Dequeue();
            current.next = smallestNode;
            current = current.next;

            if (smallestNode.next != null) {
                priorityQueue.Enqueue(smallestNode.next, smallestNode.next.val);
            }
        }

        return dummy.next;
    }

public class ListNode {
     public int val;      // The data stored in the node
    public ListNode next;  // Reference to the next node in the list

    public ListNode(int value = 0, ListNode next = null)
    {
        this.val = value;
        this.next = next;
    }
}