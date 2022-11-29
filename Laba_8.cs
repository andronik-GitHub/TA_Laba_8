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
                    string temp = "";
                    for (int i = 1; i < value.Length; i++)
                        temp += value[i];

                    binaryTree.AutoAdd(Convert.ToInt32(temp));
                }
                else if (value[0] != "")
                    binaryTree.Add(Convert.ToInt32(value[0]));
            }
        }
        

        if (binaryTree.Root != null)
        {
            Console.WriteLine("Tree:\n\n");
            binaryTree.Print_Tree(0, binaryTree.Root);

            Console.WriteLine("\n\nOбхід в прямому порядку:");
            binaryTree.PreOrder(binaryTree.Root);
            Console.WriteLine("\nOбхід в симетричному порядку:");
            binaryTree.InOrder(binaryTree.Root);
            Console.WriteLine("\nOбхід в зворотньому порядку:");
            binaryTree.PostOrder(binaryTree.Root);

            Console.Write($"\nMax: {binaryTree.FindMax(binaryTree.Root)}");
            Console.Write($"\nMin: {binaryTree.FindMin(binaryTree.Root)}");
        }


        Console.WriteLine("\n\n\n");
        Console.ReadKey();
    }
}