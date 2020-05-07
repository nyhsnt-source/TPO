using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1UnitTesting
{
    public class FileServises : IFileServise
    {
        #region Private Fields
        private Boolean fileOpened = false;
        private Boolean filesRemoved = false;
        List<String> errorLog;
        #endregion
        #region Public Fields
        public Boolean FileIsOpened
        {
            get
            {
                return fileOpened;
            }
            private set { }
        }
        public Boolean FilesAreRemoved
        {
            get
            {
                return filesRemoved;
            }
            private set { }
        }
        public List<String> ShowErrorLog
        {
            get
            {
                return errorLog;
            }
            private set { }
        }
        #endregion
        #region Constructors
        public FileServises() 
        {
            errorLog = new List<String>();
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public List<String> ReadTemporaryFilesFromTxT(String dir)
        {
            List<String> temporaryFiles = new List<String>();

            using(StreamReader sr = new StreamReader(dir))
            {
                fileOpened = true;
                String tmp_line;
                while ((tmp_line = sr.ReadLine()) != null)
                {
                    if (tmp_line.Trim() != "")
                    {
                        temporaryFiles.Add(tmp_line.Trim());
                    }
                }
            }

            return temporaryFiles;
        }
        public List<String> CreateFilesToDeletePath(List<String> FilesToDelete, String path)
        {
            List<String> filesToDeletePath = new List<String>();
            String dir = Path.GetDirectoryName(path);
            for(int i = 0; i < FilesToDelete.Count; i++)
            {
                string tmp = String.Concat(dir, "\\", FilesToDelete[i]);
                if (!File.Exists(tmp))
                {
                    String errorLogString = String.Concat("File ", FilesToDelete[i], " was not found!");
                    errorLog.Add(errorLogString);
                }
                else
                {
                    filesToDeletePath.Add(tmp);
                }
            }
            return filesToDeletePath;
        }
        public long RemoveFilesListed(List<String> filesToRemove)
        {
            long filesRemovedSize = new long();
            int deletedFilesCounter = 0;
            for(int i = 0; i < filesToRemove.Count; i++)
            {
                filesRemovedSize += new FileInfo(filesToRemove[i]).Length;
                File.Delete(filesToRemove[i]);
                if (!File.Exists(filesToRemove[i]))
                    deletedFilesCounter++;
            }
            if (deletedFilesCounter == filesToRemove.Count)
                filesRemoved = true;
            return filesRemovedSize;
        }
        public long RemoveTemporaryFiles(String dir)
        {
            String ToRemoveTxTPath = dir;
            long deletedFilesSize = new long();
            List<String> files = new List<String>();
            List<String> filesToDelete = new List<String>();
            if (!File.Exists(ToRemoveTxTPath))
                throw new FileNotFoundException();
            files = ReadTemporaryFilesFromTxT(ToRemoveTxTPath);
            filesToDelete = CreateFilesToDeletePath(files, ToRemoveTxTPath);
            deletedFilesSize = RemoveFilesListed(filesToDelete);
            return deletedFilesSize;
        }
        #endregion
    }
}
