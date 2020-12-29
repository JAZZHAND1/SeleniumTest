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
    public class Test3
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
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.FindElement(By.XPath("//div[@id='divUsername']/span")).Click();
            driver.FindElement(By.Id("txtUsername")).Clear();
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("frmLogin")).Click();
            driver.FindElement(By.Id("txtPassword")).Click();
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            driver.FindElement(By.Id("btnLogin")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(By.Id("menu_admin_viewSystemUsers")).Click();
            driver.FindElement(By.Id("btnAdd")).Click();
            driver.FindElement(By.Id("systemUser_userType")).Click();
            driver.FindElement(By.Id("systemUser_userType")).Click();
            driver.FindElement(By.Id("systemUser_employeeName_empName")).Click();
            driver.FindElement(By.Id("systemUser_employeeName_empName")).Clear();
            driver.FindElement(By.Id("systemUser_employeeName_empName")).SendKeys("Yoshida");
            driver.FindElement(By.Id("frmSystemUser")).Submit();
            driver.FindElement(By.Id("systemUser_userName")).Click();
            driver.FindElement(By.Id("systemUser_userName")).Clear();
            driver.FindElement(By.Id("systemUser_userName")).SendKeys("Slimani");
            driver.FindElement(By.XPath("//form[@id='frmSystemUser']/fieldset/ol")).Click();
            driver.FindElement(By.Id("systemUser_status")).Click();
            driver.FindElement(By.Id("systemUser_status")).Click();
            driver.FindElement(By.Id("systemUser_password")).Click();
            driver.FindElement(By.Id("systemUser_password")).Clear();
            driver.FindElement(By.Id("systemUser_password")).SendKeys("11111111");
            driver.FindElement(By.Id("systemUser_confirmPassword")).Click();
            driver.FindElement(By.Id("systemUser_confirmPassword")).Clear();
            driver.FindElement(By.Id("systemUser_confirmPassword")).SendKeys("11111111");
            driver.FindElement(By.Id("btnSave")).Click();
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
