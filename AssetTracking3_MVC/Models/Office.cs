using System.ComponentModel.DataAnnotations;

namespace AssetTracking3_MVC.Models
{
    public class Office
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please write a country name")]
        public string Country { get; set; }
        [Required(ErrorMessage ="Please write currency code")]
        [StringLength(3,ErrorMessage ="it should contain 3 charactors")]
        [Display(Name ="Currency Code")]
        public string Currency { get; set; }
        [Required(ErrorMessage ="Please enter exchagne rate to USD")]
        [Range(0,double.MaxValue,ErrorMessage ="Please enter a valid number")]
        [Display(Name ="Exchange to USD")]
        public double Rate { get; set; }

    }
}
