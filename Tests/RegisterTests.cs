using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAE2ETesting.Pages;

namespace QAE2ETesting.Tests;

public class RegisterTests
{
    private IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void TestCase1()
    {
        string uniqueId = Guid.NewGuid().ToString("N")[..8]; 
        string name = $"Gerard{uniqueId}"; 
        string email = $"gerard{uniqueId}@gmail.com";
        driver.Navigate().GoToUrl("https://www.automationexercise.com/");
        var title = driver.Title;
        Assert.AreEqual("Automation Exercise", title);
        HomePage homePage = new HomePage(driver);
        homePage.ClickLoginLink();
        SignUpLoginPage signUpLoginPage = new SignUpLoginPage(driver);
        var actualText = signUpLoginPage.GetNewAccountSignUpHeading();
        Assert.That(actualText,Is.EqualTo("New User Signup!"));
        signUpLoginPage.TypeSignUpNameAndEmail(name,email);
        signUpLoginPage.ClickSignUpButton();
        AccountInformationPage accountInformationPage = new AccountInformationPage(driver);
        var actualHeading =  accountInformationPage.GetAccountInformationHeading();
        Assert.That(actualHeading,Is.EqualTo("ENTER ACCOUNT INFORMATION"));
        accountInformationPage.SelectTitle("Mr");
        accountInformationPage.EnterPassword("gerjan012@");
        accountInformationPage.SelectDateOfBirth("5","November","1998");
        accountInformationPage.SetNewsletterSubscription(true);
        accountInformationPage.SetSpecialOfferSubscription(true);
        accountInformationPage.EnterAddressDetails("Gerard","Johnson","N/A","707 Washington Blvd"," ","United States","CT","Stamford","06901","029455677");
        accountInformationPage.ClickCreateAccountButton();
        AccountCreatedPage accountCreatedPage = new AccountCreatedPage(driver);
        var newHeading = accountCreatedPage.GetAccountCreatedHeading();
        Assert.That(newHeading, Is.EqualTo("ACCOUNT CREATED!"));
        accountCreatedPage.ClickContinueButton();
        var loginText = homePage.LoginStatusText;
        Assert.That(loginText, Does.Contain("Logged in as"));
        homePage.ClickDeleteAccountLink();
        


    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}