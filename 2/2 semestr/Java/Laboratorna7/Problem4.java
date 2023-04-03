import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Problem4 extends JFrame {

    JLabel inputLabel = new JLabel("Поле вводу");
    JTextField inputTextField = new JTextField(20);
    JLabel outputLabel = new JLabel("Поле виводу");
    JTextField outputTextField = new JTextField(20);
    JButton button = new JButton("Копіювати");

    public Problem4() {
        super("Frame title");
        this.setSize(400, 150);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setResizable(false);
        this.setLocationRelativeTo(null);


        JPanel inputPanel = new JPanel();
        inputPanel.add(inputLabel, BorderLayout.CENTER);
        inputPanel.add(inputTextField, BorderLayout.SOUTH);

        JPanel outputPanel = new JPanel();
        outputPanel.add(outputLabel, BorderLayout.CENTER);
        outputPanel.add(outputTextField, BorderLayout.SOUTH);

        JPanel buttonPanel = new JPanel();
        buttonPanel.add(button);

        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());
        panel.add(inputPanel, BorderLayout.CENTER);
        panel.add(outputPanel, BorderLayout.SOUTH);


        Container container = getContentPane();
        container.add(panel);
        container.add(buttonPanel, BorderLayout.SOUTH);

        button.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {

                outputTextField.setText(inputTextField.getText());
            }
        });


        this.setVisible(true);
    }
}