

public class Person implements Comparable<Person> {

    public String surname;
    public String phone;

    public Person(String surname, String phone) {

        this.surname = surname;
        this.phone = phone;
    }


    public int compareTo(Person p) {

        return surname.compareTo(p.surname);
    }

    @Override
    public String toString() {

        return
                "{\n" +
                        "   \"Surname\": \"" + surname + "\"\n" +
                        "   \"Phone\": \"" + phone + "\"" +
                        "\n}";
    }
}
