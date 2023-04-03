import javax.swing.SwingUtilities;

public class Login {

    public static void main(String[] args) {

        SwingUtilities.invokeLater(new Runnable() {

            @Override
            public void run() {

                new Frame();
            }
        });
    }

}