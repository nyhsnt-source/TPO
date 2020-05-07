using NUnit.Framework;
using System.IO;
using Lab1UnitTesting;
using System.Collections.Generic;

namespace FileServise.Tests
{
    public class FileServiseTesting
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void FileDoesNotExist()
        {
            FileServises File = new FileServises();
            string tmp_path_to_txt = "D://1//ToRemove.txt";
            Assert.Throws<FileNotFoundException>(()=> File.RemoveTemporaryFiles(tmp_path_to_txt));
        }

        [Test]
        public void CanOpenFile()
        {
            FileServises File = new FileServises();
            string tmp_path_to_txt = "D:\\VisualStudio2019\\ToRead.txt";
            File.ReadTemporaryFilesFromTxT(tmp_path_to_txt);
            var result = File.FileIsOpened;
            Assert.IsTrue(result);
        }

        [Test]
        public void CanReadFilesFromTxT()
        {
            FileServises File = new FileServises();
            string tmp_path_to_txt = "D:\\VisualStudio2019\\ToRead.txt";
            var result = File.ReadTemporaryFilesFromTxT(tmp_path_to_txt);
            List<string> expected = new List<string>();
            expected.Add("test.txt");
            expected.Add("test.asm");
            expected.Add("temp.doc");
            expected.Add("rest.com");
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void CanReturnDeletedFilesSize()
        {
            FileServises File = new FileServises();
            string tmp_path_to_txt = "D:\\VisualStudio2019\\ToRemove1.txt";
            var result = File.RemoveTemporaryFiles(tmp_path_to_txt);
            var expected = 478;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CanRemoveFilesFromTxT()
        {
            FileServises File = new FileServises();
            string tmp_path_to_txt = "D:\\VisualStudio2019\\ToRemove.txt";
            File.RemoveTemporaryFiles(tmp_path_to_txt);
            var result = File.FilesAreRemoved;
            Assert.IsTrue(result);
        }

        [Test]
        public void FileWasNotFound()
        {
            FileServises File = new FileServises();
            string tmp_path_to_txt = "D:\\VisualStudio2019\\ToRead1.txt";
            File.RemoveTemporaryFiles(tmp_path_to_txt);
            var result = File.ShowErrorLog;
            List<string> expected = new List<string>();
            expected.Add("File rest.com was not found!");
            expected.Add("File temp.doc was not found!");
            expected.Add("File menu.exe was not found!");
            expected.Add("File set.msc was not found!");
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}