using Lab1UnitTesting;
using Moq;
using NUnit.Framework;

namespace NUnitTestLab1
{
    public class StringFormarterTesting
    {

        private MockStringFormartter _mockStringFormartter;
        Mock<IStringFormatter> _mockStringFormatterMoq;

        [SetUp]
        public void Setup()
        {
            _mockStringFormartter = new MockStringFormartter();
            _mockStringFormatterMoq = new Mock<IStringFormatter>();
        }

        [Test]
        public void CanUpperTheString()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like insert, delete, update, etc. to see if it`s really working";
            string fin = "Some test string with key words like INSERT, DELETE, UPDATE, etc. to see if it`s really working";
            //Act
            tmp=sf.stringToUpper(tmp);
            //Assert
            NUnit.Framework.Assert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanReplaceInString()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like 'INSERT', 'DELETE', 'UPDATE', etc. to see if it`s really working";
            string fin = "Some test string with key words like ''INSERT'', ''DELETE'', ''UPDATE'', etc. to see if it`s really working";
            //Act
            tmp = sf.stringReplacing(tmp);
            //Assert
            NUnit.Framework.Assert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanSaveString() 
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like 'insert', 'delete', 'update', etc. to see if it`s really working";
            string fin = "Some test string with key words like ''INSERT'', ''DELETE'', ''UPDATE'', etc. to see if it`s really working";
            //Act
            tmp = sf.SaveString(tmp);
            //Assert
            NUnit.Framework.Assert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanUpperTheStringAssertCollection()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like insert, delete, update, etc. to see if it`s really working";
            string fin = "Some test string with key words like INSERT, DELETE, UPDATE, etc. to see if it`s really working";
            //Act
            tmp = sf.stringToUpper(tmp);
            //Assert
            NUnit.Framework.CollectionAssert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanReplaceInStringAssertCollection()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like 'INSERT', 'DELETE', 'UPDATE', etc. to see if it`s really working";
            string fin = "Some test string with key words like ''INSERT'', ''DELETE'', ''UPDATE'', etc. to see if it`s really working";
            //Act
            tmp = sf.stringReplacing(tmp);
            //Assert
            NUnit.Framework.CollectionAssert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanSaveStringAssertCollection()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like 'insert', 'delete', 'update', etc. to see if it`s really working";
            string fin = "Some test string with key words like ''INSERT'', ''DELETE'', ''UPDATE'', etc. to see if it`s really working";
            //Act
            tmp = sf.SaveString(tmp);
            //Assert
            NUnit.Framework.CollectionAssert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanUpperTheStringMSUnit()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like insert, delete, update, etc. to see if it`s really working";
            string fin = "Some test string with key words like INSERT, DELETE, UPDATE, etc. to see if it`s really working";
            //Act
            tmp = sf.stringToUpper(tmp);
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanReplaceInStringMSUnit()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like 'INSERT', 'DELETE', 'UPDATE', etc. to see if it`s really working";
            string fin = "Some test string with key words like ''INSERT'', ''DELETE'', ''UPDATE'', etc. to see if it`s really working";
            //Act
            tmp = sf.stringReplacing(tmp);
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanSaveStringMSUnit()
        {
            //Arrange
            StringFormatter sf = new StringFormatter();
            string tmp = "Some test string with key words like 'insert', 'delete', 'update', etc. to see if it`s really working";
            string fin = "Some test string with key words like ''INSERT'', ''DELETE'', ''UPDATE'', etc. to see if it`s really working";
            //Act
            tmp = sf.SaveString(tmp);
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(fin, tmp);
        }

        //LAB2------------------------------------------
        //STUB - constructor
        [Test]
        public void CanPrepareQueries()
        {
            //Arrange
            IStringFormatter sf = new StubStringFormatter();
            SqlQueryPreparator sql = new SqlQueryPreparator(sf);
            string[] tmp = { "Some test string update 'temp';" };
            string[] fin = { "Some test string UPDATE ''temp'';" };
            //Act
            tmp = sql.PrepareQueries(tmp);
            //Assert
            NUnit.Framework.Assert.AreEqual(fin, tmp);
        }

        //STUB - property
        [Test]
        public void CanPrepareQueriesSetters() 
        {
            IStringFormatter sf = new StubStringFormatter();
            SqlQueryPreparator sql = new SqlQueryPreparator();
            sql.StringFormatter = sf;// Dependency Injection
            string[] tmp = { "Some test string update 'temp';" };
            string[] fin = { "Some test string UPDATE ''temp'';" };

            tmp = sql.PrepareQueries(tmp);

            NUnit.Framework.Assert.AreEqual(fin, tmp);
        }

        //MOCKS - constructor
        [Test]
        public void CanPrepareQueriesMock()
        {
            //Arrange
            //IStringFormatter sf = new StubStringFormatter();
            SqlQueryPreparator sql = new SqlQueryPreparator(_mockStringFormartter);
            string[] tmp = { "Some test string update 'temp';" };
            string[] fin = { "Some test string UPDATE ''temp'';" };
            //Act
            tmp = sql.PrepareQueries(tmp);
            //Assert
            //NUnit.Framework.Assert.AreEqual(fin, tmp);
            NUnit.Framework.Assert.IsTrue(_mockStringFormartter.SaveStringProperty);
        }
        //MOCKS - property
        [Test]
        public void CanPrepareQueriesSettersMock()
        {
            //IStringFormatter sf = new StubStringFormatter();
            SqlQueryPreparator sql = new SqlQueryPreparator();
            sql.StringFormatter = _mockStringFormartter;// Dependency Injection
            string[] tmp = { "Some test string update 'temp';" };
            string[] fin = { "Some test string UPDATE ''temp'';" };

            tmp = sql.PrepareQueries(tmp);

            //NUnit.Framework.Assert.AreEqual(fin, tmp);
            NUnit.Framework.Assert.IsTrue(_mockStringFormartter.SaveStringProperty);
        }
        //Moq

        [Test]
        public void CanPrepateStringMoq()
        {
            _mockStringFormatterMoq.Setup(x => x.SaveString(It.IsAny<string>()));
            SqlQueryPreparator sql = new SqlQueryPreparator(_mockStringFormatterMoq.Object);
            string[] tmp = { "Some test string update 'temp';" };
            string[] fin = { "Some test string UPDATE ''temp'';" };
            //Act
            tmp = sql.PrepareQueries(tmp);
            //Assert
            _mockStringFormatterMoq.VerifyAll();
        }

        [Test]
        public void CanPrepateStringMoqProperty()
        {
            _mockStringFormatterMoq.Setup(x => x.SaveString(It.IsAny<string>()));
            SqlQueryPreparator sql = new SqlQueryPreparator();
            sql.StringFormatter = _mockStringFormatterMoq.Object;
            string[] tmp = { "Some test string update 'temp';" };
            string[] fin = { "Some test string UPDATE ''temp'';" };
            //Act
            tmp = sql.PrepareQueries(tmp);
            //Assert
            _mockStringFormatterMoq.VerifyAll();
        }
    }
}