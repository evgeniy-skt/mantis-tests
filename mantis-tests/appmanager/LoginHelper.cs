using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            OpenMainPage();
            FillUserNameInput(account);
            SubmitLogin();
            FillPasswordInput(account);
            SubmitLogin();
        }

        public void LogOut()
        {
            Driver.FindElement(By.ClassName("user-info")).Click();
            Driver.FindElement(By.ClassName("fa-sign-out")).Click();
            //Driver.Quit();
        }

        private void FillPasswordInput(AccountData accountData)
        {
            Driver.FindElement(By.Id("password")).SendKeys(accountData.Password);
        }

        private void SubmitLogin()
        {
            Driver.FindElement(By.CssSelector("input.bigger-110")).Click();
        }

        private void FillUserNameInput(AccountData accountData)
        {
            Driver.FindElement(By.Id("username")).SendKeys(accountData.Name);
        }

        private void OpenMainPage()
        {
            Driver.Url = "http://localhost:8080/mantisbt-2.24.3/login_page.php";
        }
    }
}