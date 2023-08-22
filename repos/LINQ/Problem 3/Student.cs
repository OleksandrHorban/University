class Student
{
    public string FirstName;
    public string LastName;
    public int Age;

    public Student(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName + " " + Age;
    }
}
