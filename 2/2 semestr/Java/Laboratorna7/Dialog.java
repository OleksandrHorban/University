import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Dialog extends JFrame {

    JTextField fld = new JTextField(20);
    JButton btn = new JButton("Press");
    JLabel lbl = new JLabel(" ");
    JPanel textPanel = new JPanel();
    JPanel btnPanel = new JPanel();
    JPanel lblPanel = new JPanel();

    public Dialog() {
        super("Window");
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setSize(350, 150);
        this.setResizable(false);
        this.setLocationRelativeTo(null);


        lblPanel.add(lbl);
        textPanel.add(fld);
        btnPanel.add(btn);

        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());


        panel.add(lbl, BorderLayout.NORTH);
        panel.add(fld, BorderLayout.CENTER);
        panel.add(btn, BorderLayout.SOUTH);

        Container mainPane = this.getContentPane();
        mainPane.add(panel);

        fld.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {

                lbl.setText("Input text: " + fld.getText());
            }
        });
        btn.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {

                lbl.setText("Press button");
            }
        });


        this.setVisible(true);
    }
}