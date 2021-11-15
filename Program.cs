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
            Subject[] subjects = new Subject[] { null, null, null, null, null};
            int subjectId = 1;
            Student[] students = new Student[] { null, null, null, null, null, null, null, null, null, null };
            int studentId = 1;
            int[,] studentSubjectArr = new int[10,10];


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

                    
/*                    for (int i = 0; subjects[i].Id == joinSubjectId; i++)
                    {

                        Console.WriteLine("subject ID: {0}, join subject ID: {1}", subjects[i].Id, joinSubjectId);
                        if (subjects[i] == null){continue;}
                        studentSubjectArr[0, 0] = joinStudentId;
                        studentSubjectArr[0, 1] = joinSubjectId;

                        Console.WriteLine("Students: {0}, Subjects: {1}", studentSubjectArr[0, 0], studentSubjectArr[0,1]);

                    }
*/
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        if (subjects[i] == null) { continue; }

                        else if (subjects[i].Id == joinSubjectId)
                        {
                            Console.WriteLine("subject ID: {0}, join subject ID: {1}", subjects[i].Id, joinSubjectId);
                            studentSubjectArr[0, 0] = joinStudentId;
                            studentSubjectArr[0, 1] = joinSubjectId;

                            Console.WriteLine("Students: {0}, Subjects: {1}", studentSubjectArr[0, 0], studentSubjectArr[0, 1]);

                            //Console.WriteLine("subject ID: {0}, Student ID: {1}, join student ID: {2}, join subject ID: {3}", subjects[i].Id, students[i].Id, joinStudentId, joinSubjectId);
                            subjects[i].JoinAStudent(joinStudentId);
                            students[i].AddSubject(joinSubjectId);
                            break;
                        }
                    }
                    //Console.WriteLine("Added Student {0}, into the subject {1}. \n ", students[joinStudentId].Name, subjects[joinSubjectId].Name);


                }
                else if (menuOptions == "2")
                {
                    Console.WriteLine("Enter student ID: ");
                    int removeStudentId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Subject ID: ");
                    int removeSubjectId = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < subjects.Length; i++)
                    {
                        if (subjects[i] == null || students[i] == null ) { continue; }
                        else if (subjects[i].Id == removeStudentId)
                        {
                            subjects[i].RemoveAStudent(removeStudentId);
                            students[removeStudentId].RemoveSubject(removeSubjectId);
                        }
                        
                    }
                    Console.WriteLine("Removed {0}, from subject {1}", students[removeStudentId].Name, subjects[removeSubjectId].Name);

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

                        for (int j = 0; j < subjects.Length; j++)
                        {
                            Console.WriteLine("Students: {0}, Subjects: {1}", studentSubjectArr[0, 0], studentSubjectArr[0, 1]);

                                if (students[i].Subjects[j] != -1)
                            {
                                Console.WriteLine("Student Subject " + studentSubjectArr[i,j]);
                            }
                        }
                        /*                        Console.WriteLine("Student ID: {0}, \n Student Name: {1}, \n Student Date of Birth: {2}, \n Subjects: {3}", students[i].Id,
                                                    students[i].Name, students[i].DateofBirth , students[i].Subjects);
                        */
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
                    }
                }else if(menuOptions == "5")
                {
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        var subject = subjects[i];
                        if (subject == null) { continue; }

                        Console.WriteLine("Subject{0}, Subject ID: {1}, Subject Name: {2}", i, subject.Id, subject.Name);
                    }

                    for (int i = 0; i < students.Length; i++)
                    {
                        var student = students[i];
                        if (student == null) { continue; }

                        Console.WriteLine("Student {0}, Student ID: {1}, Student Name: {2}", i, student.Id, student.Name);
                    }
                }
            }



        }

    }
}
