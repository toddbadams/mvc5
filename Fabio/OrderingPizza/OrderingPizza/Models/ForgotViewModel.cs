using System.ComponentModel.DataAnnotations;

namespace OrderingPizza.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}