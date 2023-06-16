import java.io.*;
import java.util.*;

public class InputTest {
    public static void main(String args[]) {
        if (args.length < 2) {
            System.out.println("Нужно два параметра вызова: имя файла и строка для поиска");
            return;
        }

        String filename = args[0];
        String searchString = args[1];

        String thisLine;
        ArrayList<String> list = new ArrayList<>();
        BufferedReader fin = null;

        try {
            fin = new BufferedReader(new InputStreamReader(new FileInputStream(filename)));

            while ((thisLine = fin.readLine()) != null) {
                System.out.println("==Введена строка:" + thisLine);
                list.add(thisLine);
            }

            Collections.sort(list);
            System.out.println("Отсортированный список строк:");
            Iterator<String> iter = list.iterator();

            while (iter.hasNext()) {
                String str = iter.next();
                System.out.println(str);
            }

            System.out.println("Результат поиска для строки '" + searchString + "':");
            boolean found = false;

            for (String str : list) {
                if (str.contains(searchString)) {
                    System.out.println(str);
                    found = true;
                }
            }

            if (!found) {
                System.out.println("Строка '" + searchString + "' не найдена в списке.");
            }

        } catch (FileNotFoundException e) {
            System.out.println("Файл не найден: " + filename);
            System.out.println("Error: " + e);
        } catch (IOException e) {
            System.out.println("Ошибка ввода/вывода. Файл " + filename);
            System.out.println("Error: " + e);
        } finally {
            if (fin != null) {
                try {
                    fin.close(); // !!! Закрыть файл
                } catch (IOException ex) {
                    System.out.println("Ошибка закрытия файла " + filename);
                    System.out.println("Error: " + ex);
                }
            }
        }
    }
}
