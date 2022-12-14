// See https://aka.ms/new-console-template for more information

namespace DayOne
{
    class Program
    {
        static int Calc_Largest_Cal(string[] l)
        {
            int total = 0;

            List<int> elf_total = new List<int>();

            for(int i = 0; i < l.Length; i++)
            {
                if (l[i] != "")
                {
                    total += Int32.Parse(l[i]);
                }
                else
                {
                    elf_total.Add(total);
                    total = 0;
                }
            }

            if (total != 0)
                elf_total.Add(total);

            int first = 0;
            int second = 0;
            int third = 0;

            for(int j = 0; j < elf_total.Count; j++)
            {
                if(elf_total[j] >= first)
                {
                    third = second;
                    second = first;
                    first = elf_total[j];
                }
                else if(elf_total[j] >= second)
                {
                    third = second;
                    second = elf_total[j];
                }
                else if(elf_total[j] >= third)
                {
                    third = elf_total[j];
                }
            }

            return first + second + third;
        }

        static void Main(string[] args)
        {
            string[] list = System.IO.File.ReadAllLines("C:/Users/jaden/source/repos/C#/AdCode/AdCode/test.txt");
       
            int total = Calc_Largest_Cal(list);
            Console.WriteLine(total);
           

        }

    }

}




