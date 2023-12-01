using AdventOfCode2023;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.Tests;

[TestFixture]
public class Day1Fixture
{
    [Test]
    public void CalculateTestValues()
    {
        var day1 = new Day1_CalibrationValues();
        var result = day1.Calculate(
            "C:\\MyFiles\\Training\\my-github-dot-net-training\\AdventOfCode\\AdventOfCode2023\\AdventOfCode2023\\Tests\\TestData\\test-data-day1.txt");
        result.Should().Be(319);

    }
}