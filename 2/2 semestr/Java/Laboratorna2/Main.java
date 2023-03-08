import java.lang.*;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        System.out.println("Ex 1 : ");
        Task(30);
        System.out.println("Ex 2 :");
        System.out.print("Введіть кут в градусах ");
        Scanner scan = new Scanner(System.in);
        double angle = scan.nextDouble();
        Task(angle);
    }
    public static void Task(double angle){
        double angle_in_radian = Math.toRadians(angle);
        double sin = Math.sin(angle_in_radian);
        double cos = Math.cos(angle_in_radian);
        System.out.format("Sin %.1f = %.2f\n", angle,sin);
        System.out.format("Cos %.1f = %.2f\n", angle,cos);
    }
}