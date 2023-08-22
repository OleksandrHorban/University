class Student
{
    public string FirstName;
    public string LastName;
    public string Email;

    public Student(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public override string ToString() => FirstName + " " + LastName;
}