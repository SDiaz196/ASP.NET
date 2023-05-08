#pragma warning disable CS8618
namespace DojoSurvey_Validations.Models;
using System.ComponentModel.DataAnnotations;

public class Survey
{
    [Required(ErrorMessage = "is required!")]
    [MinLength(2)]
    public string Name { get; set; }

    [Required(ErrorMessage = "is required!")]
    public string Location { get; set; }

    [Required(ErrorMessage = "is required!")]
    public string Language { get; set; }

    [MinLength(20)]
    public string? Comment { get; set; }
}