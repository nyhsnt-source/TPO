using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab1UnitTesting
{
    public class ReportViewer : IReportViewer
    {
        #region Private Fields
        private long fileSize;
        private IFileServise iFs;
        #endregion
        #region Public Fields
        public long usedSize 
        {
            get
            {
                return fileSize;
            }
            private set { }
        }
        public IFileServise FileServise
        {
            set
            {
                iFs = value;
            }
            get
            {
                if (iFs == null)
                {
                    throw new MemberAccessException("FileServise has not been initialized.");
                }
                return iFs;
            }
        }
        #endregion
        #region Constructors
        public ReportViewer() 
        {
            iFs = new FileServises();
        }
        public ReportViewer(IFileServise fileServise)
        {
            iFs = fileServise;
        }
        #endregion
        #region Public Methods
        public void Clean(string dir)
        {
            if(!File.Exists(dir))
                throw new FileNotFoundException();
            else
            {
                var temp = iFs.RemoveTemporaryFiles(dir);
                fileSize = temp;
            }
        }
        #endregion
    }
}
