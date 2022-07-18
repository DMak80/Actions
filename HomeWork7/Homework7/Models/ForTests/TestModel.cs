using System.ComponentModel.DataAnnotations;
using Homework7.ErrorMessages;
using Homework7.Models.ForTests;

namespace Homework7.Models;

public class TestModel : BaseModel
{
    //without [Display(Name = "Имя")]
    [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"{nameof(FirstName)} {Messages.MaxLengthMessage}")]
    public override string FirstName { get; set; } = null!;

    //without [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"{nameof(LastName)} {Messages.MaxLengthMessage}")]
    [Display(Name = "Фамилия")]
    public override string LastName { get; set; } = null!;

    //without [MaxLength(30, ErrorMessage = $"{nameof(MiddleName)} {Messages.MaxLengthMessage}")]
    [Required(ErrorMessage = Messages.RequiredMessage)]
    [Display(Name = "Отчество")]
    public override string? MiddleName { get; set; }
    
    //without [Display(Name = "Возраст")]
    [Range(10, 100, ErrorMessage = $"{nameof(Age)} {Messages.RangeMessage}")]
    public override int Age { get; set; }
    
    [Display(Name = "Пол")]
    public override Sex Sex { get; set; }
}