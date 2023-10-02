// See https://aka.ms/new-console-template for more information
using Apps;
using DataStructures.Graphs.AdjacencySets;
using DataStructures.Graphs.MinimumSpanningTree;
using DataStructures.Graphs.Search;
using DataStructures.Heaps;
using DataStructures.LinkedList.DoublyLinkedLists;
using DataStructures.LinkedList.SinglyLinkedLists;
using DataStructures.Queues;
using DataStructures.Sets;
using DataStructures.Shared;
using DataStructures.SortingAlgorithms;
using DataStructures.Tree.BinaryTrees;
using DataStructures.Tree.BSTs;
using CustomTypes;

System.Console.WriteLine();
var students = new Student[]
{
     new Student(10, "Ahmet", 3.40),
     new Student(15, "Mehmet", 2.45),
     new Student(85, "Burcu", 1.30),
     new Student(65, "Mete", 2.64),
     new Student(75, "Halis", 2.49),
     new Student(90, "Mevlüt", 3.10),
     new Student(12, "Elvan", 1.45),
     new Student(14, "Bahar", 2.80),
     new Student(18, "İlknur", 3.90),
};

foreach (var student in students)
{
     System.Console.WriteLine(student);   
}
System.Console.WriteLine("\n-------------\n");

var newStudents = new DataStructures.Array.Array<Student>(students);

newStudents.Add(new Student(77, "Hilal", 3.78));

foreach (var student in newStudents)
{
     System.Console.WriteLine(student);   
}

System.Console.WriteLine("\nSinglyLinkedList<Student>");
var linkedList = new SinglyLinkedList<Student>(newStudents);
linkedList.AddBefore(linkedList.Head, new Student(67, "Yiğit", 3.18));
linkedList.AddAfter(linkedList.Head, new Student(67, "Duru", 4.00));

foreach (var student in linkedList)
{
     System.Console.WriteLine(student);   
}
System.Console.WriteLine("\nBST<Student>");
var bst = new BST<Student>(linkedList);
foreach (var student in bst)
{
     System.Console.WriteLine(student);   
}
System.Console.WriteLine("\nMinHeap<Student>");
var minHeap = new MinHeap<Student>(bst);
foreach (var student in minHeap)
{
     System.Console.WriteLine(student);   
}
System.Console.WriteLine("\nMaxHeap<Student>");
var maxHeap = new BinaryHeap<Student>(SortDirection.Descending, linkedList);
foreach (var student in maxHeap)
{
     System.Console.WriteLine(maxHeap.DeleteMinMax());   
}
System.Console.WriteLine("\nBubbleSort.Sort<Student>(students)");
BubbleSort.Sort<Student>(students);
foreach (var item in students)
{
    System.Console.WriteLine(item);
}
System.Console.WriteLine("\nInsertionSort.Sort<Student>(students)");
BubbleSort.Sort<Student>(students);
foreach (var item in students)
{
    System.Console.WriteLine(item);
}


System.Console.ReadKey();



static SinglyLinkedList<int> Reverse(SinglyLinkedList<int> node)
{
    SinglyLinkedListNode<int> prev = null;
    SinglyLinkedList<int> ans = new SinglyLinkedList<int>();
    while (node.Head != null)
    {
        var next = node.Head.Next;
        node.Head.Next = prev;
        prev = node.Head;
        node.Head = next;
        ans.AddFirst(prev.Value);
    }
    return ans;
}

static void LinkedListNodeTesting01()
{
    var linkedList = new SinglyLinkedList<int>();

    linkedList.AddFirst(1);
    linkedList.AddFirst(2);
    linkedList.AddFirst(3);
    // 3 2 1

    linkedList.AddLast(4);
    linkedList.AddLast(5);
    // 3 2 1 4 5

    linkedList.AddAfter(linkedList.Head.Next, 32);
    // 3 2 -> 32 1 4 5

    linkedList.AddBefore(linkedList.Head.Next.Next.Next.Next, 14);
    // 3 2 32 1 14 <- 4 5

    var newNode1 = new SinglyLinkedListNode<int>(28);
    linkedList.AddAfter(linkedList.Head.Next, newNode1);
    // 3 2 -> 28 32 1 14 4 5


    var newNode2 = new SinglyLinkedListNode<int>(41);
    linkedList.AddBefore(linkedList.Head.Next.Next, newNode2);
    // 3 2 41 <- 28  32 1 14 4 5

    foreach (var item in linkedList)
    {
        System.Console.Write($"{item,-4}");
    }
}

