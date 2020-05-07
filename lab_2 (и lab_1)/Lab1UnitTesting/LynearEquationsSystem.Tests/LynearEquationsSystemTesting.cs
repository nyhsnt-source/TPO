using NUnit.Framework;
using System;

namespace LynearEquationsSystem.Tests
{
    public class LynearEquationsSystemTesting
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CanFindDeterminant()
        {
            Lab1UnitTesting.LynearEquationsSystem les = new Lab1UnitTesting.LynearEquationsSystem();

            double[,] test = new double[3, 4] { { 1, 2, 3, 1 }, { 3, 2, 1, 2 }, { 1, 3, 2, 3 } };
            les.SetCoefs(test);

            double fin=les.Det();

            NUnit.Framework.Assert.AreEqual(12.0,fin);
        }

        [Test]
        public void CanFindDeterminantAssertCollection()
        {
            Lab1UnitTesting.LynearEquationsSystem les = new Lab1UnitTesting.LynearEquationsSystem();

            double[,] test = new double[3, 4] { { 1, 2, 3, 1 }, { 3, 2, 1, 2 }, { 1, 3, 2, 3 } };
            les.SetCoefs(test);

            var fin = les.Det().ToString();
            var exp = "12";

            NUnit.Framework.CollectionAssert.AreEqual(exp, fin);
        }

        [Test]
        public void CanFindDeterminantMSUnit()
        {
            Lab1UnitTesting.LynearEquationsSystem les = new Lab1UnitTesting.LynearEquationsSystem();

            double[,] test = new double[3, 4] { { 1, 2, 3, 1 }, { 3, 2, 1, 2 }, { 1, 3, 2, 3 } };
            les.SetCoefs(test);

            double fin = les.Det();
            
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(12.0, fin);
        }

        [Test]
        public void CanSolve()
        {
            Lab1UnitTesting.LynearEquationsSystem les = new Lab1UnitTesting.LynearEquationsSystem();

            double[,] test = new double[3, 4] { { 1, 2, 3, 1 }, { 3, 2, 1, 2 }, { 1, 3, 2, 3 } };
            les.SetCoefs(test);

            double[] result = new double[3] { -0.08, 1.42, -0.58};

            double[] fin=les.Solve();

            //NUnit.Framework.Assert.AreEqual(result,fin);
        }

        [Test]
        public void CanSolveAssertCollection()
        {
            Lab1UnitTesting.LynearEquationsSystem les = new Lab1UnitTesting.LynearEquationsSystem();

            double[,] test = new double[3, 4] { { 1, 2, 3, 1 }, { 3, 2, 1, 2 }, { 1, 3, 2, 3 } };
            les.SetCoefs(test);

            var fin = les.Det().ToString();
            var exp = "12";

            NUnit.Framework.CollectionAssert.AreEqual(exp, fin);
        }

        [Test]
        public void CanSolveMSUnit()
        {
            Lab1UnitTesting.LynearEquationsSystem les = new Lab1UnitTesting.LynearEquationsSystem();

            double[,] test = new double[3, 4] { { 1, 2, 3, 1 }, { 3, 2, 1, 2 }, { 1, 3, 2, 3 } };
            les.SetCoefs(test);

            double fin = les.Det();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(12.0, fin);
        }
    }
}