using System;
using System.IO;
using System.Collections.Generic;

namespace _202003
{
    class Program
    {
        static int CheckTreeSlope(List<string> lines, int over, int down)
        {
            int curpos = over;
            int treeCount = 0;
            int downCount = 0;
            foreach(string line in lines) {
                if (downCount == down)
                    downCount = 0;
                else {
                    downCount++;
                    continue;
                }
                if (line[curpos] == '#') {
                    treeCount++;
                    // System.Text.StringBuilder strBuilder = new System.Text.StringBuilder(line);
                    // strBuilder[curpos] = 'X';
                    // Console.WriteLine(strBuilder.ToString());
                }
                // else {
                //     System.Text.StringBuilder strBuilder = new System.Text.StringBuilder(line);
                //     strBuilder[curpos] = 'O';
                //     Console.WriteLine(strBuilder.ToString());
                // }
                if (curpos + over >= line.Length)
                    curpos = curpos + over - line.Length;
                else
                    curpos += over;
                downCount++;
            }
            return treeCount;

        }
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            string data;
            StreamReader reader=new StreamReader(".\\input.txt");
            try
            {

                do
                {
                    data = reader.ReadLine();
                    lines.Add(data);
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
            

            int a = CheckTreeSlope(lines, 1, 1);
            int b = CheckTreeSlope(lines, 3, 1);
            int c = CheckTreeSlope(lines, 5, 1);
            int d = CheckTreeSlope(lines, 7, 1);
            int e = CheckTreeSlope(lines, 1, 2);

            Console.WriteLine(a*b*c*d*e);
        }
    }
}
