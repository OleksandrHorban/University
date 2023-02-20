import java.io.IOException;
public class Example
{
    public static void main(String[] args)
    {
        char inChar;
        System.out.println("Input symbol");
        try {
            inChar=(char)System.in.read();
            System.out.println("Your symbol is "+inChar);
        }
        catch (IOException e)
        {System.out.println("Input ERROR");
        }
    }
}

