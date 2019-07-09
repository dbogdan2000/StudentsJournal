using System.Collections.Generic;
using StudentsJournal.Domain;

namespace StudentsJournal.Data.Memory
{
    public class MemoryDatabase
    {
        public static List<Student> Students { get; set; } = new List<Student>();
    }
}