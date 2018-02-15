using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
	class NUnitTest
	{
		private IWebDriver _driver;

		[SetUp]
		public void Initialize()
		{
			_driver = new ChromeDriver();
		}

		[Test]
		public void OpenTestApp()
		{
			_driver.Url = "https://startcom.pro/lk/login/";
			//var loginBtn = _driver.FindElement(By.LinkText("/lk/login/"));
			//loginBtn.Click();
			//_driver.Navigate().GoToUrl("/lk/login/"); ///lk/?page=deposits
			while (!_driver.FindElements(By.Name("login")).Any())
			{
				Thread.Sleep(1000);
			}
			_driver.FindElement(By.Name("login")).SendKeys("Avdarya");
			Thread.Sleep(1000);
			_driver.FindElement(By.Name("qiwi")).SendKeys("avdeenko1994d");
			Thread.Sleep(1000);
			_driver.FindElement(By.Id("sign_in")).Submit();
			Thread.Sleep(1000);
			_driver.Navigate().GoToUrl("https://startcom.pro/lk/?page=deposits");
			try
			{
				_driver.FindElement(By.CssSelector("button.close")).Click();
				Thread.Sleep(2000);
			}
			catch (Exception)
			{
				Thread.Sleep(2000);
			}
			

			_driver.FindElement(By.ClassName("card-block")).Click();
			var funds = _driver.FindElement(By.CssSelector("#pills-vertical-1 div.center h1")).Text;
			var amount = Convert.ToInt32(funds.Split('.')[0]);
			
			if (amount >= 0)
			{
				_driver.FindElement(By.CssSelector("#pills-vertical-1 #vklad_sum")).SendKeys(amount.ToString());
				_driver.FindElement(By.CssSelector("#pills-vertical-1 #vklad_form")).Submit();
				if (_driver.FindElements(By.CssSelector("div.showSweetAlert.visible h2")).Any())
				{
					var alertText = _driver.FindElement(By.CssSelector("div.showSweetAlert.visible h2")).Text;
				}
			}
			Thread.Sleep(5000);

		}

		[TearDown]
		public void EndTest()
		{
			_driver.Close();
		}
	}
}
