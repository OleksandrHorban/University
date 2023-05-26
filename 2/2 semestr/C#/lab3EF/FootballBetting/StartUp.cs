using FootballBetting.Data;
using System;

namespace FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            using (FootballBettingContext context = new FootballBettingContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
