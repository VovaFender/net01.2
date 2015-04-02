using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET01._2.Math.Matrix;

namespace NET01._2Tests
{
    [TestClass]
    public class SquareMatrixTests
    {
        private SquareMatrix<int> filledTestSquareMatrix;
        private const int initialValue = 1;
        private const int size = 3;

        private const int setValue = 5;

        private bool callbackWasCalled;

        [TestInitialize]
        public void TestMatrixInitialize()
        {
            filledTestSquareMatrix = new SquareMatrix<int>(size, initialValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareMatrix_ZeroSize_Throws()
        {
            var testMatrix = new SquareMatrix<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareMatrix_NegativeSize_Throws()
        {
            var testMatrix = new SquareMatrix<int>(-1);
        }

        [TestMethod]
        public void SquareMatrixIndexers_CorrectGetSet()
        {            
            int i = size - 1;
            int j = size - 1;

            filledTestSquareMatrix[i, j] = setValue;

            Assert.AreEqual(setValue, filledTestSquareMatrix[i, j]);

        }

        [TestMethod]
        public void MatrixChanged_OnMatrixChangeEvent_EventNotRaised()
        {
            callbackWasCalled = false;
            filledTestSquareMatrix.MatrixChanged += TestEventCallback;
            int i = size - 1;
            int j = size - 1;

            filledTestSquareMatrix[i, j] = initialValue;

            Assert.IsFalse(callbackWasCalled);
        }

        [TestMethod]
        public void MatrixChanged_OnMatrixChangeEvent_EventRaised()
        {
            callbackWasCalled = false;
            filledTestSquareMatrix.MatrixChanged += TestEventCallback;
            int i = size - 1;
            int j = size - 1;

            filledTestSquareMatrix[i, j] = setValue;

            Assert.IsTrue(callbackWasCalled);
        }

        private void TestEventCallback(object sender, MatrixChangedEventArgs<int> e)
        {
            callbackWasCalled = true;
        }

        [TestMethod]
        public void MatrixChanged_OnMatrixChangeEvent_EventArguments()
        {
            callbackWasCalled = false;
            filledTestSquareMatrix.MatrixChanged += TestEventArgumentsCallback;
            int i = size - 1;
            int j = size - 1;

            filledTestSquareMatrix[i, j] = setValue;

            Assert.IsTrue(callbackWasCalled);
        }

        private void TestEventArgumentsCallback(object sender, MatrixChangedEventArgs<int> e)
        {
            if (e.Value == setValue)
                callbackWasCalled = true;
        }

    }
}
