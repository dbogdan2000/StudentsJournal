using System;
using System.Collections.Generic;
using StudentsJournal.Data.Memory;
using StudentsJournal.Domain;

namespace StudentsJournal.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 1;
            IStudentRepository studentRepository = new StudentRepository();
            ISubjectRepository subjectRepository = new SubjectRepository();
            while (true)
            {
                Console.WriteLine("Enter 1 to add new student\n" +
                                  "Enter 2 to view students list\n" +
                                  "Enter 3 to exit\n" +
                                  "Enter 4 to edit list\n" +
                                  "Enter 5 to add subjects for student\n" +
                                  "Enter 6 to edit subjects\n" +
                                  "Enter 7 to delete subject\n" +
                                  "Enter 8 to view details");
                int switcher = int.Parse(Console.ReadLine());
                switch (switcher)
                {
                    case 1:
                        Student student = new Student();
                        student.Id = counter;
                        Console.Write("Enter name: ");
                        student.Name = Console.ReadLine();
                        Console.Write("Enter surname: ");
                        student.Surname = Console.ReadLine();
                        studentRepository.Create(student);
                        counter++;
                        Console.WriteLine($"{student.Name} {student.Surname} has been added");
                        break;
                    case 2:
                        if (studentRepository.Count() != 0)
                        {
                            foreach (var st in studentRepository.Get())
                            {
                                Console.Write(st.Id);
                                Console.WriteLine($". {st.Name} {st.Surname} {st.Rating}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("List is empty");
                        }

                        break;
                    case 4:
                        Console.Write("Enter ID of a student, who you want to edit: ");
                        int editId = int.Parse(Console.ReadLine());
                        Console.Write("Write new name: ");
                        var name = Console.ReadLine();
                        Console.Write("Write new surname: ");
                        var surname = Console.ReadLine();
                        Console.WriteLine("Student has been successfully edited");
                        studentRepository.Update(editId, name, surname);
                        break;
                    case 3:
                        return;
                    case 5:
                        Console.WriteLine("Enter ID of a student, whom you want to add subject: ");
                        Subject subject = new Subject();
                        int addId = int.Parse(Console.ReadLine());
                        Console.Write("Write name of Subject: ");
                        subject.SubjectName = Console.ReadLine();
                        Console.Write("Write mark of subject: ");
                        subject.Mark = int.Parse(Console.ReadLine());
                        subjectRepository.Create(addId, subject);
                        break;
                    case 6:
                        Console.WriteLine("Enter ID of a student, whose subject you want to edit: ");
                        int editSubId = int.Parse(Console.ReadLine());
                        Console.Write("Write name of subject, which you want to edit");
                        string editName = Console.ReadLine();
                        Console.Write("Enter new mark: ");
                        var mark = int.Parse(Console.ReadLine());
                        subjectRepository.Update(editSubId, editName, mark);
                        Console.WriteLine("Subject was successfully edited");
                        break;
                    case 7:
                        Console.WriteLine("Enter ID of a student, whose subject you want to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        Console.Write("Write name of subject, which you want to delete");
                        string deleteName = Console.ReadLine();
                        subjectRepository.Delete(deleteId, deleteName);
                        break;
                    case 8:
                        Console.WriteLine("Enter ID of a student, who you want to see details: ");
                        int viewId = int.Parse(Console.ReadLine());
                        var st1 = studentRepository.Get(viewId);
                        Console.WriteLine($"ID: {st1.Id}");
                        Console.WriteLine($"Name: {st1.Name}");
                        Console.WriteLine($"Surname: {st1.Surname}");
                        Console.WriteLine($"Rating: {st1.Rating}");
                        Console.WriteLine("Subjects:");
                        foreach (var sub in st1.Subjects)
                        {
                            Console.WriteLine($"\t{sub.SubjectName} {sub.Mark}");    
                        }
                        break;
                    default:
                        throw new Exception("Wrong numb");
                }
            }
        }
    }
}