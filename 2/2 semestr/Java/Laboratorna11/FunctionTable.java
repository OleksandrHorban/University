import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class FunctionTable extends JFrame implements ActionListener {

    private static final long serialVersionUID = 1L;

    private JTextField aField, hField, nField;
    private JTextArea resultArea;

    public FunctionTable() {
        super("Function Table");

        JPanel inputPanel = new JPanel(new GridLayout(3, 2, 5, 5));
        inputPanel.add(new JLabel("Параметр А:"));
        aField = new JTextField();
        inputPanel.add(aField);
        inputPanel.add(new JLabel("крок(h):"));
        hField = new JTextField();
        inputPanel.add(hField);
        inputPanel.add(new JLabel("Кількість точок:"));
        nField = new JTextField();
        inputPanel.add(nField);

        JButton computeButton = new JButton("Обрахувати");
        computeButton.addActionListener(this);

        resultArea = new JTextArea(10, 40);
        JScrollPane scrollPane = new JScrollPane(resultArea);
        scrollPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);

        add(inputPanel, BorderLayout.NORTH);
        add(scrollPane, BorderLayout.CENTER);
        add(computeButton, BorderLayout.SOUTH);

        setSize(500, 400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setVisible(true);
    }

    public void actionPerformed(ActionEvent e) {
        double a = Double.parseDouble(aField.getText());
        double h = Double.parseDouble(hField.getText());
        int n = Integer.parseInt(nField.getText());

        resultArea.setText("");
        resultArea.append(String.format("%10s %10s\n", "X", "Y"));
        for (int i = 0; i < n; i++) {
            double x = i * h;
            double y = a * Math.sqrt(x) * Math.sin(a * x);
            resultArea.append(String.format("%10.2f %10.2f\n", x, y));
        }
    }
}
