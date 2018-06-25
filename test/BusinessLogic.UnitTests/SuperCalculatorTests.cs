using System;
using Xunit;

namespace BusinessLogic.UnitTests
{
    public class SuperCalculatorTests
    {
        [Theory]
		[InlineData(2, 2, 4)]
		[InlineData(5, 5, 10)]
		[InlineData(20, -3, 17)]
		public void AddTheory(int a, int b, int expectedAnswer)
        {
			SuperCalculator calc = new SuperCalculator();

			int answer = calc.Add(a, b);

			Assert.Equal(expectedAnswer, answer);
        }
    }
}
