class Student
{
    public string FirstName;
    public string LastName;
    public int[] Marks;

    public Student(string firstName, string lastName, int[] marks)
    {
        FirstName = firstName;
        LastName = lastName;
        Marks = marks;
    }

    public override string ToString() => FirstName + " " + LastName;
}
