using OpenQA.Selenium;

namespace mantis_tests
{
    public class HelperBase
    {
        protected static IWebDriver Driver;

        protected HelperBase(ApplicationManager manager)
        {
            Driver = manager.Driver;
        }
    }
}