using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Car
{
    [Key]
    public int CarID { get; set; }
    public int MakeID { get; set; }
    public string Model { get; set; }

    [Required]
    [Range(1980, 2024, ErrorMessage = "Podaj wlasciwy rok!")]
    [Display(Name = "Rok produkcji")]
    public int YearOfProduction {  get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [Range(1, 2000)]
    [Display(Name = "Cena za dzien")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceForDay { get; set; }
    
    // Foreign key
    public CarMake carMake { get; set; }
}
