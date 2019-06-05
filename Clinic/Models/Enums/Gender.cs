using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.Enums
{
    public enum Gender
    {
        [Display(Name = "Мужчина")]
        Man,
        [Display(Name = "Женщина")]
        Woman
    }
}