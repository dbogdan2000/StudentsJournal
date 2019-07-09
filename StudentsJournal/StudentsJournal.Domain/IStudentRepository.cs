using System.Collections.Generic;

namespace StudentsJournal.Domain
{
    public interface IStudentRepository
    {
        List<Student> Get();
        void Create(Student student);
        void Update(int id, string name, string surname); 
        void Delete(int id);
        Student Get(int id);
        int Count();
    }
}