using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1UnitTesting
{
    public interface IReportViewer
    {
        void Clean(String dir);
        long usedSize { get; }
    }
}
