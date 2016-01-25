using System.Collections.Generic;

namespace EFExample.Models
{
    public class Teacher
    {

        public long ID { get; set; }

        public string Name { get; set; }


        public ICollection<Student> Students { get; set; }


        public long SchoolID { get; set; }
        public virtual School School { get; set; }

        public Teacher()
        {
            this.Students = new HashSet<Student>();
        }
    }
}