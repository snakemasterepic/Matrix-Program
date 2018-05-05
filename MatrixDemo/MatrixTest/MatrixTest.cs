using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixDemo.RTW;

/// <summary>
/// Tests for the MatrixDemo.
/// </summary>
namespace MatrixTest
{
    /// <summary>
    /// Runs unit tests for Matrix.
    /// </summary>
    [TestClass]
    public class MatrixTest
    {
        /// <summary>
        /// Tests indexing with valid indexes.
        /// </summary>
        [TestMethod]
        public void TestIndex()
        {
            Matrix m1 = new Matrix(3, 2);
            m1[2, 1] = 1;
            m1[0, 0] = 4;

            //Testing Push capability. Trial #5 -- Adam
            MatrixTest m5 = new MatrixTest(4, 2);
        }

        /// <summary>
        /// Tests to ensure that invalid indexes throw exceptions.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestBadIndex()
        {
            Matrix m1 = new Matrix(3, 2);
            m1[3, 1] = 0;
        }

        /// <summary>
        /// Tests the backing of <see cref="MatrixDemo.RTW.Matrix.Matrix(double[,])"/>, <see cref="MatrixDemo.RTW.Matrix.GetEntries()"/>, <see cref="MatrixDemo.RTW.Matrix.operator double[,]"/>, and <see cref="MatrixDemo.RTW.Matrix.operator Matrix"/>.
        /// </summary>
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
