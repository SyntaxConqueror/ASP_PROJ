using System.ComponentModel.DataAnnotations;
using System;
using LR10.Attributes;

namespace LR10.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле Ім'я прізвище є обов'язковим")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Поле Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Введіть коректний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Бажана дата консультації є обов'язковим")]
        [FutureDate(ErrorMessage = "Бажана дата має бути в майбутньому")]
        [NotOnWeekend(ErrorMessage = "Консультація не може проходити на вихідні")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Поле Продукт є обов'язковим")]
        public string SelectedProduct { get; set; }
    }
}
