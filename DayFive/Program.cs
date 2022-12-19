namespace DayFive
{
    class Program
    {
        static List<List<char>> Crates = null!; //List of crates
        static List<List<int>> Instructions = null!; //List of instructions
        
        static void ReadGraph(string[] input) //Reads in graphic from input and assigns values into arrays representing the "Crates"
        {
            int num_columns = 0;
            int num_rows = 0;
            //Go through each line to get number of columns and rows
            foreach(string line in input)
            {
                if(line.Length > 0 && Char.IsDigit(line[1]))
                {
                    foreach(char index in line)
                    {
                        if(Char.IsDigit(index))
                            num_columns++;
                    }
                    break;
                }
                num_rows++;
            }

            //Create arrays to represent crates
            for(int i = 0; i < num_columns; i++)
            {
                Crates.Add(new List<char>());
            }

            //Assign values to newly created "crates" and add crates to list of crates
            int current_col = 1;
            for(int k = 0; k < num_columns; k++)
            {
                for(int i = 0; i < num_rows; i++)
                {
                    if(input[i][current_col] != ' ')
                    {
                        Crates[k].Add(input[i][current_col]);
                    }
                }
                current_col += 4;
            }
        }

        static void ReadInstuctions(string[] input) // read instructions for which data is moving between crates
        {
            //Find where instuctions start and assign values to string
            string current_string = "";
            int index = 0;
            foreach(string line in input)
            {
                if(line.Length > 0 && line[0] == 'm')
                {
                    List<int> current_instruct = new List<int>();
                    for(int i = 0; i < line.Length; i++)
                    {
                        if(Char.IsDigit(line[i]))
                        {
                            if(i != line.Length - 1 && Char.IsDigit(line[i + 1]))
                            {
                                current_string += line[i];
                                current_string += line[i + 1];
                                current_instruct.Add(Int32.Parse(current_string));
                                current_string = "";

                                i++;
                            }
                            else
                            {
                                current_string += line[i];
                                current_instruct.Add(Int32.Parse(current_string));
                                current_string = "";
                            }
                        }
                    }
                    Instructions.Add(current_instruct);
                    index++;
                }
            }

        }

        static void SortCrates() // Use instructions to move items between crates
        {
            foreach(var instruct in Instructions)
            {
                int amount = instruct[0];
                int from = instruct[1] - 1;
                int to = instruct[2] - 1;

                for(int i = 0; i < amount; i++)
                {
                    Crates[to].Insert(0, Crates[from][0]);
                    Crates[from].RemoveAt(0);
                }
            }
        }

        static void SortCratesPart2() // Use instructions to move items between crates keeping items in order
        {
            foreach(var instruct in Instructions)
            {
                int amount = instruct[0];
                int from = instruct[1] - 1;
                int to = instruct[2] - 1;

                for(int i = amount - 1; i >= 0; i--)
                {

                    Crates[to].Insert(0, Crates[from][i]);
                    Crates[from].RemoveAt(i);

                }
            }
        }
        
        static void PrintList<T>(List<List<T>> list) //Prints 2D List of any type
        {
            for(int i = 0; i < list.Count; i++)
            {
                for(int k = 0; k < list[i].Count; k++)
                {
                    System.Console.WriteLine("Col: " + (i + 1) + " Row: " + k + " :: " + list[i][k]);
                }
                System.Console.WriteLine();
            }
        }

        static void PrintAnswer() //Final Answer (Top item in each crate)
        {
            for(int i = 0; i < Crates.Count; i++)
            {
                for(int k = 0; k < Crates[i].Count; k++)
                {
                    if(k == 0)
                    {
                        Console.Write(Crates[i][k]);
                    }
                }
                
            }
        }
        static void Main()
        {
            Crates = new List<List<char>>();
            Instructions = new List<List<int>>();

            string[] input = System.IO.File.ReadAllLines("Input.txt");

            ReadGraph(input);
            ReadInstuctions(input);

            SortCratesPart2();
            PrintAnswer();
        }

    }

}