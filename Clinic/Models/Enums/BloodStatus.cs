using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.Enums
{
    public enum BloodStatus
    {
        [Display(Name = "Для потенциального использования")]
        ForPotentialUse,
        [Display(Name = "Отказано")]
        Canceled,
        [Display(Name = "Временно отказано")]
        CanceledTemporary,
        [Display(Name = "На первичном анализе")]
        OnPrimaryAnalysis,
        [Display(Name = "Пригодна для использования")]
        SuitableForUse
    }
}