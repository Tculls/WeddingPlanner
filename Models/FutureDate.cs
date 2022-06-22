
using System.ComponentModel.DataAnnotations;
public class FutureDate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        DateTime weddingDate = Convert.ToDateTime(value);
        if (weddingDate.Date > DateTime.Now)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("must be a future date");
        }
    }
}