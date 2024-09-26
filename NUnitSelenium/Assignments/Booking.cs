using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace NUnitSelenium.Assignments
{
    internal class Booking
    {
        public EdgeDriver driver;


        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://www.booking.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]

        public void test()
        {
            Thread.Sleep(2000);

            IWebElement close = driver.FindElement(By.XPath("//button[@aria-label='Dismiss sign-in info.']"));
            close.Click();
            Thread.Sleep(1000);

            //Scroll
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,300)", "");
            Thread.Sleep(2000);

            IWebElement Destination = driver.FindElement(By.XPath("//input[@id=':rh:']"));
            Destination.Click();
            Thread.Sleep(1000);

            IWebElement Bangalore = driver.FindElement(By.XPath("//div[@class='a3332d346a d2f04c9037'][normalize-space()='Bangalore']"));
            Bangalore.Click();
            Thread.Sleep(2000);


            IWebElement Check_In_Check_Out = driver.FindElement(By.XPath("//div[@class='f73e6603bf']"));
            Check_In_Check_Out.Click();
            Thread.Sleep(2000);
/*


            IWebElement Check_In = driver.FindElement(By.XPath("//span[@aria-label='23 September 2024']"));
            Check_In.Click();
            Thread.Sleep(2000);

            //IWebElement Exact_Date = driver.FindElement(By.XPath("//span[contains(text(),'Exact dates')]"));
            //Exact_Date.Click();
            //Thread.Sleep(1000);

            IWebElement Check_Out = driver.FindElement(By.XPath("//span[@aria-label='25 September 2024']"));
            Check_Out.Click();
            Thread.Sleep(2000);
*/

            IWebElement Guest = driver.FindElement(By.XPath("//button[@class='a83ed08757 ebbedaf8ac dbaff8df6f ada2387af8']"));
            Guest.Click();
            Thread.Sleep(2000);

            IWebElement No_Of_Guest = driver.FindElement(By.XPath("(//button[@type='button'])[8]"));
            int numberOfClicks = 2;
            for (int i = 0; i < numberOfClicks; i++)
            {
                No_Of_Guest.Click();
                Thread.Sleep(1000);
            }
            No_Of_Guest.Click();
            Thread.Sleep(1000);

            IWebElement Done = driver.FindElement(By.XPath("//button[@class='a83ed08757 c21c56c305 bf0537ecb5 ab98298258 a2abacf76b af7297d90d c213355c26 b9fd3c6b3c']"));
            Done.Click();
            Thread.Sleep(1000);

            IWebElement Search = driver.FindElement(By.XPath("//button[@type='submit']"));
            Search.Click();
            Thread.Sleep(3000);


        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
