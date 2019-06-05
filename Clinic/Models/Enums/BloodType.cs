using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.Enums
{
    public enum BloodType
    {
        [Display(Name = "Первая")]
        First,
        [Display(Name = "Вторая")]
        Second,
        [Display(Name = "Третья")]
        Third,
        [Display(Name = "Четвертая")]
        Fourth
    }

    public enum Rhesus
    {
        [Display(Name = "Положительный")]
        Plus,
        [Display(Name = "Отрицательный")]
        Minus
    }
}