static void LinkedListNodeCollectionTesting02()
{
    var list = new List<char>() { 'a', 'b', 'c' };
    var linkedList = new SinglyLinkedList<char>();
    linkedList.AddFirstRange(list);
    foreach (var item in linkedList)
    {
        System.Console.WriteLine(item);
    }
}

static void LinkedListNodeLinqTesting03()
{
    // Language Integrated Query - LINQ
    var rnd = new Random();
    var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
    var linkedList = new SinglyLinkedList<int>(initial);

    var q = from item in linkedList
            where item % 2 == 1
            select item;
    foreach (var item in q)
    {
        System.Console.Write($"{item,-3}");
    }

    Console.WriteLine();

    linkedList.Where(x => x > 5).ToList().ForEach(x => System.Console.Write($"{x,-3}"));
}

static void LinkedListNodeRemoveFirstAndLastTesting()
{
    var rnd = new Random();
    var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();
    var linkedList = new SinglyLinkedList<int>(initial);
    linkedList.ToList().ForEach(x => System.Console.Write(x + " "));
    System.Console.WriteLine();

    System.Console.WriteLine($"{linkedList.RemoveFirst()} has been first removed");
    System.Console.WriteLine($"{linkedList.RemoveFirst()} has been first removed");
    System.Console.WriteLine();
    System.Console.WriteLine($"{linkedList.RemoveLast()} has been last removed");
    System.Console.WriteLine($"{linkedList.RemoveLast()} has been last removed");
    System.Console.WriteLine();
    linkedList.ToList().ForEach(x => System.Console.Write(x + " "));
}

static void LinkedListNodeRemoveTesting()
{
    var linkedList = new SinglyLinkedList<int>(new int[] { 23, 44, 32, 55 });
    linkedList.Remove(32);
    linkedList.Remove(55);
    linkedList.Remove(23);
    // linkedList.Remove(13);
    linkedList.Remove(44);
    linkedList.ToList().ForEach(x => System.Console.Write(x + " "));
}

static void DoublyLinkedListTesting()
{
    var list = new DoublyLinkedList<int>();
    list.AddFirst(12);
    list.AddFirst(23);
    // 23 12

    list.AddLast(44);
    list.AddLast(55);
    // 23 12 44 55

    list.AddAfter(list.Head.Next, 13);
    // 23 12 -> 13 44 55

    list.AddBefore(list.Head.Next.Next.Next.Next, 15);
    //  23  12 13 44 15 <- 55
    foreach (var item in list)
    {
        System.Console.Write($"{item,-4}");
    }
}

static void DoublyLinkedListRemoveFirstAndLastTesting()
{
    var list = new DoublyLinkedList<char>(new List<char> { 'a', 'b', 'c', 'd', 'e' });

    foreach (var item in list)
    {
        System.Console.Write($"{item,-3}");
    }
    System.Console.WriteLine();

    System.Console.WriteLine($"{list.RemoveFirst()} has been from list. => First");
    System.Console.WriteLine($"{list.RemoveLast()} has been from list. => Last");

    System.Console.WriteLine();

    foreach (var item in list)
    {
        System.Console.Write($"{item,-3}");
    }
}

static void DoublyLinkedListTesting2()
{
    var list = new DoublyLinkedList<char>(new List<char> { 'a', 'b', 'c', 'd', 'e' });

    foreach (var item in list)
    {
        System.Console.Write($"{item,-3}");
    }
    System.Console.WriteLine();

    list.Remove('c');

    System.Console.WriteLine();

    foreach (var item in list)
    {
        System.Console.Write($"{item,-3}");
    }
}

