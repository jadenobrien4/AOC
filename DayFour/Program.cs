namespace DayFour
{
    class Program
    {
        //test
        static int CalculateSections(string[] input)
        {
            int total = 0;

            for(int i = 0; i < input.Length; i++)
            {
                string first = "", second = "", third = "", fourth = "";
                int iterator = 0;

                for(int k = 0; k < input[i].Length; k++)
                {
                    switch(iterator)
                    {
                        case 0:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                first += input[i][k];
                            else
                                iterator++;
                            break;

                        case 1:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                second += input[i][k];
                            else
                                iterator++;
                            break;

                        case 2:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                third += input[i][k];
                            else
                                iterator++;

                            break;

                        case 3:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                fourth += input[i][k];
                            else
                                iterator++;
                            break;
                    }
                }


                if(Int32.Parse(first) >= Int32.Parse(third) && Int32.Parse(second) <= Int32.Parse(fourth)) // 0 = first 2 = second 4 = third 6 = fourth
                    total++;
                else if(Int32.Parse(third) >= Int32.Parse(first) && Int32.Parse(fourth) <= Int32.Parse(second))
                    total++;
            }


            return total;
        }

        static int CalculateSectionsPart2(string[] input)
        {
            int total = 0;
            
            for(int i = 0; i < input.Length; i++)
            {
                string first = "", second = "", third = "", fourth = "";
                int iterator = 0;

                for(int k = 0; k < input[i].Length; k++)
                {
                    switch(iterator)
                    {
                        case 0:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                first += input[i][k];
                            else
                                iterator++;
                            break;

                        case 1:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                second += input[i][k];
                            else
                                iterator++;
                            break;

                        case 2:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                third += input[i][k];
                            else
                                iterator++;

                            break;

                        case 3:
                            if(input[i][k] != '-' && input[i][k] != ',')
                                fourth += input[i][k];
                            else
                                iterator++;
                            break;
                    }
                }


                if((Int32.Parse(first) >= Int32.Parse(third) && Int32.Parse(first) <= Int32.Parse(fourth)) || (Int32.Parse(second) >= Int32.Parse(third) && Int32.Parse(second) <= Int32.Parse(fourth)))
                        total++;
                else if((Int32.Parse(third) >= Int32.Parse(first) && Int32.Parse(third) <= Int32.Parse(second)) || (Int32.Parse(fourth) >= Int32.Parse(first) && Int32.Parse(fourth) <= Int32.Parse(second)))
                        total++;

            }


            return total;
        }

        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines("input.txt");
            System.Console.WriteLine(CalculateSectionsPart2(input));
        }

    }
}