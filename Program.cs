using System;

namespace Practice
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Enter number of Students: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());
            string studentName;
            string subjectName;
            DateTime dateOfBirth;
            Subject[] subjects = new Subject[5] ;
            int subjectId = 1;
            Student[] students = new Student[10] ;
            int studentId = 1;
            int [,] studentSubjectArr = new int[50,2];


            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine("Enter details of Student {0}: ", i +1);
                studentId += i;
                Console.WriteLine("Name: ");
                studentName = Console.ReadLine();
                Console.WriteLine("Date of Birth: ");
                dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                var student = new Student(studentId, studentName, dateOfBirth);
                students[i] = student;
            }

            Console.WriteLine("Enter number of Subjects: ");
            int numberOfSubjects = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfSubjects; i++)
            {
                Console.WriteLine("Enter details of Subject {0}: ", i + 1);
                subjectId += i;
                Console.WriteLine("Name: ");
                subjectName = Console.ReadLine();

                var subject = new Subject(subjectId, subjectName);
                subjects[i] = subject;
            }

            string menuOptions = "";

            while (menuOptions != "Q")
            {
                Console.WriteLine("What would you like to do next: \n " +
                    "(1) Register student for a subject. \n " +
                    "(2) Withdraw student from a subject. \n " +
                    "(3) View All Students. \n " +
                    "(4) View All Subjects. \n " +
                    "(5) View All Info. \n (Q) Quit Application"
                    );

                menuOptions = Console.ReadLine();

                if (menuOptions == "1")
                {
                    Console.WriteLine("Enter student ID: ");
                    int joinStudentId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Subject ID: ");
                    int joinSubjectId = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < subjects.Length; i++)
                    {
                        if (subjects[i] == null) { continue; }

                        else if (subjects[i].Id == joinSubjectId)
                        {
                            studentSubjectArr[i, 0] = joinStudentId;
                            studentSubjectArr[i, 1] = joinSubjectId;

                            Console.WriteLine("subject ID: {0}, Student ID: {1}", studentSubjectArr[i, 0], studentSubjectArr[i, 1]);

                            subjects[i].JoinAStudent(joinStudentId);
                            
                            for (int j = 0; j < students.Length; j++)
                            {
                                if (students[j].Id == joinStudentId) 
                                { 
                                    Console.WriteLine("Added {0} to the subject {1}", students[j].Name, subjects[i].Name); 
                                    students[j].AddSubject(joinSubjectId);
                                    break;
                                }
                            }
                            break;
                        }
                    }


                }
                else if (menuOptions == "2")
                {
                    Console.WriteLine("Enter student ID: ");
                    int removeStudentId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Subject ID: ");
                    int removeSubjectId = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < subjects.Length; i++)
                    {
                        if (subjects[i] == null) { continue; }
                        else if (subjects[i].Id == removeSubjectId)
                        {
                            subjects[i].RemoveAStudent(removeStudentId);

                            for (int j = 0; j < students.Length; j++)
                            {
                                if (students[j].Id == removeStudentId)
                                {
                                    students[j].RemoveSubject(removeSubjectId);
                                    Console.WriteLine("Removed {0} from subject {1}", students[j].Name, subjects[i].Name);

                                    break;
                                }
                                else { Console.WriteLine("Student {0}, is not registered for subject {1}", students[j].Name, subjects[i].Name);}
                            }
                        }

                    }
                    
                }
                else if (menuOptions == "3")
                {
                    for (int i = 0; i < students.Length; i++)
                    {
                        var student = students[i];
                        if (student == null) { continue; }

                        Console.WriteLine("Student ID " + students[i].Id);
                        Console.WriteLine("Student Name " + students[i].Name);
                        Console.WriteLine("Student DOB " + students[i].DateofBirth);
                        Console.WriteLine("Subjects: ");

                        for (int j = 0; j < student.Subjects.Length; j++)
                        {
                            var subject = student.Subjects[j];
                            if (subject != 0)
                            {
                                Console.WriteLine("{0}: {1} ",j+1, subjects[j].Name);
                            }
                        }
                    }
                }
                else if (menuOptions == "4")
                {
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        var subject = subjects[i];

                        if (subject == null) { continue; }

                        Console.WriteLine("Subject ID: {0} , \n Subject Name: {1}", subjects[i].Id,
                            subjects[i].Name);
                        Console.WriteLine("Students: ");

                        for (int j = 0; j < subject.Students.Length; j++)
                        {
                            var student = subject.Students[j];
                            if (student != 0)
                            {
                                Console.WriteLine("{0}: {1} ", j+1, students[j].Name);
                            }
                        }
                    }
                }else if(menuOptions == "5")
                {
                    Console.WriteLine(studentSubjectArr[3,0]);
                    /*for (int i = 0; i < 50; i++)
                    {
                        int xAxis = i;
                        
                        if (studentSubjectArr[xAxis,0] != 0 || studentSubjectArr[xAxis,1] != 0) { 
                            Console.WriteLine("Student: {0}, Subject Name: {2}", i, studentSubjectArr[xAxis,0], studentSubjectArr[xAxis,1]);
                        }
                    }*/

/*                    for (int i = 0; i < students.Length; i++)
                    {
                        var student = students[i];
                        if (student == null) { continue; }

                        Console.WriteLine("Student {0}, Student ID: {1}, Student Name: {2}", i, student.Id, student.Name);
                    }
*/                }
            }



        }

    }
}
