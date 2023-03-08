import java.util.Scanner;

public class SymbolTest {
    public static void main(String[] args) {
        System.out.println("Введіть кількість генерованих символів");
        Scanner x = new Scanner(System.in);
        String d = x.next();
        int number = Integer.parseInt(d);
        for ( int i = 0; i < number; i++ ) {
            char c = (char)(Math.random()*26 + 'a');
            System.out.print(c + ": ");
            switch ( c ) {
                case 'a': case 'e': case 'i':
                case 'o': case 'u':
                    System.out.println("гласная");
                    break;
                case 'y': case 'w':
                    System.out.println("иногда гласная");
                    break;
                default:
                    System.out.println("согласная");
            }
        }
    }
}