static void StackTesting1()
{
    var charset = new char[] { 'a', 'b', 'c', 'd', 'e' };
    var stack1 = new DataStructures.Stacks.Stack<char>();
    var stack2 = new DataStructures.Stacks.Stack<char>(DataStructures.Stacks.StackType.LinkedList);

    foreach (var item in charset)
    {
        System.Console.Write($"{item,-3}");
        stack1.Push(item);
        stack2.Push(item);
    }
    System.Console.WriteLine();

    System.Console.WriteLine("\nPeek");
    System.Console.WriteLine($"Stack 1 : {stack1.Peek()}");
    System.Console.WriteLine($"Stack 2 : {stack2.Peek()}");

    System.Console.WriteLine("\nCount");
    System.Console.WriteLine($"Stack 1 : {stack1.Count}");
    System.Console.WriteLine($"Stack 2 : {stack2.Count}");

    System.Console.WriteLine("\nPop");
    System.Console.WriteLine($"Stack 1 : {stack1.Pop()} has been removed");
    System.Console.WriteLine($"Stack 2 : {stack2.Pop()} has been removed");
}

static void PostFixExampleTesting()
{
    System.Console.WriteLine(PostFixExample.Run("231*+9-"));
}

static void QueueTesting()
{
    var nums = new int[] { 10, 20, 30 };
    var q1 = new DataStructures.Queues.Queue<int>();
    var q2 = new DataStructures.Queues.Queue<int>(QueueType.LinkedList);
    foreach (var item in nums)
    {
        System.Console.Write($"{item,-3}");
        q1.Enqueue(item);
        q2.Enqueue(item);
    }

    System.Console.WriteLine("\nCount");
    System.Console.WriteLine($"Queue 1 : {q1.Count}");
    System.Console.WriteLine($"Queue 2 : {q2.Count}");

    System.Console.WriteLine("\nDequeue");
    System.Console.WriteLine($"{q1.Dequeue()} has been removed from Queue 1");
    System.Console.WriteLine($"{q2.Dequeue()} has been removed from Queue 2");


    System.Console.WriteLine("\nPeek");
    System.Console.WriteLine($"Queue 1 : {q1.Peek()}");
    System.Console.WriteLine($"Queue 2 : {q2.Peek()}");
}

static void BinaryTreeRecursiveTraversalTesting(BST<int> bstList, BinaryTree<int> bt)
{
    bt.InOrder(bstList.Root)
    .ForEach(x => System.Console.Write(x + " "));
    bt.ListClear();

    System.Console.WriteLine();

    bt.PreOrder(bstList.Root)
    .ForEach(x => System.Console.Write(x + " "));

    bt.ListClear();
    System.Console.WriteLine();

    bt.PostOrder(bstList.Root)
    .ForEach(x => System.Console.Write(x + " "));
}

static void BinaryTreeRemoveTesting()
{
    var bstList = new BST<int>(new int[] { 60, 40, 70, 20, 45, 65, 85 });
    var bt = new BinaryTree<int>();

    bt.InOrder(bstList.Root)
    .ForEach(node => System.Console.Write($"{node,-3}"));



    bstList.Remove(bstList.Root, 20);
    bstList.Remove(bstList.Root, 40);
    bstList.Remove(bstList.Root, 60);


    bt.ListClear();
    System.Console.WriteLine();

    bt.InOrder(bstList.Root)
       .ForEach(node => System.Console.Write($"{node,-3}"));
}

static void MaxDepthTesting()
{
    var bstList = new BST<byte>(new byte[] { 60, 40, 70, 20, 45, 65, 85, 90, 19 });

    var bt = new BinaryTree<byte>();
    bt.InOrder(bstList.Root)
    .ForEach(x => System.Console.Write($"{x,-3}"));

    System.Console.WriteLine("\n");

    System.Console.WriteLine($"Min          : {bstList.FindMin(bstList.Root)}");
    System.Console.WriteLine($"Max          : {bstList.FindMax(bstList.Root)}");
    System.Console.WriteLine($"MaxDepth     : {BinaryTree<byte>.MaxDepth(bstList.Root)}");
}

