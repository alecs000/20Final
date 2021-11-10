using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _20
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("t.txt");
            int numString = 0;
            bool tf = false;
            string s;
            int numAgree = 0;
            string polStr = Console.ReadLine();
            string mStr;
            string[] arrTouch = new string[polStr.Length];
            int num = 0;
            for (int i = 0; i < polStr.Length; i++)
            {
                mStr = polStr;
                string sss = Convert.ToString(polStr[i]);
                
                int iii = mStr.IndexOf(".");
               ;
                if (i == 0)
                {
                    mStr = "." + polStr.Substring(1);
                }
                else if (i + 1 != polStr.Length)
                {
                    mStr = polStr.Substring(0, i) + "." + polStr.Substring(i + 1);
                }
                else if (i + 1 == polStr.Length)
                {
                    mStr = polStr.Substring(0, i) + ".";
                }
                    arrTouch[i] = mStr; 
            }
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                numString++;
                string word = "";
                for (int i = 0; i < s.Length; i++)
                {
                    MatchCollection matches =null;
                    if (s[i] == ' ')
                    {
                        for (int j = 0; j < arrTouch.Length; j++)
                        {
                            Regex regex = new Regex(arrTouch[j]);
                            matches = regex.Matches(word);
                            if (matches.Count != 0)
                                break;
                        }
                        word = "";
                    }
                    word += s[i];
                    if (i == s.Length - 1)
                    {
                        for (int j = 0; j < arrTouch.Length; j++)
                        {
                            Regex regex = new Regex(arrTouch[j]);
                            matches = regex.Matches(word);
                            if (matches.Count != 0)
                                break;
                        }  
                    }
                    if (matches != null && matches.Count!=0)
                    {
                        numAgree++;
                        tf = true;
                    }  
                }
                if (tf)
                {
                    Console.WriteLine("На строке "+numString+ " есть совпадение!!!");
                }
                tf = false;
            }
            sr.Close();
            Console.WriteLine("Колличество совпадений: "+numAgree); 
        }
    }
}
