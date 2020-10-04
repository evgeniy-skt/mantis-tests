using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase
    {
        protected ApplicationManager _applicationManager;

        [SetUp]
        public void SetupApplicationManager()
        {
            _applicationManager = ApplicationManager.GetInstance();
        }
    }
}