using System.ComponentModel.DataAnnotations;

namespace lostsocks.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}