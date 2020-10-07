using System.Collections.Generic;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_user_table")]
    public class AccountData
    {
        [Column(Name = "username")] public string Name { get; set; }
        [Column(Name = "password")] public string Password { get; set; }


    }
}