using System.ComponentModel.DataAnnotations;

namespace lostsocks.Models.Socks
{
    /// <summary>
    /// http://www.codeproject.com/Tips/550784/Validation-using-DataAnnotations
    /// 
    /// </summary>
    public class EditSockModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "no more than 500 characters please.")]
        public string Description { get; set; }

        public string ImageSrc { get; set; }

    }
}