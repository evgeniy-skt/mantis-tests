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
            _applicationManager.Login.Login(accountData);
            _applicationManager.ManagementMenu.GoToManagePage();
            _applicationManager.Project.GoToProjectPage();

            _applicationManager.Project.Remove();

            _applicationManager.Login.LogOut();
        }
    }
}