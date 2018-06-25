using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Website.UITests
{
    public class UIDemoTests
    {
        [Theory]
		[InlineData(2, 2, 4)]
		[InlineData(5, 5, 10)]
		[InlineData(20, -3, 17)]
		public void CalcualtorDemo(int a, int b, int expectedAnswer)
        {
			using (IWebDriver driver = GetChromeDriver(true))
			{
				driver.Navigate().GoToUrl("https://ui.scott.ms/");
				driver.FindElement(By.Id("InputA")).SendKeys(a.ToString());
				driver.FindElement(By.Id("InputB")).SendKeys(b.ToString());

				driver.FindElement(By.Id("Calculate")).Click();

				string answerString = driver.FindElement(By.Id("Answer")).GetAttribute("value");

				Assert.True(int.TryParse(answerString, out int answer), "Answer was not an integer");
				Assert.Equal(expectedAnswer, answer);
			}

        }

		private static IWebDriver GetChromeDriver(bool headless)
		{
			ChromeOptions options = new ChromeOptions();

			if (headless)
			{
				options.AddArgument("--headless");
				options.AddArgument("--disable-gpu");
				options.AddArgument("window-size=1400,600");
			}

			return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
		}
	}
}
