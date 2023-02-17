using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApps.DAL.Entities
{
    public class User:BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName{ get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDay{ get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
