using System.ComponentModel.DataAnnotations;

namespace CostumersAPI.Costumer
{
    public class CostumerBase
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Cellphone { get; set; }
        [Required]
        public DateTime? Birthdate { get; set; }
        [Required]
        public bool? EmailSms { get; set; }
        [Required]
        public bool? Whatsapp { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Address { get; set;}
        [Required]
        public int? Number { get; set; }

        public string? EmailConfirmation { get; set; }
    }
}
