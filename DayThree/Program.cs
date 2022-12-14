namespace DayThree
{

    class Program
    {

        static int CalculatePriority(string[] input)
        {
            //Split the input into two separate arrays
            int total = 0;


            for(int k = 0; k < input.Length; k++)
            {
                List<char> first_half = new List<char>();
                List<char> second_half = new List<char>();

                for(int i = 0; i < input[k].Length / 2; i++)
                {
                    first_half.Add(input[k][i]);
                }
                for(int j = input[k].Length / 2; j < input[k].Length; j++)
                {
                    second_half.Add(input[k][j]);
                }
                
                
                //Check if there are any duplicate letters and add priority number to total
                List<char> checked_letters = new List<char>();

                foreach(char letter in first_half)
                {
                    if(second_half.Contains(letter) && !checked_letters.Contains(letter))
                    {
                        checked_letters.Add(letter);
                        if(letter >= 97 && letter <= 172)
                            total += letter - 96;
                        else 
                            total += letter -38;
                    }
                }


            }

            return total;
        }

        static int CalculatePriorityPart2(string[] input)
        {
            int total = 0;
            List<string> inputList = new List<string>();

            foreach(string line in input)
            {
                inputList.Add(line);
            }
            
            for(int i = 0; i < inputList.Count; i += 3)
            {
                List<char> checked_letters = new List<char>();
                for(int k = 0; k < inputList[i].Length; k++)
                {
                    char letter = inputList[i][k];
                    if(!checked_letters.Contains(letter) && inputList[i + 1].Contains(letter) && inputList[i + 2].Contains(letter))
                    {
                        checked_letters.Add(letter);
                        if(letter >= 97 && letter <= 172)
                            total += letter - 96;
                        else 
                            total += letter - 38;
                    }
                }
            }


           

            return total;
        }

        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines("input.txt");
            int total = CalculatePriorityPart2(input);

            Console.WriteLine(total);

        }

    }

}