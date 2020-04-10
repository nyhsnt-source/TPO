using NUnit.Framework;
using System;
using Task3;

namespace NUnitTestProject1
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            ArrayProcessor arrayProcessor = new ArrayProcessor();

            int[] testArray = { -10000, 10, 0, 1000, 1000, 5544, -5000, 3322, 7777, 2222, 9999, 120000 };

            // делаем копию массива что передаем, чтобы убедится что после работы программы исходный - не затрагивали
            int[] testArrayCopy = new int[testArray.Length]; 
            Array.Copy(testArray, testArrayCopy, testArray.Length);
            
            int[] result = arrayProcessor.SortAndFilter(testArray);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(testArray, testArrayCopy);

                Assert.That(result, Is.Ordered);
                Assert.That(result, Has.All.InRange(1000, 9999));
            });

            testArray = new int[0];
            result = arrayProcessor.SortAndFilter(testArray);
            Assert.AreEqual(testArray, result);

            testArray = new int[] { 1000, 1000, 1000 };
            result = arrayProcessor.SortAndFilter(testArray);
            Assert.AreEqual(testArray, result);

            testArray = null;
            Assert.Throws<ArgumentNullException>(() => arrayProcessor.SortAndFilter(testArray));

            Assert.Pass();
        }
    }
}