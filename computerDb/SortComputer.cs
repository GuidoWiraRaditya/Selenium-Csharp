namespace computerDb;

public class SortComputer
{
    IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test, Order(1)]
    public void SortComputerDesc()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));

        var computerSortDescButton = driver.FindElement(By.XPath("//th[contains (@class, 'SortUp')]/a"));
        computerSortDescButton.Click();

        var computerSortAscButton = driver.FindElement(By.XPath("//th[contains (@class, 'SortDown')]/a"));
        Assert.IsTrue(computerSortAscButton.Displayed);

    }

    [Test, Order(2)]
    public void SortComputerAsc()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));

        var computerSortDescButton = driver.FindElement(By.XPath("//th[contains (@class, 'SortUp')]/a"));
        computerSortDescButton.Click();

        var computerSortAscButton = driver.FindElement(By.XPath("//th[contains (@class, 'SortDown')]/a"));
        computerSortAscButton.Click();

        var computerSortDescAssert = driver.FindElement(By.XPath("//th[contains (@class, 'SortUp')]/a"));
        Assert.IsTrue(computerSortDescAssert.Displayed);

    }

    [TearDown]
    public void CloseBrowser() {
        driver.Quit();
    }

}
