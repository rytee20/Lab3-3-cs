using System;
using System.Collections;
using System.Collections.Generic;

namespace lab1
{

    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Создать объект типа StudentCollection. Добавить в коллекцию несколько различных элементов типа Student и вывести объект StudentCollection.");
            StudentCollection StudentsOfOurUniversity = new StudentCollection();
            
            Student student1 = new Student("Екатерина", "Афонина", new DateTime(2003, 12, 13), 21, Education.Bachelor);
            Exam exam = new Exam("Математика", 4, new DateTime(2022, 6, 18));
            student1.AddExams(exam);
            exam = new Exam("Физика", 4, new DateTime(2022, 6, 12));
            student1.AddExams(exam);
            exam = new Exam("Иностранный язык", 5, new DateTime(2022, 6, 11));
            student1.AddExams(exam);
            exam = new Exam("ПрЧМИ", 5, new DateTime(2022, 6, 24));
            student1.AddExams(exam);
            Test test = new Test("Физ-ра", true);
            student1.AddTests(test);
            test = new Test("Физика", true);
            student1.AddTests(test);
            test = new Test("Иностранный язык", true);
            student1.AddTests(test);
            test = new Test("ПрЧМИ", false);
            student1.AddTests(test);
            StudentsOfOurUniversity.AddStudents(student1);

            Student student2 = new Student("Мельпомена", "Сурана", new DateTime(2003, 6, 7), 21, Education.Bachelor);
            exam = new Exam("Математика", 5, new DateTime(2022, 6, 18));
            student2.AddExams(exam);
            exam = new Exam("Физика", 5, new DateTime(2022, 6, 12));
            student2.AddExams(exam);
            exam = new Exam("Иностранный язык", 5, new DateTime(2022, 6, 11));
            student2.AddExams(exam);
            exam = new Exam("ПрЧМИ", 5, new DateTime(2022, 6, 24));
            student2.AddExams(exam);
            test = new Test("Физ-ра", false);
            student2.AddTests(test);
            test = new Test("Физика", true);
            student2.AddTests(test);
            test = new Test("Иностранный язык", true);
            student2.AddTests(test);
            test = new Test("ПрЧМИ", true);
            student2.AddTests(test);
            StudentsOfOurUniversity.AddStudents(student2);

            Student student3 = new Student("Бия", "Тревельян", new DateTime(1999, 1, 10), 14, Education.SecondEducation);
            exam = new Exam("Математика", 4, new DateTime(2022, 6, 19));
            student3.AddExams(exam);
            exam = new Exam("Физика", 3, new DateTime(2022, 6, 12));
            student3.AddExams(exam);
            exam = new Exam("Иностранный язык", 5, new DateTime(2022, 6, 1));
            student3.AddExams(exam);
            exam = new Exam("ПрЧМИ", 3, new DateTime(2022, 6, 30));
            student3.AddExams(exam);
            test = new Test("Физ-ра", false);
            student3.AddTests(test);
            test = new Test("Физика", false);
            student3.AddTests(test);
            test = new Test("Иностранный язык", true);
            student3.AddTests(test);
            test = new Test("ПрЧМИ", true);
            student3.AddTests(test);
            StudentsOfOurUniversity.AddStudents(student3);

            Student student4 = new Student("Солона", "Амелл", new DateTime(2004, 7, 28), 13, Education.Specialist);
            exam = new Exam("Математика", 4, new DateTime(2022, 6, 5));
            student4.AddExams(exam);
            exam = new Exam("Физика", 3, new DateTime(2022, 6, 8));
            student4.AddExams(exam);
            exam = new Exam("Иностранный язык", 5, new DateTime(2022, 6, 19));
            student4.AddExams(exam);
            exam = new Exam("ПрЧМИ", 3, new DateTime(2022, 6, 30));
            student4.AddExams(exam);
            test = new Test("Физ-ра", true);
            student4.AddTests(test);
            test = new Test("Физика", true);
            student4.AddTests(test);
            test = new Test("Иностранный язык", true);
            student4.AddTests(test);
            test = new Test("ПрЧМИ", true);
            student4.AddTests(test);
            StudentsOfOurUniversity.AddStudents(student4);

