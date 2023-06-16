import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class RadioBtnFrame extends JFrame implements ActionListener {


    private JLabel questionLabel;
    private JRadioButton[] answerOptions;
    private JButton nextButton;
    private ArrayList<Integer> scoreList;
    private int currentQuestionIndex;

    private static final String[] QUESTIONS =
    	{
            "What is the capital of Ukraine?",
            "What is the largest planet in our solar system?",
            "What is the highest mountain in the world?"
    	};

    private static final String[][] ANSWERS =
    	{
            {"Kyiv", "Lviv", "Odessa"},
            {"Jupiter", "Saturn", "Mars"},
            {"Mount Kilimanjaro", "Mount Everest", "Mount Fuji"}
    	};

    public RadioBtnFrame()
    {
        super("Test Program");

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(500, 300);
        setLocationRelativeTo(null);

        JPanel mainPanel = new JPanel(new BorderLayout());

        JPanel questionPanel = new JPanel(new FlowLayout());
        questionLabel = new JLabel();
        questionPanel.add(questionLabel);

        JPanel answerPanel = new JPanel(new GridLayout(0, 1));
        answerOptions = new JRadioButton[3];
        for (int i = 0; i < answerOptions.length; i++)
        {
            answerOptions[i] = new JRadioButton();
            answerPanel.add(answerOptions[i]);
        }

        mainPanel.add(questionPanel, BorderLayout.NORTH);
        mainPanel.add(answerPanel, BorderLayout.CENTER);

        JPanel buttonPanel = new JPanel(new FlowLayout());
        nextButton = new JButton("Next");
        nextButton.addActionListener(this);
        buttonPanel.add(nextButton);

        mainPanel.add(buttonPanel, BorderLayout.SOUTH);

        setContentPane(mainPanel);

        scoreList = new ArrayList<>();
        currentQuestionIndex = -1;

        nextQuestion();
    }

    private void nextQuestion()
    {
        if (currentQuestionIndex >= 0)
            for (int i = 0; i < answerOptions.length; i++)
                if (answerOptions[i].isSelected())
                {
                    if (ANSWERS[currentQuestionIndex][i].endsWith("*")) scoreList.add(5);
                    else scoreList.add(2);
                }

        currentQuestionIndex++;

        if (currentQuestionIndex < QUESTIONS.length)
        {
            questionLabel.setText(QUESTIONS[currentQuestionIndex]);
            for (int i = 0; i < answerOptions.length; i++)
            {
                answerOptions[i].setText(ANSWERS[currentQuestionIndex][i].replace("*", ""));
                answerOptions[i].setSelected(false);
            }
        }
        else
        {
            int totalScore = 0;
            for (int score : scoreList) totalScore += score;

            double averageScore = (double) totalScore / scoreList.size();

            JOptionPane.showMessageDialog(this, "Your average score is " + averageScore);
            dispose();
        }
    }

    @Override
    public void actionPerformed(ActionEvent e)
    {
        if (e.getSource() == nextButton) nextQuestion();
    }
}



