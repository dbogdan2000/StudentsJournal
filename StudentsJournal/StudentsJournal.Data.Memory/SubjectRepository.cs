using StudentsJournal.Domain;

namespace StudentsJournal.Data.Memory
{
    public class SubjectRepository: ISubjectRepository
    {
        public void Create(int studentId, Subject subject)
        {
            foreach (var student in MemoryDatabase.Students)
            {
                if (student.Id == studentId)
                {
                    student.Subjects.Add(subject);
                }
            }
        }

        public void Update(int studentId, string name, int mark)
        {
            foreach (var student in MemoryDatabase.Students)
            {
                if (student.Id == studentId)
                {
                    foreach (var subject in student.Subjects)
                    {
                        if (subject.SubjectName == name)
                        {
                            subject.Mark = mark;    
                        }
                    }
                }
            }
        }

        public void Delete(int studentId, string name)
        {
            foreach (var student in MemoryDatabase.Students)
            {
                if (student.Id == studentId)
                {
                    foreach (var subject in student.Subjects)
                    {
                        if (subject.SubjectName == name)
                        {
                            student.Subjects.Remove(subject);
                        }
                    }
                }
            }
        }
    }
}