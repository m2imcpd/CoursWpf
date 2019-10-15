using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfEntity
{
    public class Course
    {
        private int id;
        private string title;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }

        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
    }
}
