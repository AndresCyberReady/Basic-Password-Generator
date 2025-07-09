using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordChecker
{
    class Program
    {
        // Constants for password criteria
        private const int MinLength = 8;
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string DigitChars = "0123456789";
        private const string SpecialChars = "@#$%!*";

        static void Main(string[] args)
        {
            bool continueChecking = true;
            
            do
            {
                Console.Clear();
                Console.WriteLine("=== Password Strength Checker ===\n");
                Console.WriteLine("Enter a password (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input?.ToLower() == "exit")
                {
                    continueChecking = false;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("\nError: Password cannot be empty. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                var (score, feedback) = CheckPassword(input);
                
                Console.WriteLine($"\nPassword score: {score}/5");
                
                if (feedback.Length > 0)
                {
                    Console.WriteLine("\nSuggestions to improve your password:");
                    foreach (var suggestion in feedback)
                    {
                        Console.WriteLine($"- {suggestion}");
                    }
                }

                Console.WriteLine($"\nRemember to check your password against breaches at haveibeenpwned.com");
                
                switch (score)
                {
                    case 5:
                        Console.WriteLine("\n✅ Password is extremely strong.");
                        break;
                    case 4:
                        Console.WriteLine("\n⚠️  Password is strong but could be improved.");
                        break;
                    case 3:
                        Console.WriteLine("\n⚠️  Password is medium strength.");
                        break;
                    case 2:
                        Console.WriteLine("\n❌ Password is weak.");
                        break;
                    case 1:
                        Console.WriteLine("\n❌ Password is very weak.");
                        break;
                    default:
                        Console.WriteLine("\n❌ Invalid password format.");
                        break;
                }

                Console.WriteLine("\nWould you like to try another password? (y/n)");
                string choice = Console.ReadLine();
                continueChecking = choice?.ToLower() == "y";
                continueChecking = continueChecking || choice?.ToLower() == "yes";

            } while (continueChecking);

            Console.WriteLine("\nThank you for using the Password Strength Checker!");
        }

        private static (int score, string[] feedback) CheckPassword(string password)
        {
            var feedbackList = new List<string>();
            int score = 0;

            // Check length requirement
            if (password.Length >= MinLength)
            {
                score++;
            }
            else
            {
                feedbackList.Add($"Minimum length is {MinLength} characters.");
            }

            // Check for uppercase letters
            if (password.Any(c => UppercaseChars.Contains(c)))
            {
                score++;
            }
            else
            {
                feedbackList.Add("Add at least one uppercase letter.");
            }

            // Check for lowercase letters
            if (password.Any(c => LowercaseChars.Contains(c)))
            {
                score++;
            }
            else
            {
                feedbackList.Add("Add at least one lowercase letter.");
            }

            // Check for digits
            if (password.Any(c => DigitChars.Contains(c)))
            {
                score++;
            }
            else
            {
                feedbackList.Add("Include at least one number.");
            }

            // Check for special characters
            if (password.Any(c => SpecialChars.Contains(c)))
            {
                score++;
            }
            else
            {
                feedbackList.Add($"Add at least one special character ({SpecialChars})");
            }

            return (score, feedbackList.ToArray());
        }
    }
}