            Console.WriteLine(StudentsOfOurUniversity.ToString());

            //2
            Console.WriteLine("Для созданного объекта StudentCollection вызвать методы, выполняющие сортировку списка List < Student > по разным критериям, ипосле каждой сортировки вывести данные объекта.");

            StudentsOfOurUniversity.SortByLastName();
            Console.WriteLine("\nСортировка по фамилии: "+StudentsOfOurUniversity.ToString());

            StudentsOfOurUniversity.SortByDateOfBirth();
            Console.WriteLine("\nСортировка по дате рождения: " + StudentsOfOurUniversity.ToString());

            StudentsOfOurUniversity.SortByGPA();
            Console.WriteLine("\nСртировка по среднему баллу: " + StudentsOfOurUniversity.ToShortString());

            //3
            Console.WriteLine("Вызвать методы класса StudentCollection, выполняющие операции со списком List<Student>, и после каждой операции вывести результат операции.");
            Console.WriteLine("Максимальный средний балл: ");
            Console.WriteLine(StudentsOfOurUniversity.MaxGPA);
            Console.WriteLine("Студенты, учащиеся на специалитете: ");
            foreach (Student student in StudentsOfOurUniversity.GetSpecialists)
                Console.WriteLine(student.ToString());
            //Console.WriteLine("Введите средний балл с которым будут найдены студенты: ");
            //double gpa = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Студенты со средним баллом 3.75:");
            List <Student> students = StudentsOfOurUniversity.AverageMarkGroup(3.75);
            if (students == null)
            {
                Console.WriteLine("Нет студентов с заданным средним баллом");
            }
            else
            {
                foreach (Student student in students)
                    Console.WriteLine(student.ToString());
            }

            //4
            Console.WriteLine("\nСоздать объекс типа TestCollections. Вызвать метод для поиска в коллекции 1, центрального, последнего и элемента, не содержащегося в коллекции.");
            int AmountOfElements = 1000000;
            TestCollections collection = new TestCollections(AmountOfElements);
            Console.WriteLine("\nПоиск первого элемента:");
            collection.TimeSearch(0.ToString(), new Person("Имя" + 0.ToString(), "Фамилия" + 0.ToString(), new DateTime(2000, 1, 1)), new Student("Имя" + 0.ToString(), "Фамилия" + 0.ToString(), new DateTime(2000, 1, 1), 11, Education.Specialist));
            Console.WriteLine("\nПоиск центрального элемента:");
            collection.TimeSearch((AmountOfElements/2).ToString(), new Person("Имя" + (AmountOfElements / 2).ToString(), "Фамилия" + (AmountOfElements / 2).ToString(), new DateTime(2000, 1, 1)), new Student("Имя" + (AmountOfElements / 2).ToString(), "Фамилия" + (AmountOfElements / 2).ToString(), new DateTime(2000, 1, 1), 11, Education.Specialist));
            Console.WriteLine("\nПоиск последнего элемента:");
            collection.TimeSearch((AmountOfElements - 1).ToString(), new Person("Имя" + (AmountOfElements-1).ToString(), "Фамилия" + (AmountOfElements - 1).ToString(), new DateTime(2000, 1, 1)), new Student("Имя" + (AmountOfElements - 1).ToString(), "Фамилия" + (AmountOfElements - 1).ToString(), new DateTime(2000, 1, 1), 11, Education.Specialist));
            Console.WriteLine("\nПоиск элемента которого нет в коллекции:");
            collection.TimeSearch(AmountOfElements.ToString(), new Person("Екатерина", "Афонина", new DateTime(2003, 12, 13)), new Student("Екатерина", "Афонина", new DateTime(2003, 12, 13), 21, Education.Bachelor));

        }
    }
}
