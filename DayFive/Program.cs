namespace DayFive
{
    class Program
    {

        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines("test.txt");

            foreach(string line in input)
            {
                System.Console.WriteLine(line);
            }

        }

    }

}