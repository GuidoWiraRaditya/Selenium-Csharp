namespace computerDb;

public class AddNewComputerPage
{
    IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test, Order(1)]
    public void ClickCancelButton()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));
        var addComputerButton = driver.FindElement(By.Id("add"));
        addComputerButton.Click();

        var cancelButton = driver.FindElement(By.XPath("//a[@class='btn' and text()='Cancel']"));
        cancelButton.Click();

        var pageTitle = driver.FindElement(By.XPath("//a[@class='fill' and text()='Computer database']"));
        Assert.IsTrue(pageTitle.Text.Contains("Computer database"));
    }

    [Test, Order(2)]
    public void InputFieldActive()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));
        var addComputerButton = driver.FindElement(By.Id("add"));
        addComputerButton.Click();

        var nameField = driver.FindElement(By.Id("name"));
        var introducedField = driver.FindElement(By.Id("introduced"));
        var discontinuedField = driver.FindElement(By.Id("discontinued"));
        var companyDropdown = driver.FindElement(By.Id("company"));
        Assert.IsTrue(nameField.Enabled);
        Assert.IsTrue(introducedField.Enabled);
        Assert.IsTrue(discontinuedField.Enabled);
        Assert.IsTrue(companyDropdown.Enabled);
    }

    [Test, Order(3)]
    public void CreateNewComputer()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));
        var addComputerButton = driver.FindElement(By.Id("add"));
        addComputerButton.Click();

        var nameField = driver.FindElement(By.Id("name"));
        var introducedField = driver.FindElement(By.Id("introduced"));
        var discontinuedField = driver.FindElement(By.Id("discontinued"));
        var companyDropdown = new SelectElement(driver.FindElement(By.Id("company")));
        var createComputerButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Create this computer']"));

        nameField.SendKeys("NewComputer");
        introducedField.SendKeys("1997-11-05");
        discontinuedField.SendKeys("2000-11-05");
        companyDropdown.SelectByText("Apple Inc.");
        createComputerButton.Click();
    }

    [TearDown]
    public void CloseBrowser() {
        driver.Quit();
    }

}
