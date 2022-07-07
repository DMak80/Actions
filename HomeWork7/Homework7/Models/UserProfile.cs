using System.ComponentModel.DataAnnotations;

namespace Homework7.Models;

public enum Sex
{
    Male,
    Female
};

public class UserProfile
{
    [Required (ErrorMessage = "Не указано имя!")]
    [MaxLength(30, ErrorMessage = "Длина строки должна быть не более 30 символов")]
    [Display(Name = "Имя")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Не указана фамилия!")]
    [MaxLength(30, ErrorMessage = "Длина строки должна быть не более 30 символов")]
    [Display(Name = "Фамилия")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Не указано отчество!")]
    [MaxLength(30, ErrorMessage = "Длина строки должна быть не более 30 символов")]
    [Display(Name = "Отчество")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Не указан возраст!")]
    [Range(10, 100, ErrorMessage = "Возраст должен быть в диапазоне от 10 до 100")]
    [Display(Name = "Возраст")]
    public int Age { get; set; }

    [Display(Name = "Пол")]
    public Sex Sex { get; set; }
} 