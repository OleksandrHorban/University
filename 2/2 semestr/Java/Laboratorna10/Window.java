import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

import java.util.Iterator;
import java.util.TreeSet;

public class Window extends JFrame {

    private JLabel surnameLabel;
    private JTextField surnameTextField;
    private JPanel surnamePanel;

    private JLabel phoneLabel;
    private JTextField phoneTextField;
    private JPanel phonePanel;

    private JButton printButton;
    private JPanel printButtonPanel;

    private JLabel countOfRecordsLabel;
    private JTextField countOfRecordsTextField;
    private JPanel countOfRecordsPanel;

    private JPanel mainPanel;


    protected int counter;
    protected TreeSet<Person> Persons;


    public Window() {
        super("Frame title");

        counter = 0;
        Persons = new TreeSet<Person>();


        this.setSize(450, 250);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setResizable(false);
        this.setLocationRelativeTo(null);



        surnamePanel = new JPanel();
        surnamePanel.setBorder(BorderFactory.createMatteBorder(1, 1, 0, 1, Color.BLACK));

        surnameLabel = new JLabel("Surname");
        surnameTextField = new JTextField(30);
        surnamePanel.add(surnameLabel);
        surnamePanel.add(surnameTextField);


        phonePanel = new JPanel();
        phonePanel.setBorder(BorderFactory.createMatteBorder(0, 1, 0, 1, Color.BLACK));

        phoneLabel = new JLabel("Phones");
        phoneTextField = new JTextField(30);
        phonePanel.add(phoneLabel);
        phonePanel.add(phoneTextField);


        printButtonPanel = new JPanel();
        printButtonPanel.setBorder(BorderFactory.createMatteBorder(0, 1, 1, 1, Color.BLACK));

        printButton = new JButton("Print");
        printButtonPanel.add(printButton);


        countOfRecordsPanel = new JPanel();
        countOfRecordsPanel.setBorder(BorderFactory.createLineBorder(Color.BLACK));

        countOfRecordsLabel = new JLabel("Count of records");
        countOfRecordsTextField = new JTextField(3);
        countOfRecordsTextField.setText(String.valueOf(counter));
        countOfRecordsTextField.setEditable(false);
        countOfRecordsPanel.add(countOfRecordsLabel);
        countOfRecordsPanel.add(countOfRecordsTextField);


        JPanel countOfRecordsPadingPanel = new JPanel();
        countOfRecordsPadingPanel.setLayout(new GridLayout(1, 1));
        countOfRecordsPadingPanel.setBorder(BorderFactory.createEmptyBorder(2, 0, 0, 0));
        countOfRecordsPadingPanel.add(countOfRecordsPanel);


        mainPanel = new JPanel(new GridLayout(4, 1));
        mainPanel.add(surnamePanel);
        mainPanel.add(phonePanel);
        mainPanel.add(printButtonPanel);
        mainPanel.add(countOfRecordsPadingPanel);



        JPanel paddingPanel = new JPanel(new GridLayout(1, 1));
        paddingPanel.setBorder(BorderFactory.createEmptyBorder(4, 4, 4, 4));
        paddingPanel.add(mainPanel);

        Container container = this.getContentPane();
        container.add(paddingPanel);


        surnameTextField.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {

                phoneTextField.requestFocus();
            }
        });
        phoneTextField.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {

                String surname = surnameTextField.getText();
                String phone = phoneTextField.getText();

                if (surname != null && phone != null) {

                    Persons.add(new Person(surname, phone));

                    surnameTextField.setText("");
                    phoneTextField.setText("");

                    counter++;
                    countOfRecordsTextField.setText(String.valueOf(counter));


                    surnameTextField.requestFocus();
                }
            }
        });
        printButton.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {


                Iterator<Person> iter = Persons.iterator();

                System.out.println("All records: ");
                while (iter.hasNext()) {

                    System.out.print(iter.next().toString());

                    if (iter.hasNext())
                        System.out.println(",");
                }
            }
        });



        this.setVisible(true);
    }
}
