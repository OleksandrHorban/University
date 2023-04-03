import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

public class Frame extends JFrame {

	JPasswordField password;
	JTextField login;
	JLabel labelLogin;
	JLabel labelPassword;
	JButton btn_Ok;
	JButton btn_Cancel;

	public Frame() {
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setSize(400, 300);
		this.setResizable(false);
		this.setTitle("Login Window");
		this.setLocationRelativeTo(null);
		this.setLayout(null);


		labelLogin = new JLabel("Login");
		labelLogin.setBounds(80, 40, 200, 30);

		login = new JTextField();
		login.setBounds(150, 40, 200, 30);

		this.add(login);
		this.add(labelLogin);


		labelPassword = new JLabel("Password");
		labelPassword.setBounds(80, 80, 200, 30);

		password = new JPasswordField();
		password.setBounds(150, 80, 200, 30);

		this.add(labelPassword);
		this.add(password);



		btn_Ok = new JButton("Ok");
		btn_Ok.setBounds(180, 140, 60, 30);

		btn_Cancel = new JButton("Cancel");
		btn_Cancel.setBounds(250, 140, 100, 30);

		this.add(btn_Ok);
		this.add(btn_Cancel);


		this.setVisible(true);
	}

}