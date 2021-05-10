using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override void AddGrade(double grade)
        {
            if (grade > 100 || grade < 0)
            {
                throw new ArgumentOutOfRangeException($"Invalid {nameof(grade)}");
            }

            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);

                GradeAdded?.Invoke(this, new EventArgs());
            }
        }

        public override Statistics GetStatitics()
        {
            var statistics = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var grade = double.Parse(line);
                    statistics.Add(grade);

                    line = reader.ReadLine();
                }
            }

            return statistics;
        }

        public override event GradeAddedDelegate GradeAdded;
    }
}
