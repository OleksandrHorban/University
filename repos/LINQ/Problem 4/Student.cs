class Student
{
    public string FirstName;
    public string LastName;

    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString() => FirstName + " " + LastName;
}
