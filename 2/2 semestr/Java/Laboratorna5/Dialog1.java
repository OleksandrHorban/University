import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Dialog1 {

    public static void main(String[] args) {

        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        }
        catch(Exception e) {
            System.out.println(e.getMessage());
        }

        JFrame frm = new JFrame("First visual application");
        frm.setSize(600, 400);

        Container c = frm.getContentPane();
        c.add(new JLabel("Hello world"));

        WindowListener wndCloser = new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        };

        frm.addWindowListener(wndCloser);
        frm.setVisible(true);
    }
}