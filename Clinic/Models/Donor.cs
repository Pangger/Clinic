using Clinic.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Donor
    {
        public int Id { get; set; }

        [Display(Name="Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Display(Name = "Номер сертификата")]
        public string CertificationNumber { get; set; }

        [Display(Name = "Группа крови")]
        public BloodType BloodType { get; set; }

        [Display(Name = "Резус")]
        public Rhesus Rhesus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата подачи заявки")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfApplication { get; set; }

        [Display(Name = "Адрес")]
        public string Adress { get; set; }

        [Display(Name = "Номер медицинской карты")]
        public string MedicalCardNumber { get; set; }
        public virtual ICollection<Blood> BloodTests { get; set; }

        [Display(Name = "Статус донора")]
        public DonorStatus DonorStatus { get; set; }
        public string Comment { get; set; }

        public Donor()
        {
            BloodTests = new List<Blood>();
        }
    }
}