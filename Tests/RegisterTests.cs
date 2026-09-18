using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAE2ETesting.Pages;

namespace QAE2ETesting.Tests;

public class RegisterTests : BaseTest
{
    [Test]
    // Test Case 1: Register User
    public void TestCase1()
    {
        string uniqueId = Guid.NewGuid().ToString("N")[..8]; 
        string name = $"Gerard{uniqueId}"; 
        string email = $"gerard{uniqueId}@gmail.com";
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
        AccountDeletedPage accountDeletedPage = new AccountDeletedPage(driver);
        var deletedHeading = accountDeletedPage.GetAccountDeletedHeading();
        Assert.That(deletedHeading, Is.EqualTo("ACCOUNT DELETED!"));
        accountDeletedPage.ClickContinueButton();
    }
    
        [Test]
    //Test Case 5: Register User with existing email
    public void TestCase5()
    {
        string uniqueId = Guid.NewGuid().ToString("N")[..8];
        string name = $"Gerard{uniqueId}";
        string email = $"gerard{uniqueId}@gmail.com";
        HomePage homePage = new HomePage(driver);
        homePage.ClickLoginLink();
        SignUpLoginPage signUpLoginPage = new SignUpLoginPage(driver);
        var actualText = signUpLoginPage.GetNewAccountSignUpHeading();
        Assert.That(actualText,Is.EqualTo("New User Signup!"));

        signUpLoginPage.TypeSignUpNameAndEmail(name,email);
        signUpLoginPage.ClickSignUpButton();
        AccountInformationPage accountInformationPage = new AccountInformationPage(driver);
        accountInformationPage.SelectTitle("Mr");
        accountInformationPage.EnterPassword("gerjan012@");
        accountInformationPage.SelectDateOfBirth("5","November","1998");
        accountInformationPage.SetNewsletterSubscription(true);
        accountInformationPage.SetSpecialOfferSubscription(true);
        accountInformationPage.EnterAddressDetails("Gerard","Johnson","N/A","707 Washington Blvd"," ","United States","CT","Stamford","06901","029455677");
        accountInformationPage.ClickCreateAccountButton();
        AccountCreatedPage accountCreatedPage = new AccountCreatedPage(driver);
        accountCreatedPage.ClickContinueButton();
        homePage.ClickLogoutLink();
        
        SignUpLoginPage secondSignUpAttempt = new SignUpLoginPage(driver);
        secondSignUpAttempt.TypeSignUpNameAndEmail(name,email);
        secondSignUpAttempt.ClickSignUpButton();
        var signUpError = secondSignUpAttempt.GetLoginErrorMessage();
        Assert.That(signUpError,Is.EqualTo("Email Address already exist!"));
        
        secondSignUpAttempt.TypeLoginNameAndPassword(email,"gerjan012@");
        secondSignUpAttempt.ClickLoginButton();
        homePage.ClickDeleteAccountLink();
        AccountDeletedPage accountDeletedPage = new AccountDeletedPage(driver);
        accountDeletedPage.ClickContinueButton();
    }
    
}