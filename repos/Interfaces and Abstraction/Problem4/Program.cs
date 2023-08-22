namespace P04_Telephony
{
    public class Program
    {
        public static void Main()
        {
            SmartPhone smartPhone = new SmartPhone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smartPhone.Call(phoneNumber));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(site));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}