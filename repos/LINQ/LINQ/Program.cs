class Problem1
{
    static void Main()
    {
        List<Student> students = new();
        Console.WriteLine("Enter name, surname and group number");
        while (true)
        {
            
            string[] action = Console.ReadLine()?.Split();

            if (action != null)
                if (action[0].ToLower() == "end")
                {
                    Console.WriteLine();
                    break;
                }
                else if (action.Length == 3)
                {
                    students.Add(new Student(action[0], action[1], Convert.ToInt32(action[2])));
                }
        }

        var SelectedStudents = from s in students // кожен елемент з students передається в s
                               where s.Group == 2 // при умові що Group = 2
                               orderby s.FirstName // сортирування по спаданню за іменем
                               select s; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }
}
