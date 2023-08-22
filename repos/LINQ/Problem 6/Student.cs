class Student
{
    public string FirstName;
    public string LastName;
    public string Phone;

    public Student(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public override string ToString() => FirstName + " " + LastName;
}