static void DeepestNodeTesting()
{
    var bt = new BinaryTree<char>();
    bt.Root = new Node<char>('F');
    bt.Root.Left = new Node<char>('A');
    bt.Root.Left.Left = new Node<char>('D');
    bt.Root.Right = new Node<char>('T');

    bt.LevelOrderNonRecursiveTraversal(bt.Root)
    .ForEach(x => System.Console.Write($"{x,-3} "));

    System.Console.WriteLine("\n");

    System.Console.WriteLine($"Deepest Node     : {bt.DeepestNode(bt.Root)}");
    System.Console.WriteLine($"Deepest Node     : {bt.DeepestNode()}");
    System.Console.WriteLine($"MaxDepth         : {BinaryTree<char>.MaxDepth(bt.Root)}");
}

static void NumberOfLeafsAndNumberOfLeafsLinqTesting()
{
    var bst = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });

    // bst.Remove(bst.Root, 22);

    System.Console.WriteLine($"Number of leafs           : {BinaryTree<int>.NumberOfLeafs(bst.Root)}");
    System.Console.WriteLine($"Number of leafs linq      : {BinaryTree<int>.NumberOfLeafsLinq(bst.Root)}");
}

static void NumberOfFullNodesAndHalfNodesTesting()
{
    var bst = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });

    bst.Remove(bst.Root, 3);
    bst.Remove(bst.Root, 99);

    System.Console.WriteLine($"Number of leafs               : {BinaryTree<int>.NumberOfLeafs(bst.Root)}");

    System.Console.WriteLine();

    System.Console.WriteLine($"Number of full nodes          : {BinaryTree<int>.NumberOfFullNodes(bst.Root)}");
    System.Console.WriteLine($"Number of full nodes linq     : {BinaryTree<int>.NumberOfFullNodesLinq(bst.Root)}");

    System.Console.WriteLine();

    System.Console.WriteLine($"Number of half nodes          : {BinaryTree<int>.NumberOfHalfNodes(bst.Root)}");
    System.Console.WriteLine($"Number of half nodes linq     : {BinaryTree<int>.NumberOfHalfNodesLinq(bst.Root)}");
}

static void PrintsPathTesting()
{
    var bst = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
    var bt = new BinaryTree<int>();
    bst.Remove(bst.Root, 22);
    bst.Add(100);
    bst.Add(120);
    bt.PrintPaths(bst.Root);
}

static void MinHeapTesting()
{
    var heap = new DataStructures
    .Heaps
    .MinHeap<int>(new int[] { 4, 1, 10, 8, 7, 5, 9, 3, 2 });

    System.Console.WriteLine(heap.DeleteMinMax() + " has been removed");
    foreach (var item in heap)
    {
        System.Console.Write($"{item,-3}");
    }
}

static void MaxHeapTesting()
{
    var heap = new DataStructures
        .Heaps
        .MaxHeap<int>(new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

    //  System.Console.WriteLine(heap.DeleteMinMax() + " has been removed");
    foreach (var item in heap)
    {
        System.Console.Write($"{item,-3}");
    }
}

static void HeapTesting2()
{
    var heap = new DataStructures
            .Heaps
            .BinaryHeap<int>(SortDirection.Ascending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

    //  System.Console.WriteLine(heap.DeleteMinMax() + " has been removed");
    foreach (var item in heap)
    {
        System.Console.Write($"{item,-3}");
    }
}

static void DisJointSetTesting()
{
    var disJointSet = new DisJointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });
    disJointSet.Union(5, 6);
    disJointSet.Union(1, 2);
    disJointSet.Union(0, 2);
    for (int i = 0; i < 7; i++)
    {
        System.Console.WriteLine($"Find({i}) = {disJointSet.FindSet(i)}");
    }
}

