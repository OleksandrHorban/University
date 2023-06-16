import java.io.File;
import java.util.Scanner;

public class DeleteFilesFromDirectory {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String directoryPath = args[0];

        File directory = new File(directoryPath);
        if (!directory.isDirectory()) {
            System.out.println("Каталогу " + directoryPath + " не існує.");
            return;
        }

        File[] files = directory.listFiles();
        if (files == null || files.length == 0) {
            System.out.println("Каталог " + directoryPath + " порожній.");
            return;
        }

        System.out.println("У каталозі " + directoryPath + " знаходиться " + files.length + " файлів.");
        System.out.print("Бажаєте видалити ці файли? (Y/N) ");
        String answer = scanner.nextLine().trim().toLowerCase();
        if (!answer.equals("y")) {
            return;
        }

        for (File file : files) {
            if (file.isFile()) {
                file.delete();
            }
        }

        System.out.println("Файли видалено.");
    }

}
