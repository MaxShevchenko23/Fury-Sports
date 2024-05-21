using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace sport_shop_bll.AdditionalServices
{
    public class GetImageUrl
    {
        IWebDriver driver;
        public GetImageUrl()
        {
            driver = new EdgeDriver();
        }

        public string GetUrl(byte[] buffer)
        {
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (FileStream fileStream = new FileStream("temp.png", FileMode.Create))
                {
                    memoryStream.CopyTo(fileStream);

                    driver.Navigate().GoToUrl("https://imgbox.com/");

                    var input = driver.FindElement(By.Name("files[]"));

                    input.SendKeys(fileStream.Name);
                }
            }
            return driver.Url;
        }

    }
}
