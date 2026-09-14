using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace QAE2ETesting.Tests;

public class RegisterTests
{
    private IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void TestCase1()
    {
        
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}