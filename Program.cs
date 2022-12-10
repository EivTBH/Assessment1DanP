using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace MenuSelect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please Enter your logon number:");

            
            string logonID = "0000000"; //Sets ID length to compare
            while (logonID.Length > 5 || logonID.Length < 1 || String.IsNullOrWhiteSpace(logonID) || logonID == " ") //checks if logonID is longer than 5 characters, empty or has empty spaces

            {
                logonID = Console.ReadLine(); //commits logonID to memory
                

                Console.Clear();
                if (logonID.Length > 5) //stops error message appearing if successful logonID is entered
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: logonID is too long, please re-enter");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (String.IsNullOrWhiteSpace(logonID) || logonID == " ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error please enter a logonID");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            

            Console.WriteLine($"Logging in {logonID}...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"Thank-you {logonID}, please select from the following options:");
            Console.WriteLine("");
            Menu(logonID);
            Console.Clear();
            Exit_Message(logonID);
            
        }



        //Provide user with 3 choices upon entry of logon ID
        static void Menu(string logonID)

        {

            {
                Console.WriteLine("Type the corrosponding number then hit enter...");
                    int choice = 0;

                while (choice < 3 || choice > 0) //ensures only choices within range can be chosen
                {
                    {
                        Console.WriteLine("1:Create User");
                        Console.WriteLine("2:Factorial Result");
                        Console.WriteLine("3:Quit");


                        try //catches any errant exceptions
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid input");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                    }


                    if (choice == 1) //choice 1,2,3 sends users to appropriate method

                    {
                        Console.Clear();
                        User_Name(logonID);
                    }

                    if (choice == 2)

                    {
                        Console.Clear();
                        factorial_Result(logonID);
                    }

                    else if (choice == 3) //breaks loop if user chooses to exit program
                    {
                        Console.Clear();
                                             
                        break; 
                    }

                }

            }


            //This prompts user to enter full name


            static void User_Name(string logonID)
            {
                Console.Clear();
                Console.WriteLine($"This is option 1, {logonID}");
                Console.WriteLine("Please enter your First and Last name seperated by a space:");

                string fullName = null;
                do
                    try
                    {
                        fullName = Console.ReadLine();

                        if (fullName.Contains(" ") == false) //provides appropriate feedback if no space exists in between names
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: there is no space entered in the user name, cannot set a valid userID");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Please enter your First and Last name seperated by a space");

                        }
                        else if (String.IsNullOrWhiteSpace(fullName) || fullName == " ") //provides appropriate feedback if string is empty or is only an empty space
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error please enter a valid user name in the format firstname space last name.");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (fullName.Any(c => !char.IsLetter(c)))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your name cannot contain numbers. Please input a valid user name in the format firstname space last name");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                            
                    }
                    catch (Exception ex)
                    { }
                while (fullName == " " || String.IsNullOrWhiteSpace(fullName) || fullName.Contains(" ") == false || fullName.Any(c => !char.IsLetter(c))); //loops if string doesn't contain a space or is null/empty space

                Create_User(fullName);
            }


            //Removes everything but first name first initial and surname with space removed.
            static void Create_User(string pfullName)
            {

                string firstInitial = pfullName.Substring(0,1); //seperates first initial from forename
                int spacePos = pfullName.IndexOf(' '); //uses the space as seperator
                string surName = pfullName.Substring(spacePos+1); //+1 is to remove the space between forename and surname
                string userName = firstInitial + surName; //joins forname and surname as single string
                userName = userName.Trim(); //trims errant spaces at the beginning or end of name
                Console.WriteLine ($"user name allocated is {userName}");
                Console.WriteLine("Returning to root menu");
                Thread.Sleep(2000);
                Console.Clear ();
                
                
            }


            //calculate the factorial of a number entered by the user
            static void factorial_Result(string logonID)
            {
                Console.WriteLine($"This is option 2, {logonID}");
                Console.WriteLine("Please enter a number between 1 & 17");

                bool errorcorrect = false;
                int factorial = 0;
                do
                {
                    try
                    {
                         factorial = Convert.ToInt32(Console.ReadLine());

                    

                    
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.WriteLine($"The entered number was {factorial}"); //outputs user entered number to console
                    Console.WriteLine("Calculating...");
                    Thread.Sleep(1000);



                    if (factorial > 1 && factorial < 18)
                    {
                        int count = factorial;
                        string display = factorial.ToString();  //display is the factorial number

                        for (int i = factorial - 1; i > 0; i--)
                        {
                            count *= i;
                            display = display + " * " + i.ToString(); //join equation to display string

                        }
                        Console.WriteLine(display); // display string
                        Console.WriteLine("Factorial of {0}! = {1}\n", factorial, count);



                        Console.ReadKey();
                            Console.WriteLine("Returning to root menu");
                            Thread.Sleep (1000);
                            Console.Clear();
                            errorcorrect = true;
                        }

                    else if (factorial == 1)
                    {
                        Console.WriteLine("Factorial of 1 = 1");
                            Console.ReadKey();
                            Console.Clear();
                            errorcorrect = true;
                        }

                    else if (factorial <=0) //disallows negative integers
                    {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a positive whole number greater than 0");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            errorcorrect = false;
                            
                    }

                        else if (factorial == 18 || factorial > 18)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid number between 1 & 17");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            errorcorrect = false;
                        }

                    }

                    catch (Exception ex)
                    {   
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid whole number");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        errorcorrect = false;
                    }
                    

                } while (errorcorrect == false);



            }
           


        }

        //Provides obvious exit message to user so they don't believe the program exited due to error.
        static void Exit_Message(string logonID)
        {
            Console.Clear();
            Console.WriteLine("Thank-you for using Name-A-Tron 3000, the program is now closing, have a nice day.");
            Thread.Sleep(2000);
        }
    }
}