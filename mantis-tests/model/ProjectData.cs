using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        [Column(Name = "name")] public string Name { get; set; }
        [Column(Name = "description")] public string Description { get; set; }

        public static List<ProjectData> GetAll()
        {
            DataConnection.DefaultSettings = new MantisDB.MySettings();
            var db = new MantisDB();
            var fromDB = (from p in db.Projects.Where(x => x.Name != "") select p).ToList();
            db.Close();
            return fromDB;
        }

        public bool Equals(ProjectData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name && Description == other.Description;
        }

        public int CompareTo(ProjectData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Name.CompareTo(other.Name) == 0)
            {
                return Name.CompareTo(other.Name);
            }

            return Description.CompareTo(other.Description);
        }
    }
}