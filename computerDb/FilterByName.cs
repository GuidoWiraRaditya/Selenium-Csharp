namespace computerDb;

public class FilterByName
{
    IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void FilterByNameTest()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));

        var searchField = driver.FindElement(By.Id("searchbox"));
        searchField.Clear();
        searchField.SendKeys("MacBook");

        var searchButton = driver.FindElement(By.Id("searchsubmit"));
        searchButton.Click();

        var searchResult = driver.FindElement(By.XPath("//tr/td/a[text()='MacBook']"));
        Assert.IsTrue(searchResult.Text.Contains("MacBook"));
    }

    [TearDown]
    public void CloseBrowser() {
        driver.Quit();
    }

}
