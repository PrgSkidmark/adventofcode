using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _202004
{
    class Program
    {
        static bool ValidatePassport1(List<string> lines) {
            string[] words;
            List<string> entries = new List<string>();
            foreach(string line in lines) {
                words = line.Split(' ');
                foreach(string word in words) {
                    entries.Add(word);
                }
                words = null;
            }
            bool byr = false;
            bool iyr = false;
            bool eyr = false;
            bool hgt = false;
            bool hcl = false;
            bool ecl = false;
            bool pid = false;
            bool cid = true;
            foreach(string entry in entries){
                if (entry.StartsWith("byr") == true)
                    byr = true;
                if (entry.StartsWith("iyr") == true)
                    iyr = true;
                if (entry.StartsWith("eyr") == true)
                    eyr = true;
                if (entry.StartsWith("hgt") == true)
                    hgt = true;
                if (entry.StartsWith("hcl") == true)
                    hcl = true;
                if (entry.StartsWith("ecl") == true)
                    ecl = true;
                if (entry.StartsWith("pid") == true)
                    pid = true;
                //if (entry.StartsWith("cid") == true)
                //    cid = true;
            }
            return byr && iyr && eyr && hgt && hcl && ecl && pid && cid;
        }
        static bool ValidatePassport2(List<string> lines) {
            string[] words;
            List<string> entries = new List<string>();
            foreach(string line in lines) {
                words = line.Split(' ');
                foreach(string word in words) {
                    entries.Add(word);
                }
                words = null;
            }
            bool byr = false;
            bool iyr = false;
            bool eyr = false;
            bool hgt = false;
            bool hcl = false;
            bool ecl = false;
            bool pid = false;
            bool cid = true;
            foreach(string entry in entries){
             
                if (entry.StartsWith("byr") == true) {
                    string valueStr;
                    int valueInt;
                    valueStr = entry.Substring(4);
                    Int32.TryParse(valueStr, out valueInt);
                    if ((valueInt >= 1920) && (valueInt <= 2002))
                        byr = true;
                }
                    
                if (entry.StartsWith("iyr") == true) {
                    string valueStr;
                    int valueInt;
                    valueStr = entry.Substring(4);
                    Int32.TryParse(valueStr, out valueInt);
                    if ((valueInt >= 2010) && (valueInt <= 2020))
                        iyr = true;

                }
                if (entry.StartsWith("eyr") == true) {
                    string valueStr;
                    int valueInt;
                    valueStr = entry.Substring(4);
                    Int32.TryParse(valueStr, out valueInt);
                    if ((valueInt >= 2020) && (valueInt <= 2030))
                        eyr = true;
                }
                if (entry.StartsWith("hgt") == true) {
                    string valueStr;
                    valueStr = entry.Substring(4);
                    int valueInt;
                    if (valueStr.EndsWith("cm")) {
                        valueStr = valueStr.Replace("cm","");
                        Int32.TryParse(valueStr, out valueInt);
                        if ((valueInt >= 150) && (valueInt <= 193))
                            hgt = true;
                    }
                    if ( valueStr.EndsWith("in")) {
                        valueStr = valueStr.Replace("in","");
                        Int32.TryParse(valueStr, out valueInt);
                        if ((valueInt >= 59) && (valueInt <= 76))
                            hgt = true;
                    }
                }
                    
                if (entry.StartsWith("hcl") == true) {
                    Regex rx = new Regex(@"^hcl:#[0-9a-f]{6}$",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    // Find matches.
                    MatchCollection matches = rx.Matches(entry);

                    hcl = matches.Count > 0;
                }
                if (entry.StartsWith("ecl") == true) {
                    Regex rx = new Regex(@"^ecl:(amb|blu|brn|gry|grn|hzl|oth)$",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    // Find matches.
                    MatchCollection matches = rx.Matches(entry);

                    ecl = matches.Count > 0;
                }
  
                if (entry.StartsWith("pid") == true) {
                    Regex rx = new Regex(@"^pid:[0-9]{9}$",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    // Find matches.
                    MatchCollection matches = rx.Matches(entry);

                    pid = matches.Count > 0;
                }
                    
                //if (entry.StartsWith("cid") == true)
                //    cid = true;
            }
            return byr && iyr && eyr && hgt && hcl && ecl && pid && cid;
        }
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            string data;
            int validPassports = 0;
            StreamReader reader=new StreamReader(".\\input.txt");
            try
            {

                do
                {
                    data = reader.ReadLine();
                    if (data == "") {
                        if (ValidatePassport2(lines))
                            validPassports++;
                        lines.Clear();
                    }
                    else
                        lines.Add(data);
                }
                while(reader.Peek()!= -1);
                if (ValidatePassport2(lines))
                    validPassports++;                
            }
            catch
            {
                Console.WriteLine("empty file");
            }
            finally
            {
                reader.Close();
            }
            Console.WriteLine(validPassports);

        }
    }
}
