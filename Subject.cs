namespace Practice
{
    public class Subject
    {
        private int _id;
        private string _name;
        private int[] _students = new int[10];

        public Subject(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public int Id
        {
            get
            {
                return this._id;
            }

        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public int [] Students 
        { get 
            {
                return _students;
            } 
        }

        public void JoinAStudent(int studentID)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i] != studentID && _students[i] == 0)
                {
                _students[i] = studentID;
                break;
                }
            }
        }

        public void RemoveAStudent(int studentID)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if(_students[i] == studentID)
                {
                    _students[i] = 0;
                    break;
                }
            }
        }

    }
}
