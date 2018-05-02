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
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestBadIndex()
        {
            Matrix m1 = new Matrix(3, 2);
            m1[3, 1] = 0;
        }

    }
}
