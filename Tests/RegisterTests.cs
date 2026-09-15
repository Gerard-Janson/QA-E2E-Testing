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
        driver.Navigate().GoToUrl("https://www.automationexercise.com/");
        var title = driver.Title;
        Assert.AreEqual("Automation Exercise", title);
        HomePage homePage = new HomePage(driver);
        homePage.ClickLoginLink();
        SignUpLoginPage signUpLoginPage = new SignUpLoginPage(driver);
        var actualText = signUpLoginPage.GetNewAccountSignUpHeading();
        Assert.That(actualText,Is.EqualTo("New User Signup!"));
        signUpLoginPage.TypeSignUpNameAndEmail("Gerard Janson","gerardjanson@gmail.com");
        signUpLoginPage.ClickSignUpButton();
        AccountInformationPage accountInformationPage = new AccountInformationPage(driver);
        var actualHeading =  accountInformationPage.GetAccountInformationHeading();
        Assert.That(actualHeading,Is.EqualTo("ENTER ACCOUNT INFORMATION"));
        accountInformationPage.SelectTitle("Mr");
        accountInformationPage.EnterPassword("gerjan012@");
        accountInformationPage.SelectDateOfBirth("5","November","1998");
        accountInformationPage.SetNewsletterSubscription(true);
        accountInformationPage.SetSpecialOfferSubscription(true);
        accountInformationPage.EnterAddressDetails("Gerard","Janson","N/A","13 Klarinet Lane"," ","India","Mumbai","Mumbai","5966","029455677");
        accountInformationPage.ClickCreateAccountButton();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}