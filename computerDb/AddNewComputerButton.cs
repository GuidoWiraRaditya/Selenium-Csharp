namespace computerDb;

public class AddNewComputerButton
{
    IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void ClickAddNewComputerButton()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));

        var addComputerButton = driver.FindElement(By.Id("add"));
        addComputerButton.Click();

        var addComputerPageTitle = driver.FindElement(By.XPath("//h1[text()='Add a computer']"));
        Assert.IsTrue(addComputerPageTitle.Text.Contains("Add a computer"));
    }

    [TearDown]
    public void CloseBrowser() {
        driver.Quit();
    }

}