static void GraphTesting1()
{
    var graph = new Graph<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' });
    graph.AddEdge('A', 'B');
    graph.AddEdge('A', 'D');
    graph.AddEdge('C', 'D');
    graph.AddEdge('C', 'E');
    graph.AddEdge('D', 'E');
    graph.AddEdge('E', 'F');
    graph.AddEdge('F', 'G');

    System.Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes." : "No!");
    System.Console.WriteLine("Is there an edge between B and A ? {0}", graph.HasEdge('B', 'A') ? "Yes." : "No!");


    System.Console.WriteLine("Is there an edge between B and D ? {0}", graph.HasEdge('B', 'D') ? "Yes." : "No!");
    System.Console.WriteLine("Is there an edge between D and B ? {0}", graph.HasEdge('D', 'B') ? "Yes." : "No!");

    foreach (var key in graph)
    {
        System.Console.Write($"{key,-3} => ");
        foreach (var vertex in graph.GetVertex(key).Edges)
        {
            System.Console.Write(" {0}", vertex);
        }

        System.Console.WriteLine();

    }
    System.Console.WriteLine();
    System.Console.WriteLine($"Number of vertex in the graph : {graph.Count}");
}

static void WeightedGraphTesting1()
{
    var graph = new WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });
    graph.AddEdge('A', 'B', 1.2);
    graph.AddEdge('A', 'D', 2.3);
    graph.AddEdge('D', 'C', 5.5);

    System.Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes." : "No!");
    System.Console.WriteLine("Is there an edge between B and A ? {0}", graph.HasEdge('B', 'A') ? "Yes." : "No!");


    System.Console.WriteLine("Is there an edge between B and D ? {0}", graph.HasEdge('B', 'D') ? "Yes." : "No!");
    System.Console.WriteLine("Is there an edge between D and B ? {0}", graph.HasEdge('D', 'B') ? "Yes." : "No!");

    foreach (char vertex in graph)
    {
        System.Console.WriteLine($"{vertex,-3} => ");
        foreach (var key in graph.GetVertex(vertex))
        {
            var node = graph.GetVertex(key);
            System.Console.WriteLine($"   {vertex} --- " +
            $"{node.GetEdge(graph.GetVertex(vertex)).Weight<double>()} --- " +
            $"{key}");
        }

        System.Console.WriteLine();
    }
    System.Console.WriteLine();
    System.Console.WriteLine($"Number of vertex in the graph : {graph.Count}");
}

static void DiGraphTesting()
{
    var graph = new DiGraph<char>(new char[] { 'A', 'B', 'C', 'D', 'E' });
    graph.AddEdge('B', 'A');
    graph.AddEdge('A', 'D');
    graph.AddEdge('D', 'E');
    graph.AddEdge('C', 'D');
    graph.AddEdge('C', 'E');
    graph.AddEdge('C', 'A');
    graph.AddEdge('C', 'B');

    System.Console.WriteLine("Is there an edge between A and B? {0}", graph.HasEdge('A', 'B') ? "Yes." : "No!");
    System.Console.WriteLine("Is there an edge between B and A? {0}", graph.HasEdge('B', 'A') ? "Yes." : "No!");

    graph.RemoveVertex('C');

    foreach (var key in graph)
    {
        System.Console.WriteLine($"{key,-3} ->");
        foreach (var item in graph.GetVertex(key))
        {
            System.Console.WriteLine($"   {item}");
        }
    }
    System.Console.WriteLine($"Number of  vertex in graph : {graph.Count}");
}

static void WeightedDiGraphTesting()
{
    var graph = new WeightedDiGraph<char, int>(new char[] { 'A', 'B', 'C', 'D', 'E' });
    graph.AddEdge('A', 'C', 12);
    graph.AddEdge('A', 'D', 60);

    graph.AddEdge('B', 'A', 10);

    graph.AddEdge('C', 'B', 20);
    graph.AddEdge('C', 'D', 32);

    graph.AddEdge('E', 'A', 7);

    System.Console.WriteLine("Is an edge between A and B? {0}", graph.HasEdge('A', 'B') ? "Yes." : "No!");
    System.Console.WriteLine("Is an edge between A and B? {0}", graph.HasEdge('B', 'A') ? "Yes." : "No!");
    foreach (var vertexKey in graph)
    {
        System.Console.WriteLine(vertexKey + "  ⤵️");
        foreach (char key in graph.GetVertex(vertexKey))
        {
            var nodeU = graph.GetVertex(vertexKey);
            var nodeV = graph.GetVertex(key);
            var w = nodeU.GetEdge(nodeV).Weight<int>();
            //System.Console.WriteLine($"   {nodeU.Key} -- ({w}) -- {nodeV.Key}");
            System.Console.WriteLine($"   {vertexKey} -- ({w}) -- {key}");
        }
    }

    System.Console.WriteLine($"Number of vertex in this graph : {graph.Count}");
}

