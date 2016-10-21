using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace se_builder {
  public class Login {
    static void Main(string[] args) {
      IWebDriver wd = new RemoteWebDriver(DesiredCapabilities.Firefox());
      try {
        var wait = new WebDriverWait(wd, TimeSpan.FromSeconds(60));
        wd.Navigate().GoToUrl("http://dev.apartmentapps.com/Account/Login");
        wd.FindElement(By.Id("Email")).Click();
        wd.FindElement(By.Id("Email")).Clear();
        wd.FindElement(By.Id("Email")).SendKeys("micahosborne@gmail.com");
        wd.FindElement(By.Id("Password")).Click();
        wd.FindElement(By.Id("Password")).Clear();
        wd.FindElement(By.Id("Password")).SendKeys("micah123");
        wd.FindElement(By.XPath("//form[@id='form0']/div[5]/input")).Click();
      } finally { wd.Quit(); }
    }
    
    public static bool isAlertPresent(IWebDriver wd) {
        try {
            wd.SwitchTo().Alert();
            return true;
        } catch (NoAlertPresentException e) {
            return false;
        }
    }
  }
}
