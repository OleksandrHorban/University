import java.util.Scanner;

public class SecondProblem {
    public static void main(String[] args) {
        System.out.println("Введіть перший катет");
        Scanner scan1 = new Scanner(System.in);
        double firstkatet = scan1.nextInt();
        System.out.println("Введіть другий катет");
        Scanner scan2 = new Scanner(System.in);
        double secondkatet = scan2.nextInt();
        double hypotenuza = Math.hypot(firstkatet,secondkatet);
        System.out.println("Гіпотенуза = " + hypotenuza);
        double Arcsin = Math.asin(firstkatet/secondkatet);
        double Degrees = Math.toDegrees(Arcsin);
        System.out.println("Кут який лежить навпроти першого катета = " + Degrees);
        double Degree2 = 90-Degrees;
        System.out.println("Кут який лежить навпроти другого катета = " + Degree2);
    }
    }
