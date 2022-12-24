namespace DaySeven
{
    class Program
    {
        static Node tree = new Node(null, 0, "/");
        static List<int> OptimalDeletes = new List<int>();
        static int neededSpace = 0;

        static int CalculateSize(Node head)
        {
            int total = 0;
            Node currentNode = head;

            if(currentNode.CalculateNodeValue() <= 100000)
            {
                total += currentNode.CalculateNodeValue();
            }

            if(currentNode.GetChildList().Count != 0)
            {
                foreach(Node child in currentNode.GetChildList())
                {
                    total += CalculateSize(child);
                }
            }

            return total;
        }

        static void PrintTree(Node tree)
        {
            Node currentNode = tree;
            
            System.Console.Write("Dir: {0} || Value: {1} || Parent: ", tree.GetDir(), tree.CalculateNodeValue());
            string p = tree.HasParent() ? tree.GetParent().GetDir() : "NULL";
            System.Console.Write(p);
            System.Console.WriteLine();
            System.Console.WriteLine("Children: ");

            if(tree.GetChildList().Count == 0)
            {
                return;
            }
            else
            {
                foreach(Node child in tree.GetChildList())
                {
                    System.Console.WriteLine(child.GetDir());
                }
                    System.Console.WriteLine("=========================");
                foreach(Node child in tree.GetChildList())
                {
                    PrintTree(child);
                }
            }
        }

        static void ParseInput(string[] input)
        {
            Node currentNode = tree;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i][0] == '$') // Find commands
                {
                    if(input[i].Substring(2,2) == "ls")
                    {
                        for(int k = i + 1; k < input.Length; k++)
                        {
                            if(input[k][0] == '$')
                                break;
                            else
                            {
                                if(input[k][0] == 'd')
                                {
                                    currentNode.AddChild(new Node(currentNode, 0, input[k].Substring(4, input[k].Length - 4)));
                                }
                                else
                                {
                                    string currentString = "";
                                    foreach(char num in input[k])
                                    {
                                        if(Char.IsDigit(num))
                                            currentString += num;
                                        else
                                            break;
                                        
                                    }
                                    currentNode.AddValue(Int32.Parse(currentString));
                                }
                            }
                        }
                    }

                    else if(input[i].Substring(2,2) == "cd") //Change directory
                    {
                        if(input[i][5] != '.' && i != 0)
                        {
                            currentNode = currentNode.GetChild(input[i].Substring(5, input[i].Length - 5));
                        }
                        else if(input[i][5] == '.')
                        {
                            currentNode = currentNode.GetParent();
                        }
                    }

                }
            }
        }

        static void FindOptimalDirectories(Node head)
        {
            Node currentNode = head;

            if(currentNode.CalculateNodeValue() >= neededSpace)
            {
                OptimalDeletes.Add(currentNode.CalculateNodeValue());
            }

            if(currentNode.GetChildList().Count != 0)
            {
                foreach(Node child in currentNode.GetChildList())
                {
                    int t = child.CalculateNodeValue();
                    if(t >= neededSpace)
                    {
                        OptimalDeletes.Add(t);
                        if(child.GetChildList().Count != 0)
                        {
                            FindOptimalDirectories(child);
                        }
                    }
                }
            }
        }

        static void CalculateNeededSpace()
        {
            neededSpace = 30000000 - (70000000 - tree.CalculateNodeValue());
        }

        static int CalculateOptimalDirectory()
        {
            CalculateNeededSpace();
            FindOptimalDirectories(tree);

            int total = int.MaxValue;

            foreach(int dir in OptimalDeletes)
            {
                if(dir < total)
                    total = dir;
            }

            return total;
        }

        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines("Input.txt");
            ParseInput(input);
            System.Console.WriteLine(CalculateOptimalDirectory());
            
            //PrintTree(tree);

        }

    }

}