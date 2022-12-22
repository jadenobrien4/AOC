namespace DaySix 
{
    class Program
    {

        static int CalculateRepeats(string input)
        {
            int answer = 0;

            for(int i = 0; i < input.Length - 3; i++)
            {
                string currentString = input.Substring(i , 4);
                if(currentString.Distinct().Count() == 4)
                {
                    answer = i + 4;
                    break;
                }
            }
            return answer;
        }

        static int CalculateRepeatsPart2(string input)
        {
            int answer = 0;

            for(int i = 0; i < input.Length - 13; i++)
            {
                string currentString = input.Substring(i , 14);
                if(currentString.Distinct().Count() == 14)
                {
                    answer = i + 14;
                    break;
                }
            }
            return answer;
        }

        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines("Input.txt");
            System.Console.WriteLine(CalculateRepeatsPart2(input[0]));
           
        }
    }


}