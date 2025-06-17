// See https://aka.ms/new-console-template for more information

using AsynPrograming;

Console.WriteLine("Hello, World!");

Console.WriteLine("Throw before the await:");
TestAsycExceptions.Test(true);


Console.WriteLine("Throw after the await:");
TestAsycExceptions.Test(false);