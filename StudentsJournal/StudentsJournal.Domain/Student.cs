using System.Collections.Generic;

namespace StudentsJournal.Domain
{
    public class Student
    {
        private double _rating;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public double Rating
        {
            get
            {
                _rating = 0;
                if (Subjects.Count == 0)
                {
                    return 0;
                }
                
                foreach (var subject in Subjects)
                {
                    _rating += subject.Mark;
                }

                return _rating / Subjects.Count;
            }
        }

        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}