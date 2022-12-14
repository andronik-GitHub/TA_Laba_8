using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class BinaryTree
{
    public Node? Root { get; set; } // корінь
    public int Count { get; set; } = 0;


    public void AutoAdd(int numbers) // додавання в дерево numbers вибадкових значень
    {
        for (int i = 0; i < numbers; i++)
            Add(new Random().Next(1,100));
    }

    public bool Add(int value) // додавання певного елемента в дерево
    {
        Node? before = null;
        Node? after = this.Root;

        while (after != null)
        {
            before = after;
            if (value <= after.Data) // чи є новий вузол у лівому дереві
                after = after.LeftNode;
            else if (value > after.Data) // чи є новий вузол у правому дереві
                after = after.RightNode;
        }

        Node newNode = new Node();
        newNode.Data = value;

        if (this.Root == null) // дерево порожнє
            this.Root = newNode;
        else
        {
            if (value < before?.Data)
                before.LeftNode = newNode;
            else
                before.RightNode = newNode;
        }

        Count++;
        return true;
    }

    public void Print_Tree(int l, Node? Tree) // вивід дерева
    {
        if (Tree != null)
        {
            Print_Tree(l + 2, Tree.RightNode);

            for (int i = 1; i <= l; i++) Console.Write(" ");
            Console.WriteLine(Tree.Data);

            Print_Tree(l + 2, Tree.LeftNode);
        }
    }

    public void PreOrder(Node? Tree) // обхід в прямому порядку
    {
        if (Tree == null) return;

        Console.Write(Tree.Data + " ");
        PreOrder(Tree.LeftNode);
        PreOrder(Tree.RightNode);
    }

    public void InOrder(Node? Tree) // обхід в симетричному порядку
    {
        if (Tree == null) return;

        PreOrder(Tree.LeftNode);
        Console.Write(Tree.Data + " ");
        PreOrder(Tree.RightNode);
    }

    public void PostOrder(Node? Tree) // обхід в зворотньому порядку
    {
        if (Tree == null) return;

        PreOrder(Tree.LeftNode);
        PreOrder(Tree.RightNode);
        Console.Write(Tree.Data + " ");
    }

    public int FindMax(Node Tree) // максимальне значення
    {
        if (Tree == null || Tree?.Data == null) throw new Exception("Tree is null");


        while (Tree.RightNode != null) Tree = Tree.RightNode;

        return Tree.Data;
    }

    public int FindMin(Node Tree) // мінімальне значення
    {
        if (Tree == null || Tree?.Data == null) throw new Exception("Tree is null");


        while (Tree.LeftNode != null) Tree = Tree.LeftNode;

        return Tree.Data;
    }

    public int FindEvenElements(Node? Tree) // пошук парного елемента
    {
        if (Tree == null || Tree?.Data == null) throw new Exception("Tree is null");

        if (Tree.Data % 2 == 0) return Tree.Data;
        FindEvenElements(Tree.LeftNode);
        FindEvenElements(Tree.RightNode);

        return 0;
    }

    public Node? DeleteEvenValue(Node? Tree) // видалення парних елементів
    {
        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(FindEvenElements(Tree));
            Tree = Remove(Tree, FindEvenElements(Tree));
        }

        return Tree;
    }

    private Node? Remove(Node? parent, int key) // видалення елемента за значенням
    {
        if (parent == null) return parent;

        if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
        else if (key > parent.Data) parent.RightNode = Remove(parent.RightNode, key);
        else
        {
            if (parent.LeftNode == null)
                return parent.RightNode;
            else if (parent.RightNode == null)
                return parent.LeftNode;
 
            parent.Data = FindMin(parent.RightNode);

            parent.RightNode = Remove(parent.RightNode, parent.Data);
        }

        Count--;
        return parent;
    }

    public int Counter(Node? Tree, int key, int num = 0) // кільіксть входжень елемента
    {
        if (Tree == null) return 0;

        if (Tree.Data == key) num++;
        Counter(Tree.LeftNode, key, num);
        Counter(Tree.LeftNode, key, num);

        return num;
    }

    public int Sum(Node? Tree, int sum = 0) // сума всіх елеметів
    {
        if (Tree == null) return 0;

        sum += Tree.Data;
        Counter(Tree.LeftNode, sum);
        Counter(Tree.LeftNode, sum);

        return sum;
    }
}