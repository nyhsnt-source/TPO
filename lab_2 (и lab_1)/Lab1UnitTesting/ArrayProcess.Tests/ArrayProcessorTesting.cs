using Lab1UnitTesting;
using NUnit.Framework;

namespace ArrayProcess.Tests
{
    public class ArrayProcessorTesting
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CanSortAndFilterArray()
        {
            //Arrange
            ArrayProcessor ap = new ArrayProcessor();
            int[] tmp = { -3, -10, 9, 9, 8, -3, -10, 4, 5, 1 };
            int[] fin = { -10, -3, 1, 4, 5, 8, 9, 9 };
            //Act
            tmp = ap.SortAndFilter(tmp);
            //Assert
            NUnit.Framework.Assert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanSortAndFilterArrayAssertCollection()
        {
            //Arrange
            ArrayProcessor ap = new ArrayProcessor();
            int[] tmp = { -3, -10, 9, 9, 8, -3, -10, 4, 5, 1 };
            int[] fin = { -10, -3, 1, 4, 5, 8, 9, 9 };
            //Act
            tmp = ap.SortAndFilter(tmp);
            //Assert
            NUnit.Framework.CollectionAssert.AreEqual(fin, tmp);
        }

        [Test]
        public void CanSortAndFilterArrayMSUnit()
        {
            //Arrange
            ArrayProcessor ap2 = new ArrayProcessor();
            int[] tmp = { -10, 9, 9, 8, -3, -10, 4, 5, 1 };
            int[] fin = { -10, -3, 1, 4, 5, 8, 9, 9 };
            //Act
            tmp = ap2.SortAndFilter(tmp);
            //Assert
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(fin, tmp);
        }
    }
}