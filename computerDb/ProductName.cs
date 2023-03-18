namespace computerDb;

public class ProductName
{
    IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void ClickProductName()
    {
        driver.Url = "http://computer-database.gatling.io/computers";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Computer database")));

        var index = 1;
        var productButton = driver.FindElement(By.XPath("//table[@class='computers zebra-striped']/tbody/tr/td/a[" + index + "]"));
        var productName = productButton.Text;
        productButton.Click();

        var productNameField = driver.FindElement(By.XPath("//label[@for='name']//following-sibling::div/input"));

        Assert.That(productNameField.GetAttribute("value"), Is.EqualTo(productName));
    }

    [TearDown]
    public void CloseBrowser() {
        driver.Quit();
    }

}
