#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Wedding
{
    [Key]

    public int WeddingId {get; set; }

    [Required(ErrorMessage = "Please input Wedder Name")]
    [MinLength(3, ErrorMessage ="Please add a Wedder name of atleast 3 characters")]
    [Display(Name = "Wedder One")]

    public string WedderOne {get; set; }

    [Required(ErrorMessage = "Please input Wedder Name")]
    [MinLength(3, ErrorMessage ="Please add a Wedder name of atleast 3 characters")]
    [Display(Name = "Wedder Two")]

    public string WedderTwo {get; set; }

    [Required]
    [FutureDate(ErrorMessage = "Please make wedding a future date")]

    public DateTime WeddingDate {get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Please input the Wedding Address")]
    [Display(Name = "Wedding Address")]

    public string WeddingAddress {get; set; }
}