using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace NUnitSelenium.Assignments
{
    [Allure.NUnit.AllureNUnit]
    [TestFixture, Category("Parabank Website Testing...")]
    internal class ParaBank
    {
        ChromeDriver driver;

        [SetUp]
        public void setUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.html");
            driver.Manage().Window.Maximize();
        }

        [Test, Category("Registration test"), Order(1)]

        public void RegristrationBank()
        {
            Thread.Sleep(1000);
            IWebElement Register = driver.FindElement(By.XPath("//a[normalize-space()='Register']"));
            Register.Click();
            Thread.Sleep(1000);

            IWebElement FirstName = driver.FindElement(By.Id("customer.firstName"));
            FirstName.SendKeys("Rammu");
            Thread.Sleep(1000);

            IWebElement LastName = driver.FindElement(By.Id("customer.lastName"));
            LastName.SendKeys("Bhat");
            Thread.Sleep(1000);

            IWebElement Address = driver.FindElement(By.Id("customer.address.street"));
            Address.SendKeys("Kadri");
            Thread.Sleep(1000);

            IWebElement City = driver.FindElement(By.Id("customer.address.city"));
            City.SendKeys("Mangalore");
            Thread.Sleep(1000);

            IWebElement State = driver.FindElement(By.Id("customer.address.state"));
            State.SendKeys("Karnataka");
            Thread.Sleep(1000);

            IWebElement ZipCode = driver.FindElement(By.Id("customer.address.zipCode"));
            ZipCode.SendKeys("575003");
            Thread.Sleep(1000);

            IWebElement Ph_No = driver.FindElement(By.Id("customer.phoneNumber"));
            Ph_No.SendKeys("100");
            Thread.Sleep(1000);

            IWebElement SSN = driver.FindElement(By.Id("customer.ssn"));
            SSN.SendKeys("1234567890");
            Thread.Sleep(1000);


            IWebElement username = driver.FindElement(By.Id("customer.username"));
            username.SendKeys("Rammu_Bhat");
            Thread.Sleep(1000);

            IWebElement password = driver.FindElement(By.Id("customer.password"));
            password.SendKeys("Manniya");
            Thread.Sleep(1000);

            IWebElement Confirm = driver.FindElement(By.Id("repeatedPassword"));
            Confirm.SendKeys("Manniya");
            Thread.Sleep(2000);

            IWebElement Registered = driver.FindElement(By.XPath("//input[@value='Register']"));
            Registered.Click();
            Thread.Sleep(3000);

            try 
            {
                IWebElement success = driver.FindElement(By.XPath("//span[@id='customer.username.errors']"));
                Console.WriteLine("Account Created Successfully");

                Assert.That(success.Text, Is.EqualTo("This username already exists."));
            } 
            catch
            {
                Console.WriteLine("User Already Exist");
            }
            Thread.Sleep(2000);
        }

        [Test, Category("Login Test"), Order(2)]

        public void LoginBank()
        {
            IWebElement Login_username = driver.FindElement(By.XPath("//input[@name='username']"));
            Login_username.SendKeys("Rammu_Bhat");
            Thread.Sleep(1000);

            IWebElement Login_password = driver.FindElement(By.XPath("//input[@name='password']"));
            Login_password.SendKeys("Manniya");
            Thread.Sleep(3000);

            IWebElement Login = driver.FindElement(By.XPath("//input[@value='Log In']"));
            Login.Click();
            Thread.Sleep(3000);


        }


        [TearDown]

        public void tearDown()
        {
            driver.Close();
        }
    }
}
