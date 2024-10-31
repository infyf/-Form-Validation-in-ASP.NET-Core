using System;
using System.ComponentModel.DataAnnotations;

namespace lr10.Models
{
    public class ConsultationRequest
    {
        [Required(ErrorMessage = "Поле 'Ім'я прізвище' є обов'язковим.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Поле 'Email' є обов'язковим.")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле 'Бажана дата консультації' є обов'язковим.")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Дата має бути в майбутньому.")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Виберіть продукт.")]
        public string SelectedProduct { get; set; }
    }
}
