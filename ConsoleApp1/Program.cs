using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Course
    {
        public string iD;
        public string name;
        public string description;
        public List<Course> preRequisites;
        public int yearLvl;
    }
}
