namespace mantis_tests
{
    public class ApiHelper : HelperBase
    {
        public ApiHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateIfNotExist(ProjectData projectData, AccountData accountData)
        {
            var client = new Mantis.MantisConnectPortTypeClient();
            if (ProjectData.GetAllFromMantisApi(accountData).Count < 1)
            {
                client.mc_project_add(accountData.Name, accountData.Password, projectData);
            }
        }
    }
}