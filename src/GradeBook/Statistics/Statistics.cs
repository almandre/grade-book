using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Statistics
    {
        public int Count;
        public double Sum;
        public double High;
        public double Low;

        public Statistics()
        {
            Low = double.MaxValue;
            High = double.MinValue;
        }

        public double Average
        { 
            get
            {
                return Sum / Count;
            }
        }

        public char Letter
        {
            get 
            {
                switch (Average)
                {
                    case var n when n >= 90.0:
                        return 'A';
                    case var n when n >= 80.0:
                        return 'B';
                    case var n when n >= 70.0:
                        return 'C';
                    case var n when n >= 60.0:
                        return 'D';
                    case var n when n >= 50.0:
                        return 'E';
                    default:
                        return 'F';
                }
            }
        }

        public void Add(double grade)
        {
            Count += 1;
            Sum += grade;
            Low = Math.Min(Low, grade);
            High = Math.Max(High, grade);
        }
    }
}
