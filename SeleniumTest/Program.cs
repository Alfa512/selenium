﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
	class Program
	{
		static void Main(string[] args)
		{
			IWebDriver driver = new ChromeDriver();
			driver.Url = "https://startcom.pro";

		}
	}
}
