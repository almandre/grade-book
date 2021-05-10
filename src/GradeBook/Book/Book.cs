using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public abstract class Book : IBook
    {
        protected List<double> grades;
        public string Name { get; set; }

        public Book (string name = null)
        {
            Name = name;
            grades = new List<double>();
        }

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatitics();

        public abstract event GradeAddedDelegate GradeAdded;
    }
}
