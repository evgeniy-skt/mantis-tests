using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void GoToManagePage()
        {
            Driver.FindElement(By.XPath("//*[@id=\"sidebar\"]/ul/li[7]/a/span")).Click();
        }
    }
}