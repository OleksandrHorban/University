class Student
{
    public string Id;
    public int[] Marks;

    public Student(string id, int[] marks)
    {
        Id = id;
        Marks = marks;
    }

    public override string ToString() => string.Join(' ', Marks);
}
