using Lab1UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestLab1
{
    public class MockStringFormartter : IStringFormatter
    {
        public bool SaveStringProperty { get; private set; }
        public bool stringReplacingProperty { get; private set; }
        public bool stringToUpperProperty { get; private set; }
        public string SaveString(string s)
        {
            SaveStringProperty = true;
            return s;
        }

        public string stringReplacing(string temp)
        {
            stringReplacingProperty = true;
            return temp;
        }

        public string stringToUpper(string temp)
        {
            stringToUpperProperty = true;
            return temp;
        }
    }
}
