using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class StringFormatter
    {
        public static void Main(String[] args) { }

        public string WebString(string s)
        {
            if (s == null)
                throw new NullReferenceException();
            if (s.Length == 0)
                return "";
            if (s.Trim().Length == 0)
                return "";
            if (s.EndsWith(".git")) {
                if (s.StartsWith("git://"))
                    return s;
                else
                    return "git://" + s;
            }
            if (s.StartsWith("http://") || s.StartsWith("https://"))
                return s;
            else
                return "http://" + s;
        }
    }
}
