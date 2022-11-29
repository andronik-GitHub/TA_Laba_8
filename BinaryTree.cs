using System;
using System.Xml.Linq;

class BinaryTree
{
    public Node? Root { get; set; } // корінь

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

    public Node? DeleteEvenValue(Node? Tree) // Видалення всім парних елементів
    {
        if (Tree == null) return Tree;

        if (Tree.Data % 2 == 0)
        {
            if (Tree.LeftNode != null) Tree = Tree.LeftNode;
            else if (Tree.RightNode != null) Tree = Tree.RightNode;
            else Tree = null;
        }

        DeleteEvenValue(Tree?.LeftNode);
        DeleteEvenValue(Tree?.RightNode);

        return Tree;
    }
}