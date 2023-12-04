using AdventOfCode2023;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests;

[TestFixture]
public class Q1Fixture
{
    [Test]
    public void CalculateTestValues()
    {
        var q1 = new Day1_CalibrationValues();
        var result = q1.Calculate_Q1(
            "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode_2023\\UnitTests\\TestData\\test-data-Q1.txt");
        result.Should().Be(319);

    }

    [Test]
    public void CalculateFinalValues()
    {
        var q1 = new Day1_CalibrationValues();
        var result = q1.Calculate_Q1(
            "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode_2023\\AdventOfCode_2023\\Data\\Q1.txt");
        Console.WriteLine($"Result for submission: {result}");

    }
}