import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.StringTokenizer;

public class Main {
    public static void main(String[] args) {

        if (args.length == 0) {
            System.out.println("Потрібен параметр виклику: ім'я файлу");
            return;
        }

        BufferedReader fin = null;
        try {
            fin = new BufferedReader(new FileReader(args[0]));

            String line;
            while ((line = fin.readLine()) != null) {
                System.out.println("Введений рядок: " + line);

                StringTokenizer tokenizer = new StringTokenizer(line);
                System.out.println(" Рядок складається з:");
                while (tokenizer.hasMoreTokens()) {
                    String token = tokenizer.nextToken();
                    System.out.print(token);
                    try {
                        double number = Double.parseDouble(token);
                        System.out.print(" - це число = " + number);
                    } catch (NumberFormatException e) {
                        System.out.print(" - це не число");
                    }
                    System.out.println();
                }
            }
        } catch (FileNotFoundException e) {
            System.out.println("Файл не знайдений");
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (fin != null) {
                try {
                    fin.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}