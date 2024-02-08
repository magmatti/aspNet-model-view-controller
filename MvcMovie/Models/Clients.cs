using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Clients
{
    [Key]
    public int ClientID { get; set; }

    [Required]
    [Display(Name = "Imie Klienta")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Nazwisko")]
    public string Surrname { get; set; }

    [Required]
    public string Email {  get; set; }

    [Required]
    public int Telefon {  get; set; }
}
