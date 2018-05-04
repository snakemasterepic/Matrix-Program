using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixDemo.RTW;

namespace MatrixTest
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestIndex()
        {
            Matrix m1 = new Matrix(3, 2);
            m1[2, 1] = 1;
            m1[0, 0] = 4;

            //Testing Push capability. Trial #5 -- Adam
            MatrixTest m5 = new MatrixTest(4, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestBadIndex()
        {
            Matrix m1 = new Matrix(3, 2);
            m1[3, 1] = 0;
        }

        [TestMethod]
        public void TestBacking()
        {
            double[,] d = new double[4, 2];
            d[1, 0] = 2.5;
            d[3, 1] = 1.5;
            Matrix m1 = new Matrix(d);
            m1[3, 0] = 4;
            d[2, 1] = 1.5;
            Assert.AreEqual(2.5, m1[1, 0]);
            Assert.AreEqual(1.5, m1[3, 1]);
            Assert.AreEqual(0, d[3, 0]);
            Assert.AreEqual(4, m1[3, 0]);
            Assert.AreEqual(0, m1[2, 1]);
            double[,] d2 = m1;
            d2[0, 0] = 1;
            Assert.AreEqual(1, m1[0, 0]);
            m1[1, 1] = -1;
            Assert.AreEqual(-1, d2[1, 1]);
            Matrix m2 = d2;
            m2[0, 1] = -2.5;
            Assert.AreEqual(-2.5, d2[0, 1]);
            d2[1, 0] = 1;
            Assert.AreEqual(1, m2[1, 0]);
        }

    }
}
