using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class CreateProjectTest : TestBase
    {
        [Test]
        public void CreateProject()
        {
            var projectData = new ProjectData {Name = "Test Project", Description = "fdsgfhg"};
            var accountData = new AccountData {Name = "administrator", Password = "root2"};
            _applicationManager.Login.Login(accountData);
            _applicationManager.ManagementMenu.GoToManagePage();
            _applicationManager.Project.GoToProjectPage();

            _applicationManager.Project.Create(projectData);

            _applicationManager.Login.LogOut();
        }
    }
}