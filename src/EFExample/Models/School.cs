using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFExample.Models
{
    public class School
    {


        public long ID { get; set; }

        public string Name { get; set; }


        public ICollection<Teacher> Teachers { get; set; }


        public School()
        {
            this.Teachers = new HashSet<Teacher>();
        }

    }
}
