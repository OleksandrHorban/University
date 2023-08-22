class Problem11
{
    static void Main()
    {
        List<Student> students = new();
        List<StudentSpeciality> specialities = new();

        int index = 0;
        while (true)
        {
            string[] action = Console.ReadLine().Split();

            if (action != null)
                if (action[0].ToLower() == "end") { 
                    Console.WriteLine(); 
                    break; 
                }
                else
                {
                    if (action[0].ToLower() == "students:")
                    {
                        index++; // перехід на ввід студентів
                    }
                    else if (index == 0 && action.Length >= 2)
                    {
                        specialities.Add(new StudentSpeciality(string.Join(' ', action[0..^1]), action[^1]));
                    }
                    else if (action.Length == 3)
                    {
                        students.Add(new Student(action[1], action[2], action[0]));
                    }
                }
        }

        var SelectedStudents = from s in students // береться значення з студентів
                               join ss in specialities // береться значення з спеціальностей
                               on s.FacultyNumber equals ss.FacultyNumber // критерії з'єднування
                               orderby s.FirstName // сортування за іменем студентів
                               select new // новий об'єкт
                               {
                                   s.FirstName, // ім'я
                                   s.LastName, // прізвище
                                   ss.FacultyNumber, // номер спеціальності
                                   ss.SpecialityName // назва спеціальності
                               };

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.FacultyNumber} {student.SpecialityName}");
        }
    }
}

record class Student(string FirstName, string LastName, string FacultyNumber);
record class StudentSpeciality(string SpecialityName, string FacultyNumber);
