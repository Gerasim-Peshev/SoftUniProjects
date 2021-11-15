using System;

namespace P04PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            if (ContainCheck(pass) == false || LettersAndDigits(pass) == false || HowDigsCont(pass) == false)
            {
                if (ContainCheck(pass) == false)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }

                if (LettersAndDigits(pass) == false)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }

                if (HowDigsCont(pass) == false)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
            else
            {
                Console.WriteLine("Password is valid");
            }

            //if (ContainCheck(pass) == true && LettersAndDigits(pass) == true && HowDigsCont(pass) == true)
            //{
            //    Console.WriteLine("Password is valid");
            //}

            //if (ContainCheck(pass) == false && LettersAndDigits(pass) == true && HowDigsCont(pass) == true)
            //{
            //    Console.WriteLine("Password must be between 6 and 10 characters");
            //}

            //if (ContainCheck(pass) == true && LettersAndDigits(pass) == false && HowDigsCont(pass) == true)
            //{
            //    Console.WriteLine("Password must consist only of letters and digits");
            //}

            //if (ContainCheck(pass) == true && LettersAndDigits(pass) == true && HowDigsCont(pass) == false)
            //{
            //    Console.WriteLine("Password must have at least 2 digits");
            //}
        }

        static bool ContainCheck(string word)
        {
            return word.Length >= 6 && word.Length <= 10;

            //if (word.Length >= 6 && word.Length <= 10)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        static bool LettersAndDigits(string word)
        {
            foreach (char character in word)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    return false;
                }
            }

            return true;

            //bool ckeck = false;

            //for (int i = 0; i < word.Length; i++)
            //{
            //    char piece = word[i];

            //    if (piece <= 48 || piece >= 122)
            //    {
            //        ckeck = false;
            //        break;
            //    }
            //    else
            //    {
            //        ckeck = true;
            //    }
            //}

            //if (ckeck)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        static bool HowDigsCont(string word)
        {
            int count = 0;

            foreach (char character in word)
            {
                if (char.IsDigit(character))
                {
                    count++;
                }
            }

            return count >= 2 ? true : false;

            //int count = 0;

            //for (int i = 0; i < word.Length; i++)
            //{
            //    char piece = word[i];

            //    if (piece >= 48 && piece <= 57)
            //    {
            //        count++;
            //    }
            //}

            //if (count >= 2)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
