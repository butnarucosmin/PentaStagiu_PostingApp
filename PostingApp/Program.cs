using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace PostingApp
{
    class Program
    {
        private static UserService userservice = new UserService();
        private static PostService postservice = new PostService();
       

        private static void DisplayMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Add a new post");
            Console.WriteLine("3 - Display all posts");
            Console.WriteLine("4 - Display all users");
            Console.WriteLine("5 - Display post by index");
            Console.WriteLine("6 - Exit");            
        }

        private static void Register()
        {
            username:     
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(username))
            {                
                Console.WriteLine("Invalid option. Try again!");
                goto username;
            }
            else
            {
                foreach (User user in userservice.GetUsers())
                {
                    if (username == user.UserName)
                    {
                        Console.WriteLine("Invalid option. Try again!");
                        goto username;
                    }
                }
            }

            firstname:
            Console.WriteLine("Enter Your First Name:");
            string firstname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(firstname))
            {
                Console.WriteLine("Invalid option. Try again!");
                goto firstname;
            }

            lastname:
            Console.WriteLine("Enter Your Last Name:");
            string lastname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(lastname))
            {
                Console.WriteLine("Invalid option. Try again!");
                goto lastname;
            }

        birthday:
            Console.WriteLine("Enter your Birthdate(DD/MM/YYYY)");
            string input = Console.ReadLine();
            string format = "dd/MM/yyyy";
            DateTime birthday = new DateTime();
            CultureInfo provider = CultureInfo.InvariantCulture;

            try
            {
                birthday = DateTime.ParseExact(input, format, provider);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", input);
                goto birthday;
            }

            if (birthday < DateTime.Today)
            {
                userservice.AddUser(username, firstname, lastname, birthday);
            }
            else
            {
                Console.WriteLine("Invalid option. Try again!");
                goto birthday;
            }
        }

        private static void AddPost()
        {
            postservice.PostAdded += Postservice_PostAdded;

            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();
            List<string> usernamelist = new List<string>();

            foreach (var user in userservice.GetUsers())
            {
                usernamelist.Add(user.UserName);
            }

            if (usernamelist.Contains(username))
            {
                Console.WriteLine("Please enter your message:");
                postservice.AddPost(username, Console.ReadLine(), DateTime.Now);                
            }
            else
            {
                Console.WriteLine("\nPlease Register First!");

                ConsoleKeyInfo c;
                do
                {
                    Console.Write("\nPress Enter to go to menu!");
                    c = Console.ReadKey();
                } while (c.Key != ConsoleKey.Enter);
            }            
        }

        private static void Postservice_PostAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Post Added!");
            Thread.Sleep(1000);
        }

        private static void DisplayAllPosts()
        {
            var posts = postservice.GetPosts().OrderByDescending(x => x.Time);

            if (posts.Count() == 0)
            {
                Console.WriteLine("There are no posts!");
            }
            else
            {
                Console.WriteLine("All posts:");

                foreach (Post post in posts)
                {
                    Console.WriteLine($"{post.Time}: {post.Message} Posted by {post.UserName}");
                }
            }

            ConsoleKeyInfo c;
            do
            {
                Console.Write("\nPress Enter to go to menu!");
                c = Console.ReadKey();
            } while (c.Key != ConsoleKey.Enter);
        }

        private static void DisplayAllUsers()
        {
            if (userservice.GetUsers().Count() == 0)
            {
                Console.WriteLine("There are no users!");
            }
            else
            {
                Console.WriteLine("All users:");
                foreach (User user in userservice.GetUsers())
                {
                    Console.WriteLine(user.UserName);
                }
            }            

            ConsoleKeyInfo c;
            do
            {
                Console.Write("\nPress Enter to go to menu!");
                c = Console.ReadKey();
            } while (c.Key != ConsoleKey.Enter);
        }

        private static void DisplayPostbyIndex()
        {
            Console.WriteLine("Enter your index:");
            if(int.TryParse(Console.ReadLine(), out int index))
            {
                if (index < postservice.GetPosts().Count())
                    Console.WriteLine(postservice[index].Message);
                else
                    Console.WriteLine("Index too large!");
            }
            else
            {
                Console.WriteLine("Invalid option. Try again!");
            }

            ConsoleKeyInfo c;
            do
            {
                Console.Write("\nPress Enter to go to menu!");
                c = Console.ReadKey();
            } while (c.Key != ConsoleKey.Enter);
        }

        static void Main(string[] args)
        {
         start:
            postservice.PostAdded -= Postservice_PostAdded;
            Console.Clear();
            DisplayMenu();
            Console.WriteLine("Your option is:");
            int option = 0;
            int.TryParse(Console.ReadLine(), out option);
            Console.WriteLine();

            switch (option)
            {
                case 1:
                    Register();                    
                    goto start;
                case 2:
                    AddPost();
                    goto start;                
                case 3:
                    DisplayAllPosts();
                    goto start;
                case 4:
                    DisplayAllUsers();
                    goto start;
                case 5:
                    DisplayPostbyIndex();
                    goto start;
                case 6:
                    return;                
                default:
                    Console.WriteLine("Invalid option. Try again!");
                    Thread.Sleep(2000);
                    goto start;
            }
        }
    }
}
