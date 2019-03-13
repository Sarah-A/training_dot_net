using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Delegates
{
    public delegate int IntManipulator(ref int x);
    public delegate void ContraVariantDelegate_PrintAnimal(Animal animal);
    public delegate void ContraVariantDelegate_PrintLion(Lion lion);
    public delegate Animal CoVariantDelegate_GetAnimal();
    public delegate Lion CoVariantDelegate_GetLion();

    class Program
    {        

        static void Main(string[] args)
        {
            //TestBasicDelegates();
            TestDelegatesCovariance();           

        }

        static void TestDelegatesCovariance()
        {            
            Animal genericRef;
            Zoo zoo = new Zoo();

            Console.WriteLine("Testing polymorphism:");

            genericRef = zoo.GetAnimal();
            genericRef.PrintName();
            genericRef = zoo.GetLion();
            genericRef.PrintName();
            genericRef = zoo.GetGiraffe();
            genericRef.PrintName();

            Console.WriteLine("Testing Convariance:");

            //*********************************************************************************
            // Testing ConVariance
            //*********************************************************************************
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Testing CoVariance");
            Console.WriteLine("************************************************************************************");
            // the following line is illegal because GetLion is supposed to return Lion but instead returns animal
            Console.WriteLine("\n Illegal - delegate is expected to RETURN subclass but instead returns base.");
            //CoVariantDelegate_GetLion cdGetLion = zoo.GetAnimal;


            Console.WriteLine("\n Valid - delegate is expected to RETURN the base but instead returns subclass");
            CoVariantDelegate_GetAnimal cdGetAnimal = zoo.GetAnimal;
            genericRef = cdGetAnimal();
            genericRef.PrintName();
            
            Console.WriteLine("Now added GetLion to GetAnimal");
            cdGetAnimal += zoo.GetLion;
            genericRef = cdGetAnimal();
            genericRef.PrintName();

            //*********************************************************************************
            // Testing ContraVariant
            //*********************************************************************************
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Testing ContraVariance");
            Console.WriteLine("************************************************************************************");

            // the following line is illegal because PrintLion expects to get Lion and we can send
            // animal to it.
            Console.WriteLine("\n Illegal - delegate expects base and initialized with subclass PARAMETER");
            //ContraVariantDelegate_PrintAnimal cd = zoo.PrintLion;
            // cd(zoo.GetAnimal) - will call PrintLion and will call roar on a squirrel!
            

            Console.WriteLine("\n Valid - delegate expects subclass and initialized with base PARAMETER");
            ContraVariantDelegate_PrintLion cdLion = zoo.PrintLion;
            genericRef = zoo.GetLion();
            cdLion((Lion)genericRef);
            Console.WriteLine("Now added PrintAnimal to PrintLion");
            cdLion += zoo.PrintAnimal;
            cdLion((Lion)genericRef);
                    
        }

        
        static void TestBasicDelegates()
        {
            int[] vals = { 1, 2, 3, 4, 5 };
            HelperFunctions h = new HelperFunctions();
            IntManipulator d = null;

            Console.WriteLine("************************************************************************************");
            Console.WriteLine(" Testing Basic Delegates:");
            Console.WriteLine("************************************************************************************");

            Console.WriteLine("With null delegate:");
            HelperFunctions.ManipulateAndPrint(vals, d);

            Console.WriteLine("With one delegate:");
            HelperFunctions.ManipulateAndPrint(vals, Square);

            d += Square;
            d += Double;
            d += Half;
            Console.WriteLine("With three delegate:");
            HelperFunctions.ManipulateAndPrint(vals, d);

            d -= Double;
            Console.WriteLine("With two delegate:");
            HelperFunctions.ManipulateAndPrint(vals, d);
        }


        static int Square(ref int x)
        {
            Console.Write("Before Square: " + x + " - ");
            x = (int)(Math.Pow(x, 2));
            Console.Write("After: " + x + ", ");
            return x;
        }

        public static int Double(ref int x)
        {
            Console.Write("Before Double: " + x + " - ");
            x = (x * 2);
            Console.Write("After: " + x + ", ");
            return x;

        }

        public static int Half(ref int x)
        {
            Console.Write("Before Half: " + x + " - ");
            x = (x / 2);
            Console.Write("After: " + x + ", ");
            return x;
        }

        public int NonStaticVal(ref int x)
        {
            Console.Write("Before NonStaticVal: " + x + " - ");
            Console.Write("After: " + x + ", ");
            return x;
        }
    }
}
