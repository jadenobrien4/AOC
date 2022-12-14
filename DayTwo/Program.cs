
namespace DayTwo
{
    class Program
    {
        static int CalculateScorePartTwo(string[] input)
        {
            int score = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if(input[i][0] == 'A' && input[i][2] == 'X')
                {
                    score += 3;
                }
                else if(input[i][0] == 'A' && input[i][2] == 'Y')
                {
                    score += 4;
                }
                else if(input[i][0] == 'A' && input[i][2] == 'Z')
                {
                    score += 8;
                }
                else if(input[i][0] == 'B' && input[i][2] == 'X')
                {
                    score += 1;
                }
                else if(input[i][0] == 'B' && input[i][2] == 'Y')
                {
                    score += 5;
                }
                else if(input[i][0] == 'B' && input[i][2] == 'Z')
                {
                    score += 9;
                }
                else if(input[i][0] == 'C' && input[i][2] == 'X')
                {
                    score += 2;
                }
                else if(input[i][0] == 'C' && input[i][2] == 'Y')
                {
                    score += 6;
                }
                else if(input[i][0] == 'C' && input[i][2] == 'Z')
                {
                    score += 7;
                }
            }

            return score;
        }

        static int CalculateScore(string[] input)
        {
            int score = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if(input[i][0] == 'A' && input[i][2] == 'X')
                {
                    score += 4;
                }
                else if(input[i][0] == 'A' && input[i][2] == 'Y')
                {
                    score += 8;
                }
                else if(input[i][0] == 'A' && input[i][2] == 'Z')
                {
                    score += 3;
                }
                else if(input[i][0] == 'B' && input[i][2] == 'X')
                {
                    score += 1;
                }
                else if(input[i][0] == 'B' && input[i][2] == 'Y')
                {
                    score += 5;
                }
                else if(input[i][0] == 'B' && input[i][2] == 'Z')
                {
                    score += 9;
                }
                else if(input[i][0] == 'C' && input[i][2] == 'X')
                {
                    score += 7;
                }
                else if(input[i][0] == 'C' && input[i][2] == 'Y')
                {
                    score += 2;
                }
                else if(input[i][0] == 'C' && input[i][2] == 'Z')
                {
                    score += 6;
                }
            }

            return score;

        }

        static void Main()
        {
            //int total_score = CalculateScore(System.IO.File.ReadAllLines("test.txt"));
            //Console.WriteLine(total_score);

            int total_score_2 = CalculateScorePartTwo(System.IO.File.ReadAllLines("Input.txt"));
            Console.WriteLine(total_score_2);
        }

    }

}
