using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Reflection1;

public class Person : IValidatable
{
    [Required(ErrorMessage = "Введите имя")]
    public string Name { get; set; }
    [Range(0, 100, ErrorMessage = "Некорректный возраст")]
    public string Age { get; set; }

    public IEnumerable<ValidationResult> Validate()
    {
        var result = new List<ValidationResult>();
        var property = GetType().GetProperties();

        foreach (var propertyInfo in property)
        {
            var value = propertyInfo.GetValue(this);
            var validationAttr = propertyInfo.GetCustomAttributes<ValidationAttribute>();

            foreach (var validationAttribute in validationAttr)
            {
                if (!validationAttribute.IsValid(value))
                {
                    result.Add(new ValidationResult(validationAttribute.ErrorMessage));
                    Console.WriteLine(validationAttribute.ErrorMessage);
                }
            }
        }

        return result;
    }
}