namespace computerDb;

public class AccessHomepage
{
    IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void FilterByName()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));

        var pageTitle = driver.FindElement(By.XPath("//a[@class='fill' and text()='Computer database']"));
        Assert.IsTrue(pageTitle.Text.Contains("Computer database"));
    }

    [TearDown]
    public void CloseBrowser() {
        driver.Quit();
    }

}
