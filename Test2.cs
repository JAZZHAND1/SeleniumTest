using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"D:\Software\Chromedriver");
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");
            driver.FindElement(By.XPath("//div[@id='divUsername']/span")).Click();
            driver.FindElement(By.Id("txtUsername")).Clear();
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("frmLogin")).Click();
            driver.FindElement(By.Id("txtPassword")).Click();
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            driver.FindElement(By.Id("btnLogin")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(By.Id("branding")).Click();
            driver.FindElement(By.Id("welcome")).Click();
            driver.FindElement(By.Id("aboutDisplayLink")).Click();
            driver.FindElement(By.LinkText("×")).Click();
            driver.FindElement(By.XPath("//a[@id='menu_directory_viewDirectory']/b")).Click();
            driver.FindElement(By.XPath("//a[@id='menu_admin_viewAdminModule']/b")).Click();
            driver.FindElement(By.Id("searchSystemUser_userName")).Click();
            driver.FindElement(By.Id("searchSystemUser_userName")).Clear();
            driver.FindElement(By.Id("searchSystemUser_userName")).SendKeys("Alan");
            driver.FindElement(By.Id("searchBtn")).Click();
            driver.FindElement(By.Id("menu_pim_viewEmployeeList")).Click();
            driver.FindElement(By.Id("empsearch_employee_name_empName")).Click();
            driver.FindElement(By.Id("empsearch_employee_name_empName")).Clear();
            driver.FindElement(By.Id("empsearch_employee_name_empName")).SendKeys("Alan");
            driver.FindElement(By.XPath("//a[@id='menu_time_viewTimeModule']/b")).Click();
            driver.FindElement(By.Id("welcome")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

