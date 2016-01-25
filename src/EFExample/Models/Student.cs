namespace EFExample.Models
{
    public class Student
    {

        public long ID { get; set; }

        public long TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }

        public string Name { get; set; }
    }
}