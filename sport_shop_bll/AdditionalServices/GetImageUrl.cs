using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Drawing;
using System.IO;

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

                    driver.Navigate().GoToUrl("https://cubeupload.com/");

                    if (driver.FindElement(By.ClassName("left log nav")) != null)
                    {
                        driver.FindElement(By.ClassName("left log nav")).Click();

                        if (driver.Url == "https://cubeupload.com/login")
                        {
                            driver.FindElement(By.Name("cube_username")).SendKeys("furySport");
                            driver.FindElement(By.Name("cube_password")).SendKeys("zolotishko");
                        }
                        else
                        {
                            throw new Exception("Getting Url Exception: Page didnt load the login form");
                        }
                    }
                    driver.FindElement(By.Id("uploadContainer")).SendKeys("temp.png");
                }
            }
            return driver.Url;
        }

    }
}
