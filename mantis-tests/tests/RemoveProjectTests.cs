using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class RemoveProjectTests : TestBase
    {
        [Test]
        public void RemoveProject()
        {
            var accountData = new AccountData {Name = "administrator", Password = "root2"};
            var projectData = new ProjectData {Name = "ghjkl", Description = "ghjkl"};

            _applicationManager.Login.Login(accountData);
            
            _applicationManager.Project.CreateIfNotExist(projectData);
            var oldProjects = ProjectData.GetAll();
            
            _applicationManager.ManagementMenu.GoToManagePage();
            _applicationManager.Project.GoToProjectPage();

            _applicationManager.Project.Remove(0);

            Assert.AreEqual(oldProjects.Count - 1, _applicationManager.Project.GetProjectListCount());

            var newProjects = ProjectData.GetAll();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

            _applicationManager.Login.LogOut();
        }
    }
}