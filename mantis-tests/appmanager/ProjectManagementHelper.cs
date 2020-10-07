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

        public void Remove(int index)
        {
            SelectProjectToRemove(index);
            InitRemoveProject();
            ConfirmRemoveProject();
        }

        private void ConfirmRemoveProject()
        {
            Driver.FindElement(By.ClassName("btn-round")).Click();
        }

        private void InitRemoveProject()
        {
            Driver.FindElement(
                    By.CssSelector(
                        "#project-delete-form > fieldset > input.btn.btn-primary.btn-sm.btn-white.btn-round"))
                .Click();
        }

        private void SelectProjectToRemove(int index)
        {
            var listProject = Driver.FindElements(By.CssSelector(" td > a"));
            listProject[index].Click();
        }

        public int GetProjectListCount()
        {
            return Driver.FindElements(By.XPath(
                    "//*[@id=\"main-container\"]/div//div[2]/table/tbody/tr"))
                .Count;
        }

        public void CreateIfNotExist(ProjectData projectData)
        {
            if (ProjectData.GetAll().Count < 1)
            {
                FillProjectData(projectData);
                ConfirmProjectCreation();
                Proceed();
            }
        }
    }
}