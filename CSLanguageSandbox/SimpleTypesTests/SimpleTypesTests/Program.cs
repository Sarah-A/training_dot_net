using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTypesTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestArrays:
            //TestArrays.TestRectangularArray();
            //TestArrays.TestJaggedArray();

            //TestStaticInit:
            //Console.WriteLine("x = " + TestStaticInit.x.ToString());

            //TestPolyrphism:
            //TestPoly_BaseClass obj_base = new TestPoly_BaseClass();
            //TestPoly_Derv1 obj_drv1 = new TestPoly_Derv1();
            //TestPoly_Derv2 obj_drv2 = new TestPoly_Derv2();
            //Console.WriteLine(" Call with base object: ");
            //TestPoly(obj_base);
            //Console.WriteLine(" Call with drv1: ");
            //TestPoly(obj_drv1);
            //Console.WriteLine(" Call with drv2: ");
            //TestPoly(obj_drv2);

            // Test initialization order:
            //TestInitializationOrder_Drv obj_drv = new TestInitializationOrder_Drv(10);

            //TestFizzBall
            TestForLoop testLoop = new TestForLoop();
            testLoop.FizzBall();
        }

        static void TestPoly(TestPoly_BaseClass obj)
        {
            obj.ClassFunc();
        }
    }

    class TestStaticInit
    {
        public static int x = y;
        public static int y = 3;
        public static int z = 5;

        public static TestStaticInit Instance = new TestStaticInit();

        TestStaticInit()
        {
            Console.WriteLine("z = " + z.ToString());
        }
    }

    class TestArrays
    {
        public static void TestRectangularArray()
        {
            int[,] matrix = new int[3, 4];
            int[,] identicalMatrix = 
            {
                {0,1,2,3},
                {4,5,6,7},
                {8,9,10,11}
            };

            Console.WriteLine("\n Rectangular Array:\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            for (int i = 0; i < identicalMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < identicalMatrix.GetLength(1); j++)
                {
                    Console.Write(identicalMatrix[i, j] + ",");
                }
                Console.Write("\n");
            }

        }

        public static void TestJaggedArray()
        {
            int[][] matrix = new int[3][];
            int[][] identicalMatrix = new int[][]
            {
                new int[] {0},
                new int[] {1,2},
                new int[] {3,4,5}
            };

            Console.WriteLine("\n Jagged Array:\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            for (int i = 0; i < identicalMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < identicalMatrix[i].GetLength(0); j++)
                {
                    Console.Write(identicalMatrix[i][j] + ",");
                }
                Console.Write("\n");
            }

        }
    }
}
