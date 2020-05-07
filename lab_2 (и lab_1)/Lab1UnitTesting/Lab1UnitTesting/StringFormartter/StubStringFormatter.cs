using System;

namespace Lab1UnitTesting
{
    public class StubStringFormatter:IStringFormatter
    {
        public String SaveString(String s)
        {
            return "Some test string UPDATE ''temp'';";
        }
        public String stringToUpper(String temp)
        {
            return "test string UPDATE";
        }
        public String stringReplacing(String temp)
        {
            return "test string = ''text'' UPDATE";
        }
    }
}