static void DfsTreeTesting()
{
    var graph = new Graph<int>(new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 11 });
    graph.AddEdge(0, 1);
    graph.AddEdge(1, 4);
    graph.AddEdge(0, 4);
    graph.AddEdge(0, 2);

    graph.AddEdge(2, 5);
    graph.AddEdge(2, 10);
    graph.AddEdge(10, 11);
    graph.AddEdge(11, 9);
    graph.AddEdge(2, 9);



    graph.AddEdge(5, 7);
    graph.AddEdge(7, 8);
    graph.AddEdge(5, 8);
    graph.AddEdge(5, 6);

    var algoritm = new DepthFirst<int>();
    System.Console.WriteLine("{0}", algoritm.Find(graph, 5) ? "Yes." : "No!");

    foreach (var item in algoritm.DfsTree)
    {
        System.Console.Write($"{item,-3}");
    }
}

static void BfsTreeTesting()
{
    var graph = new Graph<int>(new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 11 });
    graph.AddEdge(0, 1);
    graph.AddEdge(1, 4);
    graph.AddEdge(0, 4);
    graph.AddEdge(0, 2);

    graph.AddEdge(2, 5);
    graph.AddEdge(2, 10);
    graph.AddEdge(10, 11);
    graph.AddEdge(11, 9);
    graph.AddEdge(2, 9);



    graph.AddEdge(5, 7);
    graph.AddEdge(7, 8);
    graph.AddEdge(5, 8);
    graph.AddEdge(5, 6);

    var algoritm = new BreadthFirst<int>();
    System.Console.WriteLine();
    System.Console.WriteLine(algoritm.Find(graph, 40) ? "Yes." : "No!");
    System.Console.WriteLine();
    foreach (var item in algoritm.BfsTree)
    {
        System.Console.Write($"{item,-3}");
    }
}

static void PrimsAlgorithmTesting()
{
    // Minimum Spanning Tree
    var graph = new WeightedGraph<int, int>();
    for (int i = 0; i < 12; i++)
        graph.AddVertex(i);
    graph.AddEdge(0, 1, 4);
    graph.AddEdge(0, 7, 8);
    graph.AddEdge(1, 7, 11);

    graph.AddEdge(1, 2, 8);
    graph.AddEdge(7, 8, 7);
    graph.AddEdge(7, 6, 1);


    graph.AddEdge(6, 8, 6);
    graph.AddEdge(6, 5, 2);
    graph.AddEdge(2, 8, 2);

    graph.AddEdge(2, 3, 7);
    graph.AddEdge(2, 5, 4);


    graph.AddEdge(3, 4, 9);
    graph.AddEdge(3, 5, 14);
    graph.AddEdge(5, 4, 10);

    var algoritm = new Prims<int, int>();
    algoritm.FindMinimumSpanningTree(graph)
    .ForEach(edge => Console.WriteLine(edge));
}

static void KruskalsAlgoritmTesting()
{
     // Minimum Spanning Tree
    var graph = new WeightedGraph<int, int>();
    for (int i = 0; i < 12; i++)
        graph.AddVertex(i);


    graph.AddEdge(0, 1, 4);
    graph.AddEdge(0, 7, 8);
    graph.AddEdge(1, 7, 11);

    graph.AddEdge(1, 2, 8);
    graph.AddEdge(7, 8, 7);
    graph.AddEdge(7, 6, 1);


    graph.AddEdge(6, 8, 6);
    graph.AddEdge(2, 8, 2);
    graph.AddEdge(2, 3, 7);

    graph.AddEdge(2, 5, 4);
    graph.AddEdge(6, 5, 2);


    graph.AddEdge(3, 5, 14);
    graph.AddEdge(3, 4, 9);
    graph.AddEdge(5, 4, 10);

    var algoritm = new Kruskals<int, int>();
    algoritm.FindMinimumSpanningTree(graph)
    .ForEach(edge => Console.WriteLine(edge));
}