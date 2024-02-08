using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class CarMake
{
    [Key]
    public int MakeID { get; set; }

    [Required]
    [Display(Name = "Model")]
    public string MakeName {  get; set; }
}
