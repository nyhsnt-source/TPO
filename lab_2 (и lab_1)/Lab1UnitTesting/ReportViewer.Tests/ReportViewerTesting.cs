using NUnit.Framework;
using Lab1UnitTesting;
using System.IO;
using FileServise.Tests.Mock;
using Moq;

namespace ReportViewer.Tests
{
    public class ReportViewerTesting
    {
        Mock<IFileServise> moq;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FileDoesNotExist()
        {
            IFileServise iFile = new StubFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer(iFile);            
            Assert.Throws<FileNotFoundException>(() => iReport.Clean("D:\\ToRead.txt"));
        }

        [Test]
        public void FileDoesNotExistProperty()
        {
            IFileServise iFile = new StubFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer();
            iReport.FileServise = iFile;
            Assert.Throws<FileNotFoundException>(() => iReport.Clean("D:\\ToRead.txt"));
        }

        [Test]
        public void FileDoesNotExistMock()
        {
            IFileServise iFile = new MockFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer(iFile);
            Assert.Throws<FileNotFoundException>(() => iReport.Clean("D:\\ToRead.txt"));
        }

        [Test]
        public void FileDoesNotExistPropertyMock()
        {
            IFileServise iFile = new MockFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer();
            iReport.FileServise = iFile;
            Assert.Throws<FileNotFoundException>(() => iReport.Clean("D:\\ToRead.txt"));
        }

        //[Test]
        //public void FileDoesNotExistMoq()
        //{
        //    moq.Setup(x => x.RemoveTemporaryFiles(It.IsAny<string>())).Throws<FileNotFoundException>();
        //    Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer(moq.Object);
        //    iReport.Clean("D://test.asm");
        //    moq.VerifyAll();
        //}

        [Test]
        public void FileDoesNotExistPropertyMoq()
        {
            moq.Setup(x => x.RemoveTemporaryFiles(It.IsAny<string>())).Throws<FileNotFoundException>();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer();
            iReport.FileServise = moq.Object;
            iReport.Clean("D://test.asm");
            //moq.VerifyAll();
        }

        [Test]
        public void FileExist()
        {
            IFileServise iFile = new StubFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer(iFile);
            iReport.Clean("D:\\VisualStudio2019\\ToRead.txt");
            var tmp = iReport.usedSize;
            var expected = 100;
            Assert.AreEqual(expected, tmp);
        }

        [Test]
        public void FileExistProperty()
        {
            IFileServise iFile = new StubFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer();
            iReport.FileServise = iFile;
            iReport.Clean("D:\\VisualStudio2019\\ToRead.txt");
            var tmp = iReport.usedSize;
            var expected = 100;
            Assert.AreEqual(expected, tmp);
        }

        [Test]
        public void FileExistMock()
        {
            IFileServise iFile = new MockFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer(iFile);
            iReport.Clean("D:\\VisualStudio2019\\ToRead.txt");
            var tmp = iReport.usedSize;
            var expected = 100;
            Assert.AreEqual(expected, tmp);
        }

        [Test]
        public void FileExistPropertyMock()
        {
            IFileServise iFile = new MockFileServise();
            Lab1UnitTesting.ReportViewer iReport = new Lab1UnitTesting.ReportViewer();
            iReport.FileServise = iFile;
            iReport.Clean("D:\\VisualStudio2019\\ToRead.txt");
            var tmp = iReport.usedSize;
            var expected = 100;
            Assert.AreEqual(expected, tmp);
        }
    }
}