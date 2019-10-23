
namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void AddGrade(double grade)
        {
            // Make sure that a Book has a statistics item in it created for it in the constructor and that stats.AddGrade() is called by the Book when a grade is added.
        }

        public int Count
        {
            get;
            private set;
        }

        public double Total
        {
            get;
            private set;
        }

        public double Average
        {
            get
            {
                return Total / Count;
            }
            private set
            {
                average = value;
            }
        }
        
        public double High
        {
            get;
            private set;
        }

        public double Low
        {
            get;
            private set;
        }

        public char GetGradeLetter()
        {
            switch (Average)
            {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
            
        }
        private double average;
    }
}
