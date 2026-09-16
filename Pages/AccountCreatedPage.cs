using OpenQA.Selenium;

namespace QAE2ETesting.Pages;

public class AccountCreatedPage : BasePage
{

    private readonly By _accountCreatedHeading = By.XPath("//h2[normalize-space()='Account Created!']");
    private readonly By _continueButton = By.CssSelector("[data-qa='continue-button']");
	
    
    public AccountCreatedPage(IWebDriver driver) : base(driver)
    {
    }
    
    public string GetAccountCreatedHeading()
    {
        return GetText(_accountCreatedHeading);
    }

    public void ClickContinueButton()
    {
        ClickElement(_continueButton);
    }
}