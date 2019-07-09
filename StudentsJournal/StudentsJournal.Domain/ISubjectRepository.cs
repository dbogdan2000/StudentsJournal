namespace StudentsJournal.Domain
{
    public interface ISubjectRepository
    {
        void Create(int studentId, Subject subject);
        void Update(int studentId, string name, int mark);
        void Delete(int studentId, string name);
    }
}