using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QAE2ETesting.Pages;

public class BasePage
{
    protected IWebDriver Driver;
    protected WebDriverWait Wait;

    public BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    protected void ClickElement(By locator)
    {
        Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
    }

    protected void TypeText(By locator, string text)
    {
        var element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        element.Clear();
        element.SendKeys(text);
    }

    protected String GetText(By locator)
    {
        return Wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;
    }

}
    
    
    
    