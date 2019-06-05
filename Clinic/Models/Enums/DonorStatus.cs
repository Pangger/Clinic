using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.Enums
{
    public enum DonorStatus
    {
        [Display(Name = "Потенциальный донор")]
        PotentialDonor,
        [Display(Name = "Отказано")]
        Canceled,
        [Display(Name = "Временно отказано")]
        CanceledTemporary
    }
}