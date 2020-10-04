using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class ApplicationManager
    {
        private readonly string _baseUrl;
        private static ThreadLocal<ApplicationManager> _applicationManager = new ThreadLocal<ApplicationManager>();
        public LoginHelper Login { get; }
        public IWebDriver Driver { get; }

        public ProjectManagementHelper Project { get; }
        public ManagementMenuHelper ManagementMenu { get; set; }

        private ApplicationManager()
        {
            Driver = new ChromeDriver();
            _baseUrl = "http://localhost:8080/addressbook/";
            Login = new LoginHelper(this);
            Project = new ProjectManagementHelper(this);
            ManagementMenu = new ManagementMenuHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!_applicationManager.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                newInstance.Driver.Url = "http://localhost:8080/mantisbt-2.24.3/login_page.php";
                _applicationManager.Value = newInstance;
            }

            return _applicationManager.Value;
        }
    }
}