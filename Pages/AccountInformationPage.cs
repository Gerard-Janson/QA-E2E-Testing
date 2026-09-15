using OpenQA.Selenium;

namespace QAE2ETesting.Pages;

public class AccountInformationPage : BasePage
{
    private readonly By _accountHeading = By.XPath("//h2[normalize-space()='Enter Account Information']");
    private readonly By _chooseMr = By.CssSelector("input[value='Mr']");
    private readonly By _chooseMrs = By.CssSelector("input[value='Mrs']");
    private readonly By _password = By.CssSelector("[data-qa='password']");
    private readonly By _days = By.CssSelector("[data-qa='days']");
    private readonly By _months = By.CssSelector("[data-qa='months']");
    private readonly By _years = By.CssSelector("[data-qa='years']");
    private readonly By _newsletter = By.Id("newsletter");
    private readonly By _specialOffers = By.Id("optin");
    private readonly By _firstName = By.CssSelector("[data-qa='first_name']");
    private readonly By _lastName = By.CssSelector("[data-qa='last_name']");
    private readonly By _company = By.CssSelector("[data-qa='company']");
    private readonly By _address1 = By.CssSelector("[data-qa='address']");
    private readonly By _address2 = By.CssSelector("[data-qa='address2']");
    private readonly By _country = By.CssSelector("[data-qa='country']");
    private readonly By _state = By.CssSelector("[data-qa='state']");
    private readonly By _city = By.CssSelector("[data-qa='city']");
    private readonly By _zipcode = By.CssSelector("[data-qa='zipcode']");
    private readonly By _mobileNumber = By.CssSelector("[data-qa='mobile_number']");
    private readonly By _createAccountButton = By.CssSelector("[data-qa='create-account']");
    
    public AccountInformationPage(IWebDriver driver) : base(driver)
    {
    }
    
    public void SelectTitle(string title)
    {
        if (title == "Mr")
            ClickElement(_chooseMr);
        else if (title == "Mrs")
            ClickElement(_chooseMrs);
    }
    
    public void EnterPassword(string password)
    {
        TypeText(_password, password);
    }

    public void SelectDateOfBirth(string day, string month, string year)
    {
        SelectDropDownByValue(_days, day);
        SelectDropDownByText(_months, month);
        SelectDropDownByValue(_years, year);
    }

    public void EnterAddressDetails(
        string firstName,
        string lastName,
        string company,
        string address1,
        string address2,
        string country,
        string state,
        string city,
        string zipcode,
        string mobileNumber)
    {
        TypeText(_firstName, firstName);
        TypeText(_lastName, lastName);
        TypeText(_company, company);
        TypeText(_address1, address1);
        TypeText(_address2, address2);
        SelectDropDownByText(_country, country);
        TypeText(_state, state);
        TypeText(_city, city);
        TypeText(_zipcode, zipcode);
        TypeText(_mobileNumber, mobileNumber);
    }

    public void ClickCreateAccountButton()
    {
        ClickElement(_createAccountButton);
    }

    public string GetAccountInformationHeading()
    {
        return GetText(_accountHeading);
    }

    public void SetNewsletterSubscription(bool subscribe)
    {
        SetCheckbox(_newsletter, subscribe);
    }

    public void SetSpecialOfferSubscription(bool optin)
    {
        SetCheckbox(_specialOffers, optin);
    }
}