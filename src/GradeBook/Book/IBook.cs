using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public interface IBook
    {
        public string Name { get; }

        public void AddGrade(double grade);

        public Statistics GetStatitics();

        public event GradeAddedDelegate GradeAdded;
    }
}
