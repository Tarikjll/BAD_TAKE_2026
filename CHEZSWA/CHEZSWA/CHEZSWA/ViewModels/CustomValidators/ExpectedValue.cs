using System.ComponentModel.DataAnnotations;

namespace CHEZSWA.ViewModels.CustomValidators
{
    public class ExpectedValue
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class ExpectedValueAttribute : ValidationAttribute
        {
            private readonly object _expectedValue;

            public ExpectedValueAttribute(object expectedValue)
            {
                _expectedValue = expectedValue;
            }

            public override bool IsValid(object value)
            {
                
                if (value == null)
                    return false;

            
                return value.Equals(_expectedValue);
            }
        }
    }
}
