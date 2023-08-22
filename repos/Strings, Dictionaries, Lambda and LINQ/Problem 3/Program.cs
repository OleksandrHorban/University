class Problem3
{
    static void Main()
    {
        string Email = Console.ReadLine();
        string? Text = Console.ReadLine();

        if (Email != null && Text != null)
        {
            string ChangedEmail = "";
            int index = 0;

            for (int i = 0; i < Email.Length; i++)
                if (Email[i] != '@') { 
                    ChangedEmail += (index == 0 ? '*' : Email[i]); 
                }
                else {
                    index++; 
                    ChangedEmail += Email[i]; 
                }

            Text = Text.Replace(Email, ChangedEmail);
            Console.WriteLine("\n" + Text);
        }
    }
}
