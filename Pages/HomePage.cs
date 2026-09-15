using OpenQA.Selenium;

namespace QAE2ETesting.Pages;

public class HomePage : BasePage
{
    protected IWebDriver driver;
    private readonly By _LoginLink = By.CssSelector("a[href='/login']");
    
    public HomePage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }
    
    
    public void ClickLoginLink()
    {
        ClickElement(_LoginLink);
    }
}