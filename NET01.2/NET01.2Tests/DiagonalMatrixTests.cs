using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET01._2.Math.Matrix;

namespace NET01._2Tests
{
    [TestClass]
    public class DiagonalMatrixTests
    {
        private DiagonalMatrix<int> filledTestDiagonalMatrix;
        private const int initialValue = 1;
        private const int size = 5;

        private const int setValue = 5;

        private bool callbackWasCalled;

        [TestInitialize]
        public void TestMatrixInitialize()
        {
            filledTestDiagonalMatrix = new DiagonalMatrix<int>(size, initialValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DiagonalMatrix_ZeroSize_Throws()
        {
            var testMatrix = new DiagonalMatrix<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DiagonalMatrix_NegativeSize_Throws()
        {
            var testMatrix = new DiagonalMatrix<int>(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DiagonalMatrixIndexersSet_IndexOutOfMainDiagonal_Throws()
        {
            filledTestDiagonalMatrix[size - 1, size - 2] = initialValue;
        }

        [TestMethod]
        public void DiagonalMatrixIndexersGet_IndexOutOfMainDiagonal_ReturnsDefault()
        {
            var defaultValue = default(int);

            var outOfDiagonalValue = filledTestDiagonalMatrix[size - 1, size - 2];

            Assert.AreEqual(defaultValue, outOfDiagonalValue);
        }

        [TestMethod]
        public void DiagonalMatrixIndexers_CorrectGetSet()
        {
            int i = size - 1;
            int j = size - 1;

            filledTestDiagonalMatrix[i, j] = setValue;

            Assert.AreEqual(setValue, filledTestDiagonalMatrix[i, j]);
        } 
    }
}
