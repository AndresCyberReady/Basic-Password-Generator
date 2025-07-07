using System;
using System.Linq; // Required for Any()

namespace PasswordChecker
{
    class Program
    {
        public static void Main(string[] args)
        {
            int minLength = 8;
            int score = 0;
            string password;

            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";
            string specialChars = "@#$%!*";

            Console.WriteLine("Please enter a password");
            password = Console.ReadLine();

            // Check password length
            if (password.Length >= minLength)
            {
                score += 1;
            }

            // Check for uppercase characters
            if (password.Any(c => uppercase.Contains(c)))
            {
                score += 1;
            }

            // Check for lowercase characters
            if (password.Any(c => lowercase.Contains(c)))
            {
                score += 1;
            }

            // Check for digits
            if (password.Any(c => digits.Contains(c)))
            {
                score += 1;
            }

            // Check for special characters
            if (password.Any(c => specialChars.Contains(c)))
            {
                score += 1;
            }

            // Output the score
            Console.WriteLine($"Password score: {score}. Please still make sure to visit haveibeenpwned.com to ensure your password has not been seen before");

            // Provide feedback based on the score using a switch statement
            switch (score)
            {
                
                case 4:
                    Console.WriteLine("Password is extremely strong.");
                    break;
                case 3:
                    Console.WriteLine("Password is strong.");
                    break;
                case 2:
                    Console.WriteLine("Password is medium.");
                    break;
                case 1:
                    Console.WriteLine("Password is weak.");
                    break;
                default:
                    Console.WriteLine("Password doesn't meet any of the standards.");
                    break;
            }
        }
    }
}