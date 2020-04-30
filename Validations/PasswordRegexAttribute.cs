using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DominionClone
{
    public class PasswordRegExAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // value == string password
            string strRegex = "^(.{0,7}|[^0-9]*|[a-zA-Z0-9]*)$";

            Regex regex = new Regex(strRegex);

            bool is_valid = true;
            string pw = (string)value;
            Console.WriteLine($"checking pw: {pw}");
            Console.WriteLine($"is_valid: {is_valid}");

            if (regex.IsMatch(pw)) { is_valid = false; }
            Console.WriteLine($"is_valid: {is_valid}");

            if (!is_valid)
            {
                return new ValidationResult("must contain at least 1 number, 1 letter, and 1 special character");
            }
            else { return ValidationResult.Success; }

        }

    }
}