using OpenQA.Selenium;

namespace QAE2ETesting.Pages;

public class SignUpLoginPage : BasePage
{
    private readonly By _signUpName = By.CssSelector("[data-qa='signup-name']");
    private readonly By _signUpEmail = By.CssSelector("[data-qa='signup-email']");
    private readonly By _signUpButton = By.CssSelector("[data-qa='signup-button']");
    private readonly By _loginName = By.CssSelector("[data-qa='login-name']");
    private readonly By _loginpassword = By.CssSelector("[data-qa='password']");
    private readonly By _loginButton = By.CssSelector("[data-qa='login-button']");
    private readonly By _NewAccountSignUpHeading = By.XPath("//h2[normalize-space()='New User Signup!']");

    public SignUpLoginPage(IWebDriver driver) : base(driver)
    {
        
    }

    public void TypeSignUpNameAndEmail(string name,string email)
    {
        TypeText(_signUpName, name);
        TypeText(_signUpEmail, email);
    }

    public void ClickSignUpButton()
    {
        ClickElement(_signUpButton);
    }
    
    public void TypeLoginNameAndPassword(string name,string password)
    {
        TypeText(_loginName, name);
        TypeText(_loginpassword, password);
    }
    
    public void ClickLoginButton()
    {
        ClickElement(_loginButton);
    }

    public string GetNewAccountSignUpHeading()
    {
        return GetText(_NewAccountSignUpHeading);
    }
    
}