using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _202005
{
    class Program
    {
        static int FindSeatId(string data)
        {
            int rows = 127;
            int cols = 7;
            int minRow = 0;
            int maxRow = rows;
            int minCol = 0;
            int maxCol = cols;

            foreach (char c in data)
            {
                if (c == 'F')
                {
                    if (maxRow - minRow == 1)
                    {
                        maxRow = minRow;
                    }
                    else
                    {
                        maxRow = maxRow - ((maxRow - minRow) / 2) - 1;
                    }
                }
                else if (c == 'B')
                {
                    if (maxRow - minRow == 1)
                    {
                        minRow = maxRow;
                    }
                    else
                    {
                        minRow = minRow + ((maxRow - minRow) / 2) + 1;
                    }
                }
                else if (c == 'L')
                {
                    if (maxCol - minCol == 1)
                    {
                        maxCol = minCol;
                    }
                    else
                    {
                        maxCol = maxRow - ((maxCol - minCol) / 2) - 1;
                    }

                }
                else if (c == 'R')
                {
                    if (maxCol - minCol == 1)
                    {
                        minCol = maxCol;
                    }
                    else
                    {
                        minCol = minCol + ((maxCol - minCol) / 2) + 1;
                    }

                }

            }
            return (minRow * 8) + minCol;
        }
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            string data;
            int highestSeatId = 0;
            StreamReader reader = new StreamReader(".\\sampleinput.txt");
            try
            {

                do
                {
                    data = reader.ReadLine();
                    lines.Add(data);
                }
                while (reader.Peek() != -1);
            }
            catch
            {
                Console.WriteLine("empty file");
            }
            finally
            {
                reader.Close();
            }

            int seatId;
            foreach (string line in lines)
            {
                seatId = FindSeatId(line);
                Console.WriteLine(seatId);
                if (seatId > highestSeatId)
                    highestSeatId = seatId;
            }
            Console.WriteLine(highestSeatId);
        }
    }
}
