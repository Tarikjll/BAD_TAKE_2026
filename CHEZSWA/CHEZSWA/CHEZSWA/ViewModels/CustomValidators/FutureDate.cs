using System.ComponentModel.DataAnnotations;
namespace CHEZSWA.ViewModels.CustomValidators
{
    public class FutureDate : ValidationAttribute
    {

        private readonly object _expectedValue;

        public override bool IsValid(object? value)
        {
          if (value is DateTime dateValue)
            {
                return dateValue >= DateTime.Now;
            }
            return false;
        }
    }

}
