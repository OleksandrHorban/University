import java.util.*;

public class Student {

    private String name;
    private int course;

    public Student(String name, int course) {
        this.name = name;
        this.course = course;
    }


    public String getName() { return this.name; }
    public int getCourse() { return this.course; }

    public static void print(List<Student> students, int course) {

        Iterator<Student> iter = students.iterator();
        while(iter.hasNext()) {

            Student student = iter.next();

            if (student.getCourse() == course)
                System.out.println(student.getName());
        }
    }
}
