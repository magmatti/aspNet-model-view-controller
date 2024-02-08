using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class RentedCar
{
    [Key]
    public int RentID { get; set; }
    public int ClientID {  get; set; }
    public int CarID { get; set; }

    [DataType(DataType.Date)]
    public DateTime RentDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReturnDate {  get; set; }
    public decimal Cost {  get; set; }

    // Foreign Keys
    public Clients Client { get; set; }
    public Car car { set; get; }
}
