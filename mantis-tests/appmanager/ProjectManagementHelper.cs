using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        private ApplicationManager _applicationManager;

        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
            _applicationManager = manager;
        }

        public void Create(ProjectData project)
        {
            InitCreateProject();
            FillProjectData(project);
            ConfirmProjectCreation();
            Proceed();
        }
        
        private void Proceed()
        {
            Driver.FindElement(By.LinkText("Proceed")).Click();
        }

        private void ConfirmProjectCreation()
        {
            Driver.FindElement(By.CssSelector(" div.widget-toolbox.padding-8.clearfix > input")).Click();
        }

        private void FillProjectData(ProjectData project)
        {
            Driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            Driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        private void InitCreateProject()
        {
            Driver.FindElement(By.CssSelector("div.widget-toolbox.padding-8.clearfix > form > fieldset > button"))
                .Click();
        }

        public void GoToProjectPage()
        {
            Driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
    }
}