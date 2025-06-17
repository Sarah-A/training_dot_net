using AdventOfCode2023;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests;

[TestFixture]
public class Day1Fixture
{
    [Test]
    public void CalculateTestValues_Q1()
    {
        var q1 = new Day1_CalibrationValues();
        var result = q1.Calculate_Q1(
            "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode_2023\\UnitTests\\TestData\\test-data-Q1.txt");
        result.Should().Be(319);

    }
    
    [Test]
    public void CalculateFinalValues_Q1()
    {
        var q1 = new Day1_CalibrationValues();
        var result = q1.Calculate_Q1(
            "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode_2023\\AdventOfCode_2023\\Data\\Q1.txt");
        Console.WriteLine($"Result for submission: {result}");

    }
    
    [Test]
    public void CalculateTestValues_Q2()
    {
        var q1 = new Day1_CalibrationValues();
        var result = q1.Calculate_Q2(
            "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode_2023\\UnitTests\\TestData\\test-data-Q2.txt");
        result.Should().Be(281);

    }
    
    [Test]
    public void CalculateFinalValues_Q2()
    {
        var q1 = new Day1_CalibrationValues();
        var result = q1.Calculate_Q2(
            "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode_2023\\AdventOfCode_2023\\Data\\Q1.txt");
        Console.WriteLine($"Result for submission: {result}");

    }
}