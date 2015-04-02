using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET01._2.Math.UInt128;

namespace NET01._2Tests
{
    [TestClass]
    public class UInt128Tests
    {
        private UInt128 testUInt128A;
        private UInt128 testUInt128B;

        [TestInitialize]
        public void TestUintsInitialize()
        {
            testUInt128A = new UInt128();
            testUInt128B = new UInt128();
        }

        [TestMethod]
        public void Addiction_WithoutOverflow()
        {
            //arrange
            ulong lowerExpected = 2;
            ulong upperExpected = 2;

            testUInt128A.Lower = 1;
            testUInt128A.Upper = 1;

            testUInt128B.Lower = 1;
            testUInt128B.Upper = 1;

            //act
            var addictionResult = testUInt128A + testUInt128B;

            //assert
            Assert.AreEqual(upperExpected, addictionResult.Upper);
            Assert.AreEqual(lowerExpected, addictionResult.Lower);
        }

        [TestMethod]
        public void Addiction_WithLowerOverflow()
        {
            //arrange
            ulong lowerExpected = 0;
            ulong upperExpected = 1;

            testUInt128A.Lower = 1;
            testUInt128A.Upper = 0;

            testUInt128B.Lower = ulong.MaxValue;
            testUInt128B.Upper = 0;
            
            //act
            var addictionResult = testUInt128A + testUInt128B;

            //assert
            Assert.AreEqual(upperExpected, addictionResult.Upper);
            Assert.AreEqual(lowerExpected, addictionResult.Lower);
        }

        [TestMethod]
        public void Subtraction_WithoutOverflow()
        {
            //arrange
            ulong lowerExpected = 1;
            ulong upperExpected = 1;

            testUInt128A.Lower = 2;
            testUInt128A.Upper = 2;

            testUInt128B.Lower = 1;
            testUInt128B.Upper = 1;

            //act
            var addictionResult = testUInt128A - testUInt128B;

            //assert
            Assert.AreEqual(upperExpected, addictionResult.Upper);
            Assert.AreEqual(lowerExpected, addictionResult.Lower);
        }

        [TestMethod]
        public void Subtraction_WithLowerOverflow()
        {
            //arrange
            ulong lowerExpected = ulong.MaxValue;
            ulong upperExpected = ulong.MaxValue;

            testUInt128A.Lower = 0;
            testUInt128A.Upper = 0;

            testUInt128B.Lower = 1;
            testUInt128B.Upper = 0;

            //act
            var addictionResult = testUInt128A - testUInt128B;

            //assert
            Assert.AreEqual(upperExpected, addictionResult.Upper);
            Assert.AreEqual(lowerExpected, addictionResult.Lower);
        }

        [TestMethod]
        public void EqualToOperator_EqualNumbers()
        {
            testUInt128A.Lower = 0;
            testUInt128A.Upper = 0;

            testUInt128B.Lower = 0;
            testUInt128B.Upper = 0;

            Assert.IsTrue(testUInt128A == testUInt128B);
        }

        [TestMethod]
        public void NotEqualToOperator_EqualNumbers()
        {
            testUInt128A.Lower = 1;
            testUInt128A.Upper = 0;

            testUInt128B.Lower = 0;
            testUInt128B.Upper = 0;

            Assert.IsTrue(testUInt128A != testUInt128B);
        }

        [TestMethod]
        public void ImplicitCast_UlongToUint128()
        {
            ulong testUlongToCast = ulong.MaxValue;
            UInt128 testUint128ToCast;

            testUint128ToCast = testUlongToCast;

            Assert.AreEqual(testUlongToCast, testUint128ToCast.Lower);
        }

        [TestMethod]
        public void ExplicitCast_SmallEnoughUint128ToUlong()
        {
            ulong testUlongToCast;
            var testUint128ToCast = new UInt128
            {
                Lower = ulong.MaxValue
            };

            testUlongToCast = (ulong) testUint128ToCast;

            Assert.AreEqual(testUlongToCast, testUint128ToCast.Lower);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExplicitCast_TooBigUint128ToUlong()
        {
            ulong testUlongToCast;
            var testUint128ToCast = new UInt128
            {
                Lower = ulong.MaxValue,
                Upper = ulong.MaxValue
            };

            testUlongToCast = (ulong)testUint128ToCast;
        }
    }
}
