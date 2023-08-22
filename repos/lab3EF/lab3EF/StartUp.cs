using StudentSystem.Data;
using System;

namespace StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (StudentSystemContext context = new StudentSystemContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
