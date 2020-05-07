using System;
using System.Collections.Generic;
using System.Text;
using Lab1UnitTesting;

namespace FileServise.Tests.Mock
{
    public class MockFileServise : IFileServise
    {
        public Boolean DeleteTempFiles { get; private set; }
        public long RemoveTemporaryFiles(string dir)
        {
            DeleteTempFiles = true;
            return 100;
        }
    }
}
