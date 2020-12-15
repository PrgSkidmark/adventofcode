using System;
using System.IO;
using System.Collections.Generic;

namespace _202002
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> passwords = new List<string>();
            string data;
            StreamReader reader=new StreamReader(".\\input.txt");
            try
            {

                do
                {
                    data = reader.ReadLine();
                    passwords.Add(data);
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

            string range;
            string letter;
            string pw;
            int min;
            int max;
            int charCount;
            //int badCount = 0;
            int goodCountWay1 = 0;
            int goodCountWay2 = 0;
            bool bGood;
            for (int pwNum = 0; pwNum < passwords.Count; pwNum++) {
                data = passwords[pwNum];
                range = data.Substring (0, data.IndexOf(" "));
                min = Int32.Parse(range.Substring(0, data.IndexOf("-")));
                max = Int32.Parse(range.Substring(data.IndexOf("-")+1));
                
                letter = data.Substring (data.IndexOf(" ")+1, 1);
                pw = data.Substring(data.IndexOf(":")+2);

                charCount = 0;
                for (int charNum = 0; charNum < pw.Length; charNum++) {
                    if (pw[charNum] == letter[0])
                        charCount++;
                }
                if ((charCount >= min) && (charCount <= max)) {
                    goodCountWay1++;
                }
                bGood = false;
                if (min-1 < pw.Length)
                    if (pw[min-1] == letter[0])
                        bGood = true;
                if (max-1 < pw.Length) {
                    if (pw[max-1] == letter[0]) 
                        bGood = true;
                    if ( (pw[min-1] == letter[0]) && (pw[max-1] == letter[0]))
                        bGood = false;
                }
                if (bGood)
                    goodCountWay2++;
                
            }
            Console.WriteLine(goodCountWay1);
            Console.WriteLine(goodCountWay2);

        }
    }
}
