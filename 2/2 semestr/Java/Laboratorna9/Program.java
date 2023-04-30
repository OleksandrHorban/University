import java.util.ArrayList;

public class Program {

    public static void main(String[] args) {

        Student.print(
                new ArrayList<Student>() {
                    {
                        add(new Student("Ivan", 244));
                        add(new Student("Mykola", 344));
                        add(new Student("Stepan", 144));
                        add(new Student("Oleksandr", 144));
                        add(new Student("Mark", 444));
                        add(new Student("Yuriy", 244));
                        add(new Student("Anatoliy", 244));
                        add(new Student("Oksana", 344));
                        add(new Student("Vika", 144));
                        add(new Student("Maria", 344));
                    }},
                244);
    }
}