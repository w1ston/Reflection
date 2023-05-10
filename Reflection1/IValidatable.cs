using System.ComponentModel.DataAnnotations;

namespace Reflection1;

public interface IValidatable
{
    IEnumerable<ValidationResult> Validate();
}