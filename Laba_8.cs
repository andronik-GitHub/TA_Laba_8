using System;

class Laba_8
{
    static void Main()
    {
        BinaryTree binaryTree = new();

        while (true)
        {
            string[]? value = Console.ReadLine()?.Split(' ');

            if (value != null)
            {
                if (value[0]?.ToLower() == "end")
                    break;
                else if (value[0]?.ToLower() == "rand")
                {
                    binaryTree.AutoAdd(Convert.ToInt32(value[1]));
                    break;
                }
                else if (value[0] != "")
                    binaryTree.Add(Convert.ToInt32(value[0]));
            }
        }
        

        if (binaryTree.Root != null)
        {
            Console.WriteLine("Tree:\n\n");
            binaryTree.Print_Tree(0, binaryTree.Root);
        }


        Console.ReadKey();
    }
}