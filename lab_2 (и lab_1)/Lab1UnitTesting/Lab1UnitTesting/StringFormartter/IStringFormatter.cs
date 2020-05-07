using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1UnitTesting
{
    public interface IStringFormatter
    {
        String SaveString(String s);
        String stringToUpper(String temp);
        String stringReplacing(String temp);
    }
}
