using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace se_builder {
  [TestFixture()]
  public class CreateEditMR {
    [Test()]
    public void TestCase() {
      IWebDriver wd = new RemoteWebDriver(DesiredCapabilities.Firefox());
      try {
        wd.Navigate().GoToUrl("http://dev.apartmentapps.com/MaitenanceRequests/NewRequest");
        if (!wd.FindElement(By.XPath("//select[@id='UnitId']//option[4]")).Selected) {
            wd.FindElement(By.XPath("//select[@id='UnitId']//option[4]")).Click();
        }
        if (!wd.FindElement(By.XPath("//select[@id='MaitenanceRequestTypeId']//option[10]")).Selected) {
            wd.FindElement(By.XPath("//select[@id='MaitenanceRequestTypeId']//option[10]")).Click();
        }
        if (!wd.FindElement(By.Id("PermissionToEnter")).Selected) {
            wd.FindElement(By.Id("PermissionToEnter")).Click();
        }
        wd.FindElement(By.XPath("//div[@class='btn-group']/label[2]")).Click();
        wd.FindElement(By.Id("Comments")).Click();
        wd.FindElement(By.Id("Comments")).Clear();
        wd.FindElement(By.Id("Comments")).SendKeys("Selenium Test Request");
        wd.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
        wd.FindElement(By.LinkText("Edit")).Click();
        wd.FindElement(By.Id("Comments")).Click();
        wd.FindElement(By.Id("Comments")).Clear();
        wd.FindElement(By.Id("Comments")).SendKeys("Selenium Test Requests");
        wd.FindElement(By.XPath("//div[@class='modal-footer']/input")).Click();
      } finally { wd.Quit(); }
    }
  }
}
