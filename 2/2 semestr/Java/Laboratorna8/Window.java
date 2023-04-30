import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.util.ArrayList;

public class Window extends JFrame {

    ArrayList<String> list = new ArrayList<String>();

    JLabel inputLabel = new JLabel("Input field");
    JTextField inputTextField = new JTextField(30);
    JLabel outputLabel = new JLabel("Output field");
    JTextField outputTextField = new JTextField(30);
    JButton buttonCopy = new JButton("Copy");
    JButton buttonPrint = new JButton("Print");

    public Window() {
        super("Frame title");
        this.setSize(300, 200);
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
        buttonPanel.add(buttonCopy);
        buttonPanel.add(buttonPrint);

        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());
        panel.add(inputPanel, BorderLayout.CENTER);
        panel.add(outputPanel, BorderLayout.SOUTH);


        Container container = getContentPane();
        container.add(panel, BorderLayout.CENTER);
        container.add(buttonPanel, BorderLayout.SOUTH);

        buttonCopy.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {

                list.add(inputTextField.getText());
                outputTextField.setText(inputTextField.getText());
            }
        });
        buttonPrint.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {


                System.out.println("List items:");
                for (String item : list)
                    System.out.println(item);
            }
        });


        this.setVisible(true);
    }
}
