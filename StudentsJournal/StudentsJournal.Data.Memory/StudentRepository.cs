using System;
using System.Collections.Generic;
using StudentsJournal.Domain;

namespace StudentsJournal.Data.Memory
{
    public class StudentRepository: IStudentRepository
    {
        public List<Student> Get()
        {
            return MemoryDatabase.Students;
        }

        public void Create(Student student)
        {
            MemoryDatabase.Students.Add(student);
        }

        public void Update(int id, string name, string surname)
        {
            foreach (var student in MemoryDatabase.Students)
            {
                if (student.Id == id)
                {
                    student.Name = name;
                    student.Surname = surname;
                }
            }
        }


        public void Delete(int id)
        {
            foreach (var student in MemoryDatabase.Students)
            {
                if (student.Id == id)
                {
                    MemoryDatabase.Students.Remove(student);
                }
            }
        }

        public Student Get(int id)
        {
            foreach (var student in MemoryDatabase.Students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            
            throw new Exception($"Student {id} not found");
        }

        public int Count()
        {
            return MemoryDatabase.Students.Count;
        }
    }
}