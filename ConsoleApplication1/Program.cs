using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDbContext context = new EFDbContext();
            List<User> users = context.Users.ToList();

            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();

            List<User> matches = users
                .Where(x => x.Username == username)
                .ToList();
            User match;
            if(matches.Count < 1)
            {
                Console.WriteLine("User not found.");
                return;
            }
            else
            {
                match = matches.FirstOrDefault();
            }
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            if(match.Password == password)
            {
                Console.WriteLine("Welcome, " + match.Name);
            }
            else
            {
                Console.WriteLine("Incorrect password!");
            }

            Console.ReadLine();
        }
    }
}
