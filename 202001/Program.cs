using System;
using System.IO;
using System.Collections.Generic;

namespace _202001
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            StreamReader reader=new StreamReader(".\\input.txt");
            try
            {
                string num;
                int convNum;
                do
                {
                    num = reader.ReadLine();
                    Int32.TryParse(num, out convNum);
                    numbers.Add(convNum);
                }
                while(reader.Peek()!= -1);
            }
            catch
            {
                Console.WriteLine("empty file");
            }
            finally
            {
                reader.Close();
            }

            int firstPos;
            int secondPos;
            int thirdPos;

            for (firstPos = 0; firstPos < numbers.Count; firstPos++) {
                for (secondPos = 0; secondPos < numbers.Count; secondPos++) {
                    if (secondPos == firstPos)
                        continue;
                    if ((numbers[firstPos] + numbers[secondPos]) == 2020) {
                        Console.WriteLine(numbers[firstPos] * numbers[secondPos]);
                        break;
                    }
                }
            }

            for (firstPos = 0; firstPos < numbers.Count; firstPos++) {
                for (secondPos = 0; secondPos < numbers.Count; secondPos++) {
                    if (secondPos == firstPos)
                        continue;
                    for (thirdPos = 0; thirdPos < numbers.Count; thirdPos++) {
                        if ((thirdPos == secondPos) || (thirdPos == firstPos))
                            continue;
                        if ((numbers[firstPos] + numbers[secondPos] + numbers[thirdPos]) == 2020) {
                            Console.WriteLine(numbers[firstPos] * numbers[secondPos] * numbers[thirdPos]);
                            break;
                        }
                    }
                }
            }            
        }
    }
}
