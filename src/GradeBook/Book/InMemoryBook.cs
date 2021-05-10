using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name = null) : base(name)
        {

        }

        public override void AddGrade(double grade)
        {
            if (grade > 100 || grade < 0)
            {
                throw new ArgumentOutOfRangeException($"Invalid {nameof(grade)}");
            }

            grades.Add(grade);

            GradeAdded?.Invoke(this, new EventArgs());
        }

        public override Statistics GetStatitics()
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.Add(grade);
            }

            return statistics;
        }

        public override event GradeAddedDelegate GradeAdded;
    }
}
