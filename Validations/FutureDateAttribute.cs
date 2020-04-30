using System;
using System.ComponentModel.DataAnnotations;
namespace DominionClone
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime CurrentTime = DateTime.Now;
            DateTime inputDate = Convert.ToDateTime(value);
            int currDate = (int.Parse(DateTime.Now.ToString("yyyyMMdd")));
            int partyDate = (int.Parse(inputDate.ToString("yyyyMMdd")));


            Console.WriteLine($"\n\ncurrDate: {currDate}\n\npartyDate: {partyDate}");

            if (partyDate < currDate)
            {
                return new ValidationResult("date entered is invalid");
            }
            else { return ValidationResult.Success; }

        }

    }
}