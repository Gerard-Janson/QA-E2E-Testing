using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAE2ETesting.Pages;
namespace QAE2ETesting.Tests;

public abstract class BaseTest
{
    private protected IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.automationexercise.com/");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}