using System;
using System.Collections;
using System.Collections.Generic;


namespace lab1
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }

    class Student: Person, IDateAndCopy, IEnumerable
    {
        public IEnumerator Enumerator { get; set; }

        public IEnumerator GetEnumerator()
        {
            return Enumerator;
        }

        private Person _studentData;          //данные о студенте
        private Education _degreeOfEducation; //форма обучения
        private int _groupNumber;             //номер группы
        private List<Test> _listOfTests = new List<Test>();
        private List<Exam> _listOfExams = new List<Exam>();
        //private ArrayList _listOfExams = new ArrayList();          //список экзаменов
        //private ArrayList _listOfTests = new ArrayList();          //список зачетов


        //public Student() //конструктор без параметров
        //{
            //_studentData = new Person();
            //FirstName = "Имя";
            //astName = "Фамилия";
            //DateOfBirth=
            //_degreeOfEducation = Education.Specialist;
            //_groupNumber = 1;
        //}

        public Student(string firstname, string lastname, DateTime dateofbirth, int groupnumber, Education degreeofeducation) //конструктор с параметрами
            :base(firstname, lastname, dateofbirth)
        {
            _studentData = new Person();
            _studentData.FirstName = firstname;
            _studentData.LastName = lastname;
            _studentData.Date = dateofbirth;
            _groupNumber = groupnumber;
            _degreeOfEducation = degreeofeducation;
        }

        public Student():this("Имя","Фамилия", new DateTime (2022, 1, 1), 1, Education.Specialist) // конструктор без парамеров
        {
            //_studentData = new Person();
            //_studentData.FirstName = "Имя";
            //_studentData.LastName = "Фамилия";
            //_studentData.Date = new DateTime(2022, 1, 1);
        } 

        public Person StudentData //get set
        {
            get
            {
                return _studentData;
            }

            set
            {
                _studentData = value;
            }
        }

        public Education DegreeOfEducation //get set для формы обучения
        {
            get
            {
                return _degreeOfEducation;
            }

            set
            {
                _degreeOfEducation = value;
            }
        }

        public int GroupNumber //get set для номера группы
        {
            get
            {
                return _groupNumber;
            }
            set
            {
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Неверное значение!");
                }
                else
                {
                    _groupNumber = value;
                }
            }
            //set
            //{
            //int buff=0;
            //try
            //{
            //buff = Convert.ToInt32(value);
            //if (buff <=100 || buff > 599)
            //throw new ArgumentOutOfRangeException();
            //_groupNumber = buff;
            //}
            //catch (ArgumentOutOfRangeException)
            //{
            //Console.WriteLine("Ошибка ввода!");

            //}
            //finally
            //{
            //_groupNumber = buff;
            //}
            //_groupNumber = buff;
            //}
        }

        public List<Exam> Exams //get set для экзаменов
        {
            get
            {
                return _listOfExams;
            }

            set
            {
                _listOfExams = value;
            }
        }

        public List<Test> Tests //get set для экзаменов
        {
            get
            {
                return _listOfTests;
            }

            set
            {
                _listOfTests = value;
            }
        }

        public double GPA //подсчет среднего балла
        {
            get
            {
                if (_listOfExams == null)
                    return 0;
                int sum = 0;
                int count = 0;
                foreach (Exam exam in _listOfExams)
                {
                    sum = sum + exam._mark;
                    count = count + 1;
                }
                return (double)sum / _listOfExams.Count;
            }
        }

        public bool this [Education index] //индексатор
        {
            get
            {
                if (_degreeOfEducation == index)
                    return true;
                else return false;
                //return DegreeOfEducation == index;
            }
        }

        public void AddExams (params Exam[] exams) //добавление экзаменов
        {
            _listOfExams.AddRange(exams);
            //if(ListOfExams == null)
            //{
            //ListOfExams = new Exam[exams.Length];
            //exams.CopyTo(ListOfExams, 0);
            //}
            //else
            //{
            //Exam[] old_exams= new Exam[ListOfExams.Length];
            //ListOfExams.CopyTo(old_exams,0);

            //ListOfExams = new Exam[old_exams.Length + exams.Length];
            //old_exams.CopyTo(ListOfExams, 0);
            //exams.CopyTo(ListOfExams, old_exams.Length);
            //}
        }

        public void AddTests(params Test[] tests) //добавление экзаменов
        {
            _listOfTests.AddRange(tests);
        }

        public override string ToString() //преобразование в строку со спистом тестов и экзаменв
        {
            string exams="";
            if (_listOfExams.Count == 0)
                exams = "нет сданных экзаменов";
            else
            {
                foreach (Exam exam in _listOfExams)
                {
                    exams += exam.ToString();
                }
            }

            string tests = "";
            if (_listOfTests.Count == 0)
                tests = "нет сданных зачетов";
            else
            {
                foreach (Test test in _listOfTests)
                {
                    tests += test.ToString();
                }
            }

            return "\nДанные студента: " + "\nИмя: " + FirstName + ' ' + LastName + "\nДата рождения: " + Date + "\nФорма обучения: " + _degreeOfEducation + "\nНомер группы: " + _groupNumber + "\nСданные экзамены: " + exams + "\nСданные зачеты: " + tests;
        }

        public new string ToShortString() //преобразование в строку со средним баллом без списка тестов и экзаменов
        {
            return "\nДанные студента: " + "\nИмя: " + FirstName + ' ' + LastName + "\nДата рождения: " + Date + "\nФорма обучения: " + _degreeOfEducation + "\nНомер группы: " + _groupNumber + "\nСредний балл: " + GPA;
        }

        public override object DeepCopy()  //полная копия
        {
            Student studentobj = new Student(this.FirstName, this.LastName,this.Date,this._groupNumber,this._degreeOfEducation);
            studentobj._listOfExams = _listOfExams;
            studentobj._listOfTests = _listOfTests;
            return studentobj;
        }

        public IEnumerable<Object> AllExamsAndTests() //список всех экзаменов и тестов
        {
            Console.WriteLine("\nСписок всех экзаменов:");
            for (int i = 0; i < _listOfExams.Count; i++)
            {
                yield return (Exam)_listOfExams[i];
                Console.WriteLine(((Exam)_listOfExams[i]).ToString());
            }
            Console.WriteLine("\nСписок всех тестов:");
            for (int i = 0; i < _listOfTests.Count; i++)
            {
                yield return (Test)_listOfTests[i];
                Console.WriteLine(((Test)_listOfTests[i]).ToString());
            }
        }

        public IEnumerable<Exam> ExamsWithMark(int mark) //экзамены с оценкой выше заданной
        {
            for (int i = 0; i < _listOfExams.Count; i++)
            {
                if(((Exam)_listOfExams[i])._mark>mark)
                {
                    yield return (Exam)_listOfExams[i];
                    Console.WriteLine(((Exam)_listOfExams[i]).ToString());
                }
            }
        }

        //public IEnumerator<string> SubjectsInExamsAndTests() //список предметов которые есть и в списке экзаменов и в списке зачетов
        //{
            //string[] subjects;

            //new StudentEnumerator(subjects);
        //}
        public IEnumerable<Object> PassedExamsAndTests() //итератор для сданных экзаменов и тестов
        {
            Console.WriteLine("\nСписок сданных экзаменов:");
            for (int i = 0; i < _listOfExams.Count; i++)
            {
                if(((Exam)_listOfExams[i])._mark>=2)
                {
                    yield return (Exam)_listOfExams[i];
                    Console.WriteLine(((Exam)_listOfExams[i]).ToString());
                }
            }
            Console.WriteLine("\nСписок сданных тестов:");
            for (int i = 0; i < _listOfTests.Count; i++)
            {
                if(((Test)_listOfTests[i])._offset==true)
                {
                    yield return (Test)_listOfTests[i];
                    Console.WriteLine(((Test)_listOfTests[i]).ToString());
                }
            }
        }

        public IEnumerable<Object> PassedTests() //итератор для сданных тестов для которых сдан экзамен
        {
            Console.WriteLine("\nСписок сданных тестов для которых сдан экзамен:");
            for (int i = 0; i < _listOfTests.Count; i++)
            {
                if (((Test)_listOfTests[i])._offset == true)
                {
                    for (int j = 0; j < _listOfExams.Count; j++)
                    {
                        if (((Exam)_listOfExams[j])._subjectName== ((Test)_listOfTests[i])._subjectName && ((Exam)_listOfExams[j])._mark >= 2)
                        {
                            yield return (Test)_listOfTests[i];
                            Console.WriteLine(((Test)_listOfTests[i]).ToString());
                        }
                    }    
                }
            }
        }

    }
}
