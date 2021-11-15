using System;

namespace Practice
{
    public class Student
    {
        private int _id;
        private string _name;
        private DateTime _dateOfBirth;
        private int[] _subjects;

        public Student(int id, string name, DateTime dob)
        {
            this._id = id;
            this._name = name;
            this._dateOfBirth = dob;
            this._subjects = new int[] { -1, -1, -1, -1, -1 };
        }

        public int Id => this._id;

        public string Name
        {
            get {
                return this._name;
            }
            set {
                this._name = value;
            }
        }

        public int[] Subjects
        {
            get {
                //int[] ids = new int[5];
                //foreach (var id in _subjects)
                //{
                //    ids[id] = _subjects[id];
                //}
                //return ids;
                return _subjects;

            }
        }



        public DateTime DateofBirth {
            get
            {
                return this._dateOfBirth;
            }
        }

        public void AddSubject(int subjectID)
        {
            for (int i = 0; i < _subjects.Length; i++)
            {
                if (_subjects[i] != subjectID)
                {
                    _subjects[i] = subjectID;
                    break;
                }
            }
        }

        public void RemoveSubject(int subjectID)
        {
            for (int i = 0; i < 5; i++)
            {
                if (_subjects[i] == subjectID)
                {
                    _subjects[i] = -1;
                    break;
                }
            }
        }

        //public override string ToString()
        //{
        //    return "Student Id:" + this._id + "\n" + "Student Name:" + this._name + "\n" + "Date Of Birth:" + this._dateOfBirth; 
        //}
    }
}
