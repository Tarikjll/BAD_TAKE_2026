using System.ComponentModel.DataAnnotations;

namespace CHEZSWA.ViewModels
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
                // Als value null is, fout (kan aanpassen als nodig)
                if (value == null)
                    return false;

                // Vergelijk value met de verwachte waarde
                return value.Equals(_expectedValue);
            }
        }
    }
}
