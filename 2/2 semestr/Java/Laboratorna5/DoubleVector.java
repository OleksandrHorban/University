import java.awt.*;
import java.awt.event.*;
import javax.swing.*;


public class DoubleVector {

    private double[] vector = null;

    public DoubleVector(double[] vector) {
        this.vector = vector;
    }



    public double multi(DoubleVector anotherVector) {
        double s = 0;

        for (int i = 0; i < vector.length; i++)
            s += vector[i] * anotherVector.vector[i];

        return s;
    }

    public static double multi(DoubleVector a, DoubleVector b) {
        return a.multi(b);
    }


    public double sum(DoubleVector anotherVector) {
        double s = 0;

        for (int i = 0; i < vector.length; i++)
            s += vector[i] + anotherVector.vector[i];

        return s;
    }

    public static double sum(DoubleVector a, DoubleVector b) {
        return a.sum(b);
    }


    public double riz(DoubleVector anotherVector) {
        double s = 0;

        for (int i = 0; i < vector.length; i++)
            s += vector[i] + (-anotherVector.vector[i]);

        return s;
    }

    public static double riz(DoubleVector a, DoubleVector b) {
        return a.riz(b);
    }


    public double multinum(double num) {
        double s = 0;

        for(int i = 0; i < vector.length; i++)
            s += vector[i] * num;

        return s;
    }

    public static double multinum(DoubleVector a, double num) {
        return a.multinum(num);
    }



    public static void main(String[] args) {

        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        }
        catch(Exception e) {
            System.out.println(e.getMessage());
        }

        JFrame jFrame = new JFrame("DoubleVector");
        jFrame.setSize(400, 700);

        Container container = jFrame.getContentPane();
        container.setLayout(new FlowLayout());



        double[] a = {1, 2, 3, 4};
        double[] b = {1, 1, 1, 1};
        double[] c = {2, 2, 2, 2};

        DoubleVector v1 = new DoubleVector(a);
        DoubleVector v2 = new DoubleVector(b);
        DoubleVector v3 = new DoubleVector(c);

        String result = "<html>";


        result += "v1 * v2 = " + v1.multi(v2) + "<br/>";
        result += "v1 * v2 = " + DoubleVector.multi(v1, v2) + "<br/>";
        result += "v1 * v3 = " + v1.multi(v3) + "<br/>" + "<br/>";


        result += "v1 + v2 = " + v1.sum(v2) + "<br/>";
        result += "v1 + v2 = " + DoubleVector.sum(v1, v2) + "<br/>";
        result += "v1 + v3 = " + v1.sum(v3) + "<br/>" + "<br/>";


        result += "v1 - v2 = " + v1.riz(v2) + "<br/>";
        result += "v1 - v2 = " + DoubleVector.riz(v1, v2) + "<br/>";
        result += "v1 - v3 = " + v1.riz(v3) + "<br/>" + "<br/>";


        result += "v1 * 3 = " + v1.multinum(3) + "<br/>";
        result += "v2 * 3 = " + DoubleVector.multinum(v2, 3) + "<br/>";
        result += "v3 * 3 = " + v3.multinum(3) + "<br/>" + "<br/>";

        result += "</html>";

        JLabel label = new JLabel(result);
        label.setFont(new Font("Serif", Font.PLAIN, 25));

        container.add(label);



        WindowListener windowListener = new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        };
        jFrame.addWindowListener(windowListener);
        jFrame.setVisible(true);
    }
}