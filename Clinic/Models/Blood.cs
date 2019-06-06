using Clinic.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Blood
    {
        public int Id { get; set; }

        [Display(Name = "Дата сдачи анализа")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Объем")]
        public double Amount { get; set; }

        [Display(Name = "Тип анализа")]
        public string DonationType { get; set; }
        public int? DonorId { get; set; }
        public Donor Donor { get; set; }

        [Display(Name = "Статус анализа")]
        public BloodStatus BloodStatus { get; set; }
    }
}