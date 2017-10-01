using System.ComponentModel.DataAnnotations;

namespace ConsoleLib
{
    class Reader
    {
        [Required]
        public string       Name { get; set; }

        public ReaderGender Gender    { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Signature must contain only two letters")]
        public string       Signature { get; set; }
    }
}
