namespace computerDb;

public class Pagination
{
    IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test, Order(1)]
    public void NextButton()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));

        //should add checking whether previous button is active or not

        var nextButton = driver.FindElement(By.XPath("//div[@id='pagination']//*[contains(text(),'Next')]"));
        nextButton.Click();

        var previousButton = driver.FindElement(By.XPath("//div[@id='pagination']//*[contains(text(),'Previous')]"));
        Assert.IsTrue(previousButton.Enabled);
    }

    [TearDown]
    public void CloseBrowser() {
        driver.Quit();
    }

}
