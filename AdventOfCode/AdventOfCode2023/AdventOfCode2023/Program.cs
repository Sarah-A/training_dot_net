// See https://aka.ms/new-console-template for more information

using AdventOfCode2023;

Console.WriteLine("Hello, World!");

var day1 = new Day1_CalibrationValues();
var result = day1.Calculate(
    "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode2023\\UnitTests\\TestData\\test-data-day1.txt");
Console.WriteLine($"expected: 319. received: {result}");


result = day1.Calculate(
    "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode2023\\AdventOfCode2023\\Data\\day1.txt");
Console.WriteLine($"Result for submission: {result}");
    