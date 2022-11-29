using System;

class BinaryTree
{
    public Node? Root { get; set; }

    public void AutoAdd(int numbers)
    {
        for (int i = 0; i < numbers; i++)
            Add(new Random().Next(1,100));
    }

    public bool Add(int value)
    {
        Node? before = null;
        Node? after = this.Root;

        while (after != null)
        {
            before = after;
            if (value <= after.Data) // Чи є новий вузол у лівому дереві
                after = after.LeftNode;
            else if (value > after.Data) // Чи є новий вузол у правому дереві
                after = after.RightNode;
        }

        Node newNode = new Node();
        newNode.Data = value;

        if (this.Root == null) // Дерево порожнє
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

    public void Print_Tree(int l, Node? Tree)
    {
        if (Tree != null)
        {
            Print_Tree(l + 2, Tree.RightNode);

            for (int i = 1; i <= l; i++) Console.Write(" ");
            Console.WriteLine(Tree.Data);

            Print_Tree(l + 2, Tree.LeftNode);
        }
    }
}