using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NET01._2.Math.Matrix;
using NET01._2.Math.UInt128;

namespace NET01._2
{
    class Program
    {
        private static bool wasCalled = false;

        private static void Main(string[] args)
        {
            //int size = 2;
            //int initialValue = 1;

            //var filledTestSquareMatrix = new SquareMatrix<int>(size, initialValue);

            ////direct method
            //filledTestSquareMatrix.MatrixChanged += TestCallback;

            ////anonymous method
            //filledTestSquareMatrix.MatrixChanged += delegate(object sender, MatrixChangedEventArgs<int> e)
            //{
            //    Console.WriteLine("Anonymous callback method was called with arguments value: {0}", e.Value);
            //};

            ////lambda expression
            //filledTestSquareMatrix.MatrixChanged +=
            //    ((sender, e) =>
            //        Console.WriteLine("Lambda callback expression was called with arguments value: {0}", e.Value));


            //filledTestSquareMatrix[size - 1, size - 1] = initialValue + 1;

            UIntTest();

            Console.ReadKey();
        }

        private static void UIntTest()
        {            
        }

        private static void TestCallback(object sender, MatrixChangedEventArgs<int> e)
        {
            Console.WriteLine("TestCallback method was called with arguments value: {0}", e.Value);
        }
    }
}
