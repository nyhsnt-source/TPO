using NUnit.Framework;
using System;
using Task1;

namespace NUnitTestProject1
{
    public class Tests
    {

        [Test]
        public void TestNormal()
        {
            double[] x = { 1, 1, 7, 7 };
            double[] y = { 2, 10, 10, 2 };
            Rectangle rect = new Rectangle(x, y);
            Assert.AreEqual(10.0, rect.Diagonal());

            x = new double[] { 2, 2, 6, 6 };
            y = new double[] { 1, 4, 4, 1 };
            rect.SetVertices(x, y);
            Assert.AreEqual(5.0, rect.Diagonal());

            // проверка что не ломается при отр. координатах
            x = new double[] { -2, -2, -6, -6 };
            y = new double[] { -1, -4, -4, -1 };
            rect.SetVertices(x, y);
            Assert.AreEqual(5.0, rect.Diagonal());


            x = new double[] { 1, 1, 5, 5 };
            y = new double[] { 1, 4, 4, 1 };
            rect.SetVertices(x, y);
            Assert.AreEqual(5.0, rect.Diagonal());

            // проверка что не ломается при нулевой координате
            x = new double[] { 0, 0, 4, 4 };
            y = new double[] { 0, 3, 3, 0 };
            rect.SetVertices(x, y);
            Assert.AreEqual(5.0, rect.Diagonal());


            // то же что и пример выше, просто координаты перемешаны
            x = new double[] { 2, 2, 6, 6 };
            y = new double[] { 1, 4, 4, 1 };
            rect.SetVertices(x, y);
            Assert.AreEqual(5.0, rect.Diagonal());            
            
            // TODO добавить и на дробные ответы, но решение округляет до 3х знаков

            Assert.Pass();
        }

        [Test]
        public void TestExceptions()
        {
            Rectangle a = new Rectangle();
            Assert.Throws<NullReferenceException>(() => a.Diagonal());

            double[] x = { 1, 1, 7 };
            double[] y = { 2, 10, 10, 2 };
            a = new Rectangle(x, y);
            Assert.Throws<ArgumentException>(() => a.Diagonal());

            y = new double[] { 3, 3, 3 };
            a.SetVertices(x, y);
            Assert.Throws<ArgumentException>(() => a.Diagonal());

            x = new double[] { 3, 3, 3, 3 };
            y = new double[] { 3, 3, 3, 3 };
            a.SetVertices(x, y);
            Assert.Throws<ArgumentException>(() => a.Diagonal());


            x = new double[] { 0, 0, 0, 0 };
            y = new double[] { 0, 0, 0, 0 };
            a.SetVertices(x, y);
            Assert.Throws<ArgumentException>(() => a.Diagonal());

            // 3 точки лежат на одной прямой
            x = new double[] { 2, 2, 2, 6 };
            y = new double[] { 1, 4, 3, 1 };
            a.SetVertices(x, y);
            Assert.Throws<ArgumentException>(() => a.Diagonal());
/*
            // квадрат
            x = new double[] { -1, 1, -1, 1 };
            y = new double[] { -1, 1, 1, -1 };
            a.SetVertices(x, y);
            Assert.Throws<ArgumentException>(() => a.Diagonal());
*/

            x = null;
            y = null;
            a.SetVertices(x, y);
            Assert.Throws<NullReferenceException>(() => a.Diagonal());
        }
    }
}