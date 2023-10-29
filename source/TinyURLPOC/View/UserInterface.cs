using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURLPOC.Helpers;

namespace TinyURLPOC.View
{
    public class UserInterface
    {
        public static void Run()
        {
            UserInputValidation inputValidation = new UserInputValidation();


            Console.WriteLine("Welcome to the application");

            Console.WriteLine("MENU");
            Console.WriteLine("1. (ADD) Create Short URL - Option for Alias - Option for auto generated one");
            Console.WriteLine("2. (DELETE) Delete ShortUrl From Associated Original URL");
            Console.WriteLine("3. (GetById) Retrieve Original URL from Short URL");
            Console.WriteLine("4. (GetById) Get The Count on how many times the Original URL has been retrieved");
            Console.WriteLine("5. (GetAll) Get All Created ShortUrls Associated With OriginalUrl");

            var menuInput = Console.ReadLine();

            if (inputValidation.IsValidMenuOption(menuInput))
            {
                var option = int.Parse(menuInput);
                switch (option)
                {
                    case (int) UserInputValidation.ValidationType.ADD:
                    {
                        //Console.WriteLine("6. Add")
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid User Input, try again");
            }
            

            
        }
    }
}
