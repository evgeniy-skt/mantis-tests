using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class CreateProjectTests : TestBase
    {
        [Test]
        public void CreateProject()
        {
            var projectData = new ProjectData {Name = "Test Project", Description = "fdsgfhg"};
            var accountData = new AccountData {Name = "administrator", Password = "root2"};


            _applicationManager.Login.Login(accountData);
            _applicationManager.Project.RemoveIfExist(projectData);
            var oldProjects = ProjectData.GetAll();
            _applicationManager.Project.Create(projectData);

            Assert.AreEqual(oldProjects.Count + 1, _applicationManager.Project.GetProjectListCount());

            var newProject = ProjectData.GetAll();
            oldProjects.Add(projectData);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
            _applicationManager.Login.LogOut();
        }
    }
}